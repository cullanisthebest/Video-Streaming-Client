using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlayingVideoCullan
{
    class Controller
    {
        private static View _view;
        RTSPModel _RTSPModel = null;
        Thread videoTimerThread = null;
        RTPModel _RTPModel = null;
        byte[] videoFrame;
        String sessionNum;

        //Connect button is clicked
        public void Connect_btn_Click(object sender, EventArgs e)
        {
            //Determine which view to control
            _view = (View)((Button)sender).FindForm();

            //disable the connect button
            _view.Disable_Connect();

            //Listen for server
            this.ListenForServer();

            //enable the setup button
            _view.Enable_Button("setup");
        }

        //Setup button is clicked
        public void Setup_btn_Click(object sender, EventArgs e)
        {
            //Determine which view to control
            if (sender is Button)
                _view = (View)((Button)sender).FindForm();
            else if (sender is PictureBox)
                _view = (View)((PictureBox)sender).FindForm();

            //Build the request message
            String[] requestMsg = { "SETUP", this.GetServerIP().ToString(), this.GetPortNumber(), this.GetVideoName() };

            //send the request message to the server
            _RTSPModel.send(requestMsg);

            //wait for the reply from the server
            String reply = _RTSPModel.listen();

            //parse reply to get session number
            reply = reply.Trim();
            String[] replyArr = reply.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
            sessionNum = replyArr[6];

            //format server's reply to display in server box
            reply = replyArr[0] + " " + replyArr[1] + " " + replyArr[2]
                + "\r\n" + replyArr[3] + " " + replyArr[4] + "\r\n"
                + replyArr[5] + " " + replyArr[6];

            UpdateServerBox(reply + Environment.NewLine);
            UpdateClientBox("New RTSP State: READY" + Environment.NewLine);
            //disable & enable appropriate buttons
            _view.Disable_Button("setup");
            _view.Enable_Button("play");
            _view.setImageBoxBlack();
        }

        //Play button is clicked
        public void Play_btn_Click(object sender, EventArgs e)
        {
            //Determine which view to control
            if (sender is Button)
                _view = (View)((Button)sender).FindForm();
            else if (sender is PictureBox)
                _view = (View)((PictureBox)sender).FindForm();

            //Build the request message
            String[] requestMsg = { "PLAY", this.GetServerIP().ToString(), this.GetPortNumber(), this.GetVideoName(), sessionNum };

            //send the request message to the server
            _RTSPModel.send(requestMsg);

            //wait for the reply from the server
            String reply = _RTSPModel.listen();

            reply = reply.Trim();
            String[] replyArr = reply.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);

            //format server's reply to display in server box
            reply = replyArr[0] + " " + replyArr[1] + " " + replyArr[2]
                + "\r\n" + replyArr[3] + " " + replyArr[4] + "\r\n"
                + replyArr[5] + " " + replyArr[6];

            if (replyArr[0] == "RTSP/1.0")
                UpdateServerBox(Environment.NewLine + reply + Environment.NewLine);

            //Start UDP video thread to start receiving images
            if (videoTimerThread == null)
            {
                this.videoTimerThread = new Thread(Communications);
                videoTimerThread.IsBackground = true; //to stop all threads with application is terminated
                this.videoTimerThread.Start();
            }

            UpdateClientBox("New RTSP State: PLAYING" + Environment.NewLine);

            //disable & enable appropriate buttons
            _view.Disable_Button("play");
            _view.Enable_Button("pause");
            _view.Enable_Button("teardown");
        }

        //Pause button is clicked
        public void Pause_btn_Click(object sender, EventArgs e)
        {
            //Determine which view to control
            if (sender is Button)
                _view = (View)((Button)sender).FindForm();
            else if (sender is PictureBox)
                _view = (View)((PictureBox)sender).FindForm();

            //Build the request message
            String[] requestMsg = { "PAUSE", this.GetServerIP().ToString(), this.GetPortNumber(), this.GetVideoName(), sessionNum };

            //send the request message to the server
            _RTSPModel.send(requestMsg);

            //wait for the reply from the server
            String reply = _RTSPModel.listen();

            reply = reply.Trim();
            String[] replyArr = reply.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);

            //format server's reply to display in server box
            reply = replyArr[0] + " " + replyArr[1] + " " + replyArr[2]
                + "\r\n" + replyArr[3] + " " + replyArr[4] + "\r\n"
                + replyArr[5] + " " + replyArr[6];

            if (replyArr[0] == "RTSP/1.0")
                UpdateServerBox(Environment.NewLine + reply + Environment.NewLine);

            UpdateClientBox("New RTSP State: PAUSED" + Environment.NewLine);

            //disable & enable appropriate buttons
            _view.Disable_Button("pause");
            _view.Enable_Button("play");
        }

        //Tear down button is clicked
        public void Teardown_btn_Click(object sender, EventArgs e)
        {
            //Determine which view to control
            if (sender is Button)
                _view = (View)((Button)sender).FindForm();
            else if (sender is PictureBox)
                _view = (View)((PictureBox)sender).FindForm();

            //Build the request message
            String[] requestMsg = { "TEARDOWN", this.GetServerIP().ToString(), this.GetPortNumber(), this.GetVideoName(), sessionNum };

            //send the request message to the server
            _RTSPModel.send(requestMsg);

            //wait for the reply from the server
            String reply = _RTSPModel.listen();

            reply = reply.Trim();
            String[] replyArr = reply.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);

            //format server's reply to display in server box
            reply = replyArr[0] + " " + replyArr[1] + " " + replyArr[2]
                + "\r\n" + replyArr[3] + " " + replyArr[4] + "\r\n"
                + replyArr[5] + " " + replyArr[6];

            if (replyArr[0] == "RTSP/1.0")
                UpdateServerBox(Environment.NewLine + reply + Environment.NewLine);

            UpdateClientBox("New RTSP State: TEARDOWN" + Environment.NewLine);

            //reset sequence number
            _RTSPModel.CSeqNum = 1;

            //disable & enable appropriate buttons
            _view.Enable_Button("setup");
            _view.Disable_Button("play");
            _view.Disable_Button("pause");
            _view.Disable_Button("teardown");
        }

        //close application
        public void Exit_btn_Click(object sender, EventArgs e)
        {
            if (videoTimerThread != null)
                this.videoTimerThread.Abort();
            Application.Exit();
        }

        //communications thread for UDP socket to receive video frames
        public void Communications()
        {
            //used to receive video frames from server
            _RTPModel = new RTPModel(this.GetServerIP(), this.GetPortNumber());

            while (true)
            {
                //converts the video frame into an image
                Image currentVideoFrame = _RTPModel.getImage(ref videoFrame);

                //break out of loop if video is over
                if (currentVideoFrame == null)
                {
                    _view.Disable_Button("pause");
                    break;
                }

                //store the video header
                byte[] videoFrameHeader = new byte[12];
                System.Buffer.BlockCopy(videoFrame, 0, videoFrameHeader, 0, videoFrameHeader.Length);

                //if packet report is checked, display packet report
                if (_view.PacketReportChecked())
                {
                    //get sequence number
                    byte[] sequenceNum = new byte[2];
                    System.Buffer.BlockCopy(videoFrameHeader, 2, sequenceNum, 0, sequenceNum.Length);
                    Array.Reverse(sequenceNum);
                    BitArray sequenceNumBits = new BitArray(sequenceNum);
                    int seqNumBitsStr = getIntFromBitArray(sequenceNumBits);

                    //get time stamp
                    byte[] timeStamp = new byte[4];
                    System.Buffer.BlockCopy(videoFrameHeader, 4, timeStamp, 0, timeStamp.Length);
                    Array.Reverse(timeStamp);
                    BitArray timeStampBits = new BitArray(timeStamp);
                    int timeStampBitsStr = getIntFromBitArray(timeStampBits);

                    //get payload type
                    byte[] type = new byte[1];
                    System.Buffer.BlockCopy(videoFrameHeader, 1, type, 0, type.Length);
                    BitArray typeBits = new BitArray(type);
                    typeBits.Set(7, false);
                    int timeBitsStr = getIntFromBitArray(typeBits);

                    this.UpdateClientBox(Environment.NewLine + "Got RTP packet with SeqNum #" + seqNumBitsStr
                        + ", Timestamp: " + timeStampBitsStr + " of type " + timeBitsStr + Environment.NewLine);
                }

                //if print header is checked, then display the header bits
                if (_view.PrintHeaderChecked())
                {
                    //convert the header bytes into bits
                    string headerBits = string.Join(" ", videoFrameHeader.Select(x => Convert.ToString(x, 2).PadLeft(8, '0')));

                    this.UpdateClientBox(Environment.NewLine + "RTP Header: " + headerBits + Environment.NewLine);
                }

                //display the image
                _view.setImageBox(currentVideoFrame);
            }

        }

        //connect with server using RTSP
        public void ListenForServer()
        {
            //Create a model to listen for server
            _RTSPModel = new RTSPModel(Int32.Parse(_view.GetPortNumber()), this.GetServerIP());

            UpdateClientBox("Client is waiting for server!" + Environment.NewLine);

            //blocks until the client has connected to the server
            _RTSPModel.ConnectWithServer();

            UpdateClientBox("Client connected to server!" + Environment.NewLine);
        }

        //get the client/server's IP
        public IPAddress GetServerIP()
        {
            IPAddress serverIP = _view.GetServerIP();
            return serverIP;
        }

        //get the client/server's port number
        public String GetPortNumber()
        {
            String portNumber = _view.GetPortNumber();
            return portNumber;
        }

        //get the video name
        public String GetVideoName()
        {
            String videoName = _view.GetVideoName();
            return videoName;
        }

        //update the server box
        public void UpdateServerBox(string msg)
        {
            _view.SetServerBox(msg);
        }

        //update the client box
        public void UpdateClientBox(string msg)
        {
            _view.SetClientBox(msg);
        }

        //convert bit array to int
        public int getIntFromBitArray(BitArray bitArray)
        {

            if (bitArray.Length > 32)
                throw new ArgumentException("Argument length shall be at most 32 bits.");

            int[] array = new int[1];
            bitArray.CopyTo(array, 0);
            return array[0];
        }
    }
}
