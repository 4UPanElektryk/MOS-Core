﻿using MOS_User_Menager_Integration;
using System;
using System.IO;
using Maciek_SHELL.Essentials;
using SimpleLogs4Net;

namespace Maciek_SHELL.Commands.Cmds
{
    class DelDir : Cmd
    {
		public DelDir(string name) : base(name) { }
		public override bool Execute(string[] args, string input, User user)
        {
			bool action = false;
			string path = Dual.TrimStart(input, args[0] + " ");
			Console.Write("Do You want to Delete " + path + " ? Y | N >> ");
			ConsoleKey Key = Console.ReadKey().Key;
			Console.WriteLine();
			if (Key == ConsoleKey.Y)
			{
				if (Directory.Exists(LoggedProgram.DIR + path))
				{
					Directory.Delete(LoggedProgram.DIR + path);
					Log.AddEvent(new Event("User action: Directory Delete - " + LoggedProgram.DIR + path, Event.Type.Informtion, DateTime.Now));
					action = true;
				}
				else
				{
					Log.AddEvent(new Event("User action: Directory Can not be Deleted ,Rason: Directory not Exist - " + LoggedProgram.DIR + path, Event.Type.Informtion, DateTime.Now));
					Dual.Msg("Directory Can not be created, Rason: Directory already Exist", ConsoleColor.Red);
					action = true;
				}
			}
			else
			{
				Console.WriteLine("");
			}
			return action;
		}
    }
}
