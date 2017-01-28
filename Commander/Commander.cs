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
            Manager.HasCommmand("test");
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
                Command tmp = Manager.GetCommand(cmd);
                tmp.Invoke(args);
                Manager.ChangeLevel(tmp);
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
            foreach(Command cmd in Manager.ActiveNode.GetChildren())
            {
                res += ++i + ". " + cmd.Name + "\n";
            }
            return res;
        }

        public bool Remove()
        {
            return true;
        }
    }
}
