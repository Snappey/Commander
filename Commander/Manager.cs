using System;
using System.Collections.Generic;
using Commander.Data;

namespace Commander
{
    internal static class Manager
    {
        public static Command RootCommand;
        public static Command ActiveNode;

        static Manager()
        {
            RootCommand = new Command("root", CommandType.Command, null, delegate (string s) { return CommandType.Command; });
            RootCommand.SetParent(RootCommand);
            //RootCommand.GetChildren().Add(RootCommand); // We want a circular parent at the top of the tree
            ChangeLevel(RootCommand);
        }


        public static Command RegisterCommand(string name, CommandType type, Func<string, CommandType> func, Command parent=null)
        {
            if (parent == null)
            {
                parent = RootCommand;
            }
            Command tmp = new Command(name, type, parent, func);
            parent.AddNode(tmp);
            return tmp;
        }

        /*public static bool RemoveCommand(string name)
        {
            if(HasCommmand(name))
            {
                Commands.Remove(name);
            }
            return true;
        }*/

        private static KeyValuePair<bool, Command> FindCommand(string cmd, Command node)
        {
            foreach (Command command in node.GetChildren())
            {
                if (command.Name == cmd)
                {
                    return new KeyValuePair<bool, Command>(true, command);
                }
            }
            return new KeyValuePair<bool, Command>(false, null);
        }

        public static bool HasCommmand(string name)
        {
            return FindCommand(name, ActiveNode).Key;
        }

        public static Command GetCommand(string name)
        {
            return FindCommand(name, ActiveNode).Value;
        }

        public static void ChangeLevel(Command cmd)
        {
            if (cmd.HasChildern())
            {
                ActiveNode = cmd;
            }
            else
            {
                ActiveNode = cmd.GetParent();
            }
        }
    }
}
