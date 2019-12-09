using System;
using System.Collections.Generic;
using System.Text;

namespace AkumuliNetClient
{
    public class AkumuliEntry
    {
        public string Metric { get; set; }
        public Dictionary<string, string> Tags { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
        public double Value { get; set; }

        public AkumuliEntry()
        { }

        public AkumuliEntry(string metric, Dictionary<string, string> tags, DateTime timestamp, double value)
        {
            Metric = metric;
            Tags = tags;
            Timestamp = timestamp;
            Value = value;
        }

        public AkumuliEntry(string metric, Dictionary<string, string> tags, double value)
        {
            Metric = metric;
            Tags = tags;
            Timestamp = DateTime.UtcNow;
            Value = value;
        }
    }
}
