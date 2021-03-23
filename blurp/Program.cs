using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace blurp
{
    class Program
    {
        static void Main(string[] args)
        {
            Log("Blurp simple scripting engine by gigajew");
            Log("Available commands: ");
            Log("execute <path>");
            Log("sleep <int>");
            Log(string.Format( "Running script {0}", args[0]));
            StreamReader reader = new StreamReader(args[0]);
            while (reader.Peek() >= 0 )
            {
                string line = reader.ReadLine();
                if (string.IsNullOrEmpty(line)) continue;

                Command command = Command.Parse(line);
                if (command.Code == OpCode.EXECUTE_FILE)
                {
                    string path = command.Parameters.First() as string;
                    Log(string.Format("Executing app at {0}", path));
                    Process.Start(path);
                }
                else if (command.Code == OpCode.SLEEP) {
                    int time = (int)command.Parameters.First();
                    Log(string.Format("Sleeping for {0} milliseconds", time));
                    Thread.Sleep(time);
                }
            }
        }

        static void Log(string value )
        {
            Console.WriteLine("[Log] {0}", value);
        }
    }
}
