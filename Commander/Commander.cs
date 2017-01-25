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
        public CommandManager()
        {
            
        }

        public bool Add(string name, CommandType type, Func<string, CommandType> func )
        {
            Manager.RegisterCommand(name, type, func);
            return true;
        }

        public Command Search(string cmd)
        {
            return Manager.GetCommand(cmd);
        }

        public bool Invoke(string cmd, string args)
        {
            try
            {
                Manager.GetCommand(cmd).Invoke(args);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public string List()
        {
            string res = String.Empty;
            int i = 0;
            foreach(KeyValuePair<string, Command> cmd in Manager.Commands)
            {
                res += ++i + ". " + cmd.Key + "\n";
            }
            return res;
        }

        public bool Remove()
        {
            return true;
        }
    }
}
