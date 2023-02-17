using System;
using Akka.Actor;
namespace ActorPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Creacióon del sistema de nuevo actor
            using (var system = ActorSystem.Create("HelloWorldSystem"))
            {
                // se crea un nuevo actor
                var actor = system.ActorOf<HelloWorldActor>("HelloWorldActor");

                // Se envía el mensaje al actor y se espera por una respuesta
                Console.WriteLine("¿Cuál es tu nombre?");
                var result = actor.Ask<string>(Console.ReadLine()).Result;

                // Respuesta
                Console.WriteLine(result);
                Console.ReadKey();
            }
        }
    }

    class HelloWorldActor : ReceiveActor
    {
        public HelloWorldActor()
        {
            //Manejador de mensajes
            Receive<string>(name =>
            {
                //Se envía la respuesta.
                Sender.Tell($"Hola, {name}!");
            });
        }
    }

}