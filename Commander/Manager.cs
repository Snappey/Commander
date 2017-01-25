using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Commander.Data;

namespace Commander
{
    internal static class Manager
    {
        public static Dictionary<string, Command> Commands = new Dictionary<string, Command>();


        public static void RegisterCommand(string name, CommandType type, Func<string, CommandType> func)
        {
            Commands.Add(name, new Command(name, type, func));
        }

        public static bool RemoveCommand(string name)
        {
            if(HasCommmand(name))
            {
                Commands.Remove(name);
            }
            return true;
        }

        public static bool HasCommmand(string name)
        {
            if (Commands.ContainsKey(name))
            {
                return true;
            }
            return false;
        }

        public static Command GetCommand(string name)
        {
            if (HasCommmand(name))
            {
                return Commands[name];
            }
            return null;
        }
    }
}
