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
            var test = manager.Add("test", CommandType.Command, delegate(string s)
            {
                Console.WriteLine("You did this: " + s);
                return CommandType.Command;
            });

            var testing = manager.Add("testing", CommandType.Command, delegate(string s) 
            {
                Console.WriteLine("Wow this is the second layer!");
                return CommandType.Command;
            }, test);

            manager.Add("testing times", CommandType.Command, delegate(string s)
            {
                Console.WriteLine("It happens!");
                return CommandType.Command;
            }, test);

            manager.Add("Further Testing", CommandType.Command, delegate(string s)
            {
                Console.WriteLine("We're in too DEEP!");
                return CommandType.Command;
            }, testing);


            var branch = manager.Add("branch-test", CommandType.Command, delegate(string s)
            {
                Console.WriteLine("Second Branch: " + s);
                return CommandType.Command;
            });

            manager.Add("branch-testing", CommandType.Command, delegate(string s)
            {
                Console.WriteLine("Second level of testing");
                return CommandType.Command;
            }, branch);

           /* manager.Invoke("branch-test", Console.ReadLine());

            manager.Invoke("branch-testing", "lolzor");

            manager.Invoke("back", "up a level");*/

            manager.Invoke("test", "lolzor");
            manager.Invoke("testing", "lolzor");
            manager.List();
            manager.Invoke("Further Testing", "lolozor");
            manager.Invoke("back", "lolzor");

            var res =  manager.Invoke("test", "test");
            Console.WriteLine(res);

            Console.WriteLine(manager.List());
            Console.ReadKey();
        }
    }
}
