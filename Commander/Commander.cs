using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Commander.Data;

namespace Commander
{
    public class CommandManager
    {
        /// <summary>
        ///  Register a Command to be stored
        /// </summary>
        /// <param name="name"> Name of the command, used to invoke the command </param>
        /// <param name="type"> Type of command it is (Command / Folder) (NOT NEEDED, just use Command) </param>
        /// <param name="func"> The function that should be run when the command is invoked </param>
        /// <param name="parent"> The parent command, used to determine what scope the command can be activated in. e.g. That command has to be invoked before this command can be accessed </param>
        /// <returns> Returns the registered Command </returns>
        public Command Add(string name, CommandType type, Func<string, CommandType> func, Command parent=null)
        {
            return Manager.RegisterCommand(name, type, func, parent);
        }

        /// <summary>
        /// Returns a Command object with the given name (Case Sensitive)
        /// </summary>
        /// <param name="cmd"> The Command to search for </param>
        /// <returns> Returns the given command if it is found, null if no matching command is found </returns>
        public Command Search(string cmd)
        {
            return Manager.GetCommand(cmd);
        }

        /// <summary>
        /// Used to execute a command with the given arguments
        /// </summary>
        /// <param name="cmd"> The name of the command to execute </param>
        /// <param name="args"> The arguments to be passed to the command </param>
        /// <returns> Bool, whether the command was successfully executed </returns>
        public bool Invoke(string cmd, string args="")
        {
            try
            {
                if (cmd == "back") // TODO: Change this so it can be set custom / allow for multiple tree traversal operators
                {
                    Manager.ChangeLevel(Manager.ActiveNode.GetParent());
                }
                else
                {
                    Command tmp = Manager.GetCommand(cmd);
                    tmp.Invoke(args);
                    Manager.ChangeLevel(tmp);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Lists all commads at the current level
        /// </summary>
        /// <returns> String, list of all functions numbered </returns>
        public string List()
        {
            string res = String.Empty;
            int i = 0;
            foreach(Command cmd in Manager.ActiveNode.GetChildren())
            {
                res += ++i + ". " + cmd.Name + "\n";
            }
            return res;
        }

        /// <summary>
        /// Not Implemented
        /// </summary>
        /// <returns></returns>
        public bool Remove()
        {
            return true;
        }
    }
}
