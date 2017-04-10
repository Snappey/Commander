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
        Folder = 2, // Not Implemented
    }

    public class Command
    {
        public CommandType Type;
        public string Name;
        private Func<string, CommandType> Func;
        private List<Command> childNodes = new List<Command>();
        private Command Parent;

        public Command(string name, CommandType type, Command parent, Func<string, CommandType> func)  
        {
            parent?.AddNode(this); // TODO: Check what happens if parent is passed as null from Manager.RegisterCommand, I think it creates a command with no parent..

            Name = name;
            Type = type;
            Parent = parent;
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

        public void AddNode(Command cmd)
        {
            if (!cmd.HasParent())
            {
                this.childNodes.Add(cmd);
            }
            else
            {
                //throw new Exception("Command already has a Parent Node");
            }
        }

        public bool HasParent()
        {
            return (Parent != null);
        }

        public Command GetParent()
        {
            return Parent;
        }

        public bool SetParent(Command cmd)
        {
            Parent?.childNodes.Remove(this);
            Parent = cmd;
            return true;
        }

        public bool HasChildern()
        {
            if (childNodes.Count > 0)
            {
                return true;
            }
            return false;
        }

        public List<Command> GetChildren()
        {
            return childNodes;
        }
    }
}
