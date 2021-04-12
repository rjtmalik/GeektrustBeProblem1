using Problem1.Process;
using SimpleInjector;
using System;
using System.Collections.Generic;

namespace Set5Problem1ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            bool acceptInput = true;
            var requests = new List<string>();
            while (acceptInput)
            {
                Console.WriteLine("Do you want to enter a secret message?(Y/N)");
                var key = Console.ReadKey();
                if (key.KeyChar == 'y' || key.KeyChar == 'Y')
                {
                    Console.WriteLine();
                    Console.WriteLine("Please Enter Here (Country, Message) : ");
                    var KeyAndMessage = Console.ReadLine();
                    requests.Add(KeyAndMessage);
                }
                else
                {
                    acceptInput = false;
                }
            }

            var result = SoutherosUniverse.Instance.Invasion("space", requests.ToArray());

            if (result.Length == 0)
                Console.WriteLine("NONE");
            else
            {
                var consoleOutput = "SPACE";
                foreach (var item in result)
                {
                    consoleOutput += $" {item}";
                }
                Console.WriteLine(consoleOutput);
            }
            Console.ReadLine();
        }
    }
}
