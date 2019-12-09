using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace AkumuliNetClient
{
    public partial class Akumuli
    {
        TcpClient client;

        bool IsConnectedTCP()
        {
            return client.Connected;
        }

        void ConnectTCP()
        {
            try
            {
                // Create a TcpClient.
                // Note, for this client to work you need to have a TcpServer 
                // connected to the same address as specified by the server, port
                // combination.
                client = new TcpClient(Host, PortTCP);

            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("ArgumentNullException: {0}", e);
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }

        }

        void DisconnectTCP()
        {
            try
            {
                client.Close();

            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }

        }

        public bool WriteData(AkumuliEntry entry)
        {
            if (IsConnectedTCP())
            {
                var stream = client.GetStream();
                Byte[] data = System.Text.Encoding.ASCII.GetBytes(AkumuliFormat(entry));
                stream.Write(data, 0, data.Length);
                Console.WriteLine("Sent: {0}", AkumuliFormat(entry));
                data = new Byte[256];
                String responseData = String.Empty;
                Int32 bytes = stream.Read(data, 0, data.Length);
                responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
                Console.WriteLine("Received: {0}", responseData);
                stream.Close();
            }
            return true;
        }

        private string AkumuliFormat(AkumuliEntry entry)
        {
            var s = "";
            s = to_resp_string(entry.Metric) + " ";
            s = s + to_series_string(entry.Tags) + Environment.NewLine;
            s = s + to_resp_timestamp(entry.Timestamp) + Environment.NewLine;
            s = s + to_resp_string(entry.Value) + Environment.NewLine;
            return s;
        }

        private string to_resp_timestamp(DateTime timestamp)
        {
            return $":%d{timestamp.Ticks}";
        }

        private string to_series_string(Dictionary<string, string> tags)
        {
            var s = "";
            var first = true;
            foreach(var t in tags)
            {
                if (!first)
                {
                    s = s + " ";
                }
                else
                {
                    s = s + t.Key + "=" + t.Value;
                }
            }

            throw new NotImplementedException();
        }

        private string to_resp_string(object value)
        {
            var t = value.GetType();

            if (t == typeof(double) || t == typeof(float))
            {
                return $"+%.20g{value}";
            }
            else if (t == typeof(int))
            {
                return $":%d{value}";
            }
            else if (t == typeof(string))
            {
                return $"+{value}";
            }
            throw new Exception("Value cannot be converted.");
        }

    }
}
