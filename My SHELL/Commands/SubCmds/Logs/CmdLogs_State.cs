﻿using MyShell.Essentials;
using MyShell.Integrations.User_Manager;
using SimpleLogs4Net;
using System;

namespace MyShell.Commands.SubCmds.Logs
{
    class CmdLogs_State : SubCmd
    {
        public CmdLogs_State(string name) : base(name)
        {

        }
        public override bool Execute(string[] args, string input, User user)
        {
            if (args.Length >= 1)
            {
                if (bool.TryParse(args[0], out bool result))
                {
                    Essentials.Config._LogsConfig.Enabled = result;
                    Essentials.Config.Save();
                    Essentials.Config.Load();
                    Log.ChangeEnable(Essentials.Config._LogsConfig.Enabled);
                    if (Essentials.Config._LogsConfig.Enabled)
                    {
                        Dual.Msg("Logs are now enabled", ConsoleColor.Yellow);
                    }
                    else
                    {
                        Dual.Msg("Logs are now disabled", ConsoleColor.Yellow);
                    }
                }
            }
            else
            {
                if (user._State == User.Type.SysAdmin)
                {
                    Log.ChangeEnable(Essentials.Config._LogsConfig.Enabled);
                    if (Essentials.Config._LogsConfig.Enabled)
                    {
                        Dual.Msg("Logs are enabled", ConsoleColor.Yellow);
                    }
                    else
                    {
                        Dual.Msg("Logs are disabled", ConsoleColor.Yellow);
                    }
                }
                else
                {
                    Dual.Msg("Not enough previlage level you need SysAdmin account", ConsoleColor.Red);
                }
            }
            return true;
        }
    }
}
