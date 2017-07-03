using System;
using Akka.Actor;
using ExperienceWithAkka.Shared;

namespace ExperienceWithAkka.Client
{
    internal static class Program
    {
        private static void Main()
        {
            Console.WriteLine("Client");
            using (var system = ActorSystem.Create("GreetingSystem"))
            {
                var actor = system.ActorOf(Props.Create<GreetingActor>(), "Greeting");
                Console.WriteLine(actor);

                //send a message to the remote actor
                while (true)
                {
                    //get a reference to the remote actor
                    var greeter = system.ActorSelection("/user/Greeting");
                    Console.WriteLine("Who?");
                    var message = new Greet(Console.ReadLine());
                    greeter.Tell(message);
                }
            }
        }
    }
}
