using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commander.Data
{
    [Flags]
    public enum CommandType
    {
        Command = 1,
        Folder = 2, // Not Implemented yet
    }

    public class Command
    {
        public CommandType Type;
        private string Name;
        private Func<string, CommandType> Func;

        public Command(string name, CommandType type, Func<string, CommandType> func)  
        {
            Name = name;
            Type = type;
            Func = func;
        }

        public CommandType Invoke(string args)
        {
            if (Type == CommandType.Command)
            {
                Func.Invoke(args);
            }           
            return Type;
        }
    }
}
