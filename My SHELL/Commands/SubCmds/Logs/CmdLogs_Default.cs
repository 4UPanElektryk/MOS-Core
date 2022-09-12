﻿using MyShell.Essentials;
using MyShell.Integrations.User_Manager;
using System;
using System.IO;

namespace MyShell.Commands.SubCmds.Logs
{
    class CmdLogs_Default : SubCmd
    {
        public CmdLogs_Default(string name) : base(name)
        {
            _IsDefault = true;
        }
        public override bool Execute(string[] args, string input, User user)
        {
            if (args.Length == 1)
            {
                foreach (string item in Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory + Essentials.Config._LogsConfig.Path))
                {
                    if (item.EndsWith(".log"))
                    {
                        Console.WriteLine(item);
                    }
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Sub Command \"" + args[1] + "\" was Not Found for");
                Console.WriteLine("Command \"" + args[0] + "\"");
                Console.WriteLine("Or is not accesible for that privilage level");
                Console.ResetColor();
            }
            return true;
        }
    }
}
