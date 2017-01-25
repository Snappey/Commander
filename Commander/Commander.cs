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

        public bool Remove()
        {
            return true;
        }
    }
}
