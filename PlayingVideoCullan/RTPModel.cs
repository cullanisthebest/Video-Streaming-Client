using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace PlayingVideoCullan
{
    class RTPModel
    {
        UdpClient UDPSocket = new UdpClient(11000); //UDP socket to receive video packets from server
        IPEndPoint serverEndPoint;
        RTPPacket _RTPpacket;

        public RTPModel(IPAddress IP, String port)
        {
            //create client end point
            this.serverEndPoint = new IPEndPoint(IP, Int32.Parse(port));
            //use to packetize the packet
            this._RTPpacket = new RTPPacket();
        }

        //convert the video frame into an image
        public Image getImage(ref byte[] videoFrame)
        {
            try
            {
                //get video frame from server (has header)
                byte[] packetizedVideoFrame = UDPSocket.Receive(ref serverEndPoint);

                //make sure video frame received is not empty (ie. end of file)
                if (packetizedVideoFrame.Length > 0)
                {
                    videoFrame = packetizedVideoFrame;

                    //unpacketize (remove header) from the video packet
                    byte[] unpacketizedVideoFrame = _RTPpacket.unpacketizeVideoFrame(packetizedVideoFrame);

                    //convert the video frame into an image
                    Image image = Image.FromStream(new MemoryStream(unpacketizedVideoFrame));

                    return image;
                }
                else
                    return null;
            }
            catch (SocketException err)
            {
                Console.WriteLine("Receive failed: ", err.Message);
                return null;
            }
        }
    }
}
