using System;
using System.Linq;
using Nancy;
using Nancy.Hosting.Self;
using Nancy.Configuration;
using System.Collections.Generic;
using Newtonsoft.Json;


namespace Nancy_REST
{
    class Program
    {
        static void Main(string[] args)
        {
            var hostConfigs = new HostConfiguration
            {
                UrlReservations = new UrlReservations() { CreateAutomatically = true }
            };

            Uri uri = new Uri("http://localhost:1234");

            using (var host = new NancyHost(hostConfigs, uri))
            {
                host.Start();
                Console.WriteLine("Listening to requests on localhost:1234");
                Console.ReadLine();
            }
        }
    }
}
