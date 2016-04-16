using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlayingVideoCullan
{
    public partial class View : Form
    {
        Controller myController = new Controller();

        public View()
        {
            InitializeComponent();
            connectBtn.Click += myController.Connect_btn_Click;
            setupBtn.Click += myController.Setup_btn_Click;
            playBtn.Click += myController.Play_btn_Click;
            pauseBtn.Click += myController.Pause_btn_Click;
            teardownBtn.Click += myController.Teardown_btn_Click;
            exitBtn.Click += myController.Exit_btn_Click;

            teardownHoverBtn.Click += myController.Teardown_btn_Click;
            playHoverBtn.Click += myController.Play_btn_Click;
            pauseHoverBtn.Click += myController.Pause_btn_Click;
            setupHoverBtn.Click += myController.Setup_btn_Click;
        }

        public String GetPortNumber()
        {
            String port = this.portNum.Text;
            return port;
        }

        //return the server IP
        public IPAddress GetServerIP()
        {
            IPAddress serverIP = IPAddress.Parse(this.serverIP.Text);
            return serverIP;
        }

        //return the video name
        public String GetVideoName()
        {
            String videoName = this.videoName.Text;
            return videoName;
        }

        public void setImageBoxBlack()
        {
           this.imageBox.BackColor = Color.Black;
        }

        public void setImageBox(Image image)
        {
            this.imageBox.Image = image;
        }

        public void Disable_Connect()
        {
            this.connectBtn.Enabled = false;
        }

        public void Enable_Button(String button)
        {
            if (button == "setup")
            {
                this.setupBtn.Enabled = true;
                this.setupHoverBtn.Enabled = true;
            }
            else if (button == "play")
            {
                this.playBtn.Enabled = true;
                this.playHoverBtn.Enabled = true;
            }
            else if (button == "pause")
            {
                this.pauseBtn.Enabled = true;
                this.pauseHoverBtn.Enabled = true;
            }
            else if (button == "teardown")
            {
                this.teardownBtn.Enabled = true;
                this.teardownHoverBtn.Enabled = true;
            }
        }

        public void Disable_Button(String button)
        {
            if (button == "setup")
            {
                this.setupBtn.Enabled = false;
                this.setupHoverBtn.Enabled = false;
            }
            else if (button == "play")
            {
                this.playBtn.Enabled = false;
                this.playHoverBtn.Enabled = false;
            }
            else if (button == "pause")
            {
                this.pauseBtn.Enabled = false;
                this.pauseHoverBtn.Enabled = false;
            }
            else if (button == "teardown")
            {
                this.teardownBtn.Enabled = false;
                this.teardownHoverBtn.Enabled = false;
            }
        }

        //delegate to use function as a parameter
        delegate void SetInfoCallback(String info);

        //append text to the server box
        public void SetServerBox(String _msg)
        {
            String text = _msg;
            SetInfoCallback callback = new SetInfoCallback(add_server_text);
            this.Invoke(callback, new object[] { text });
        }

        public void add_server_text(String _msg)
        {
            this.serverBox.Text += _msg;
        }

        //append text to the client box
        public void SetClientBox(String _msg)
        {
            String text = _msg;
            SetInfoCallback callback = new SetInfoCallback(add_client_text);
            this.Invoke(callback, new object[] { text });
        }

        public void add_client_text(String _msg)
        {
            this.clientBox.Text += _msg;
        }

        //check if Packet Report is checked
        public Boolean PacketReportChecked()
        {
            if (packetReportCheck.CheckState.ToString() == "Checked")
                return true;
            else
                return false;
        }

        //check if Print Header is checked
        public Boolean PrintHeaderChecked()
        {
            if (printHeaderCheck.CheckState.ToString() == "Checked")
                return true;
            else
                return false;
        }

        //show control buttons if entering the imagebox
        public void imageBox_MouseEnter(object sender, EventArgs e)
        {
            this.ShowAllButtons();
        }

        //hide all control buttons when entering the view (ie. leaving imagebox)
        public void View_MouseEnter(object sender, EventArgs e)
        {
            this.HideAllButtons();
        }

        //hide all control buttons
        public void HideAllButtons()
        {
            this.playHoverBtn.Visible = false;
            this.pauseHoverBtn.Visible = false;
            this.setupHoverBtn.Visible = false;
            this.teardownHoverBtn.Visible = false;
        }

        //show all control buttons
        public void ShowAllButtons()
        {
            this.playHoverBtn.Visible = true;
            this.pauseHoverBtn.Visible = true;
            this.setupHoverBtn.Visible = true;
            this.teardownHoverBtn.Visible = true;
            this.playHoverBtn.Parent = imageBox;
            this.pauseHoverBtn.Parent = imageBox;
            this.setupHoverBtn.Parent = imageBox;
            this.teardownHoverBtn.Parent = imageBox;
        }
    }
}
