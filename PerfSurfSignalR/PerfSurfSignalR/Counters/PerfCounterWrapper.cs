using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace PerfSurfSignalR.Counters
{
    public class PerfCounterWrapper
    {
        public PerfCounterWrapper(string name, string category, string counter, string instance = "")
        {
            _counter = new PerformanceCounter(category, counter, instance, readOnly: true);
            Name = name;
        }

        public float Value
        {
            get { return _counter.NextValue(); }
        }

        public string Name { get; set; }

        PerformanceCounter _counter;
    }
}