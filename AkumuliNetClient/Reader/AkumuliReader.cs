using System;
using System.Collections.Generic;
using System.Text;

namespace AkumuliNetClient
{
    public partial class Akumuli
    {
        public string ServerUrl
        {
            get
            {
                return $"http://{Host}:{PortREST}/";
            }
        }

        public string StatsUrl
        {
            get
            {
                return $"{ServerUrl}api/stats";
            }
        }

        public string QueryUrl
        {
            get
            {
                return $"{ServerUrl}api/query";
            }
        }

        public string SuggestUrl
        {
            get
            {
                return $"{ServerUrl}api/suggest";
            }
        }

        public string SearchUrl
        {
            get
            {
                return $"{ServerUrl}api/search";
            }
        }
    }
}
