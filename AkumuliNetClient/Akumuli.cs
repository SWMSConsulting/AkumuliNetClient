using System;

namespace AkumuliNetClient
{
    public partial class Akumuli
    {
        public string Host { get; set; }
        public int PortREST { get; set; } = 0;
        public int PortUDP { get; set; } = 0;
        public int PortTCP { get; set; } = 0;


        public Akumuli(string host, int portRest, int portUDP, int portTCP)
        {
            Host = host;
            PortREST = portRest;
            PortUDP = portUDP;
            PortTCP = portTCP;
        }

    }
}
