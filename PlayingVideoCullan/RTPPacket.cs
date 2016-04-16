using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayingVideoCullan
{
    class RTPPacket
    {
        public RTPPacket() { }

        public byte[] unpacketizeVideoFrame(byte[] packetizedVideoFrame) {

            //empty byte array to store the video packet (without header)
            byte[] unpacketizedVideoFrame = new byte[packetizedVideoFrame.Length - 12];

            //add video frame after the header
            System.Buffer.BlockCopy(packetizedVideoFrame, 12, unpacketizedVideoFrame, 0, unpacketizedVideoFrame.Length);

            return (unpacketizedVideoFrame);
        }
    }
}
