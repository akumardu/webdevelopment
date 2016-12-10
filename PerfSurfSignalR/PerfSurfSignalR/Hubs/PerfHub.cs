using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;
using PerfSurfSignalR.Counters;

namespace PerfSurfSignalR.Hubs
{
    public class PerfHub : Hub
    {
        public PerfHub()
        {
            StartCountersCollection();
        }

        private void StartCountersCollection()
        {
            var task = Task.Factory.StartNew(async () =>
            {
                var perfService = new PerfCounterService();
                while(true)
                {
                    var results = perfService.GetResults();
                    Clients.All.newCounters(results);
                    await Task.Delay(2000);
                }
            }, TaskCreationOptions.LongRunning);
        }

        public void Send(string message)
        {
            Clients.All.newMessage(
                Context.User.Identity.Name + " says : " + message);
        }
    }
}