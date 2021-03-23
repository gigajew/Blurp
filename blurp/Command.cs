using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace blurp
{
    class Command
    {
        public OpCode Code;
        public object[] Parameters;

        public static Command Parse(string line )
        {
            Command command = new Command();
            string[] fragments = line.Split(' ');
            string opcode = fragments[0];
            if(opcode == "execute")
            {
                command.Code = OpCode.EXECUTE_FILE;

            } else if (opcode == "sleep")
            {
                command.Code = OpCode.SLEEP;
            }
            string[] parameters = fragments.Skip(1).ToArray();
            List<object> parsed_parameters = new List<object>();
            foreach(string parameter in parameters )
            {
                if(int.TryParse(parameter, out int result))
                {
                    parsed_parameters.Add(result);
                } else
                {
                    parsed_parameters.Add(parameter);
                }
            }
            command.Parameters = parsed_parameters.ToArray();
            return command;
        }
    }
}
