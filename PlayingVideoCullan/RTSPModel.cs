using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace PlayingVideoCullan
{
    class RTSPModel
    {
        public int port;
        public IPAddress ServerIP;
        public Socket tcpClient = new Socket(
            AddressFamily.InterNetwork,
            SocketType.Stream,
            ProtocolType.Tcp);
        IPEndPoint listenEndPoint;

        //byte array to store request and response messages between client and server
        public byte[] receiveBuffer = new byte[4096];

        public int CSeqNum;

        public RTSPModel(int _port, IPAddress serverIP)
        {
            this.port = _port;
            this.ServerIP = serverIP;
            this.CSeqNum = 1;

            listenEndPoint = new IPEndPoint(ServerIP, port);
        }

        //connect client with the server
        public void ConnectWithServer()
        {
            try
            {
                //Connect the client to the server at the server's end point
                tcpClient.Connect(listenEndPoint);
            }
            catch
            {
                if (tcpClient != null)
                {
                    tcpClient.Close();
                }
            }
        }

        //client send message to server
        public void send(String[] clientMessage)
        {
            try
            {
                //set up the SETUP request
                if (clientMessage[0] == "SETUP")
                {
                    String clientResponseMsg = clientMessage[0] + " rtsp://" + clientMessage[1] + ":" + clientMessage[2] + "/" + clientMessage[3] + " RTSP/1.0\r\n"
                        + "CSeq: " + CSeqNum + "\r\n" 
                        + "Transport: RTP/UDP; " + "client_port= 11000";
                    receiveBuffer = System.Text.Encoding.UTF8.GetBytes(clientResponseMsg);
                }
                //set up the PLAY request
                else if (clientMessage[0] == "PLAY")
                {
                    String clientResponseMsg = clientMessage[0] + " rtsp://" + clientMessage[1] + ":" + clientMessage[2] + "/" + clientMessage[3] + " RTSP/1.0\r\n"
                        + "CSeq: " + CSeqNum + "\r\n" 
                        + "Session: " + clientMessage[4];
                    receiveBuffer = System.Text.Encoding.UTF8.GetBytes(clientResponseMsg);
                }
                //set up the PAUSE request
                else if (clientMessage[0] == "PAUSE")
                {
                    String clientResponseMsg = clientMessage[0] + " rtsp://" + clientMessage[1] + ":" + clientMessage[2] + "/" + clientMessage[3] + " RTSP/1.0\r\n"
                        + "CSeq: " + CSeqNum + "\r\n" 
                        + "Session: " + clientMessage[4];
                    receiveBuffer = System.Text.Encoding.UTF8.GetBytes(clientResponseMsg);
                }
                //set up the TEARDOWN request
                else if (clientMessage[0] == "TEARDOWN")
                {
                    String clientResponseMsg = clientMessage[0] + " rtsp://" + clientMessage[1] + ":" + clientMessage[2] + "/" + clientMessage[3] + " RTSP/1.0\r\n"
                        + "CSeq: " + CSeqNum + "\r\n" 
                        + "Session: " + clientMessage[4];
                    receiveBuffer = System.Text.Encoding.UTF8.GetBytes(clientResponseMsg);
                }

                //increment sequence number
                this.CSeqNum++;

                //send the request to the server
                tcpClient.Send(receiveBuffer);
            }
            catch (SocketException err)
            {
                Console.WriteLine("Error occurred on accepted socket:" + err.Message + Environment.NewLine + Environment.NewLine);
            }
        }

        //client wait for server's reply
        public String listen()
        {
            try
            {
                int rc = tcpClient.Receive(receiveBuffer);
                if (rc == 0)
                {
                    tcpClient.Close();
                    return "Error";
                }
                return Encoding.Default.GetString(receiveBuffer) + Environment.NewLine + Environment.NewLine;
            }
            catch (SocketException err)
            {
                return "Error occurred on accepted socket:" + err.Message + Environment.NewLine + Environment.NewLine;
            }
        }
    }
}
