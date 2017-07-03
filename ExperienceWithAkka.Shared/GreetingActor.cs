using System;
using System.Threading;
using Akka.Actor;

namespace ExperienceWithAkka.Shared
{
    public class GreetingActor : ReceiveActor
    {
        public GreetingActor()
        {
            Console.WriteLine("GreetingActor");
            Receive<Greet>(
                greet =>
                {
                    for (var i = 0; i < 10; i++)
                    {
                        Console.WriteLine("Hello {0}", greet.Who);
                        Thread.Sleep(1000);
                    }
                }
            );
        }
    }
}
