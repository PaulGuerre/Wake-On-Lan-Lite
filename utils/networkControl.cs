using System.Globalization;
using System.Net;
using System.Net.Sockets;
using System.Text.RegularExpressions;

namespace Wake_On_Lan_Lite
{
    //Class that sends the magic packet 
    class networkControl
    {
        
        //Function that sends the magic packet according to the mac address parameter
        public void wakeUp(string MAC_ADDRESS)
        {
            //Regex for a real mac address
            MAC_ADDRESS = Regex.Replace(MAC_ADDRESS, "[-|:]", "");

            //Creation of the socket
            var sock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp)
            {
                EnableBroadcast = true
            };

            int payloadIndex = 0;

            byte[] payload = new byte[1024];

            for (int i = 0; i < 6; i++)
            {
                payload[payloadIndex] = 255;
                payloadIndex++;
            }

            for (int j = 0; j < 16; j++)
            {
                for (int k = 0; k < MAC_ADDRESS.Length; k += 2)
                {
                    var s = MAC_ADDRESS.Substring(k, 2);
                    payload[payloadIndex] = byte.Parse(s, NumberStyles.HexNumber);
                    payloadIndex++;
                }
            }

            //Sending the magic packet
            sock.SendTo(payload, new IPEndPoint(IPAddress.Parse("255.255.255.255"), 0));
            sock.Close(10000);
        }
    }
}
