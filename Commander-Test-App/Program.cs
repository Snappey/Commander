using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Commander;
using Commander.Data;

namespace Commander_Test_App
{
    class Program
    {
        private static CommandManager manager;

        static void Main(string[] args)
        {
            manager = new CommandManager();
            manager.Add("test", CommandType.Command, delegate(string s)
            {
                Console.WriteLine("You did this: " + s);
                return CommandType.Command;
            });

            manager.Invoke("test", Console.ReadLine());

            Console.ReadKey();
        }
    }
}
