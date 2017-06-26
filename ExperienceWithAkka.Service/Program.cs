using System;
using Akka.Actor;
using Akka.Configuration;

namespace ExperienceWithAkka.Service
{
    internal static class Program
    {
        private static void Main()
        {

            var config = ConfigurationFactory.ParseString(@"
                akka {
                    actor {
                        provider = ""Akka.Remote.RemoteActorRefProvider, Akka.Remote""
                    }

                    remote {
                        helios.tcp {
                            port = 8080
                            hostname = localhost
                        }
                    }
                }
            ");

            using (var system = ActorSystem.Create("MyServer", config))
            {
                system.ActorOf<GreetingActor>("greeter");
                Console.ReadKey();
            }
        }
    }
}
