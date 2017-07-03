using System;
using Akka.Actor;
using Akka.Routing;
using ExperienceWithAkka.Shared;

namespace ExperienceWithAkka.Service
{
    internal static class Program
    {
        private static void Main()
        {
            Console.WriteLine("Server");
            using (var system = ActorSystem.Create("GreetingSystem"))
            {
                system.WhenTerminated.Wait();
            }
        }
    }
}
