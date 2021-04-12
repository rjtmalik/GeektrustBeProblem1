using Problem1.Process.Contracts;
using Problem1.Model;
using Problem1Process;
using SimpleInjector;
using System;
using System.Collections.Generic;

namespace Set5Problem1ConsoleApp
{
    class Program
    {
        static readonly Container container;

        static Program()
        {
            container = new Container();

            container.Register<IAlliesProcess, AlliesProcess>();

            container.Verify();
        }

        static void Main(string[] args)
        {
            //Console.WriteLine("who is the ruler of Southeros?");
            bool acceptInput = true;
            List<AllianceRequest> requests = new List<AllianceRequest>();
            while (acceptInput)
            {
                Console.WriteLine("Do you want to enter a secret message?(Y/N)");
                var key = Console.ReadKey();
                if (key.KeyChar == 'y' || key.KeyChar == 'Y')
                {
                    Console.WriteLine();
                    Console.WriteLine("Please Enter Here (Country, Message) : ");
                    var KeyAndMessage = Console.ReadLine();
                    var msg = KeyAndMessage.Split(new char[] { ',' });
                    requests.Add(new AllianceRequest() { Country = msg[0], SecretMessage = msg[1] });
                }
                else
                {
                    acceptInput = false;
                }
            }
            var alliesProcess = container.GetInstance<IAlliesProcess>();
            var result = alliesProcess.EvaluateAlliance(requests, "space");

            Console.WriteLine();
            Console.WriteLine("Who is the ruler of Southeros?");
            Console.WriteLine(result.RulerName);

            Console.WriteLine("Allies of Ruler?");
            Console.WriteLine(result.UIFriendlyListOfAllies);
            Console.ReadLine();

        }
    }
}
