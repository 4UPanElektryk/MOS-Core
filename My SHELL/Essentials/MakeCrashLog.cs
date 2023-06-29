﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using SimpleLogs4Net;
using Newtonsoft.Json;

namespace MyShell.Essentials
{
	public class MakeCrashLog
	{
		public static string Path;
		public MakeCrashLog(string path)
		{
			Path = path;
		}
		public static void WriteLog(string exeption, string sender, string trace,List<string> commands)
		{
            try
            {
                if (File.Exists(Path))
                {
                    File.Delete(Path);
                }
                CrasshLog log = new CrasshLog()
                {
                    UTCDateAndTime = DateTime.UtcNow,
                    Exeption = exeption,
                    Sender = sender,
                    Trace = trace,
                    CommandsLeadingToCrash = commands
                };
                log.Config = new OutputAndInput() { Application = Config._AppConfig, Logs = Config._LogsConfig };

                if (Config._LogsConfig.Enabled)
                {
                    int i = 0;
                    string startpath = Config._LogsConfig.Path + Config._LogsConfig.Prefix;
                    foreach (string item in Directory.GetFiles(Config._LogsConfig.Path))
                    {
                        if (item.StartsWith(startpath))
                        {
                            string fin = item.Substring(Config._LogsConfig.Path.Length + Config._LogsConfig.Prefix.Length);
                            fin = fin.Substring(0,fin.Length-4);
                            int g = int.Parse(fin);
                            if (g > i)
                            {
                                i = g;
                            }
                        }
                    }
                    string latestLogPath = Config._LogsConfig.Path + Config._LogsConfig.Prefix + i + ".log";
                    log.LatestLogPath = latestLogPath;
                    log.LatestLog = File.ReadAllLines(latestLogPath).ToList();
                }
                else
                {
                    log.LatestLog = new List<string>();
                    log.LatestLogPath = "Logs Disabled";
                }
                File.WriteAllText(Path, JsonConvert.SerializeObject(log, Formatting.Indented));
            }
            catch (Exception ex)
            {
                Console.Clear();
                string[] fail =
                {
                    "Somhow wrinting Crash log Failed",
                    ex.Message.Replace("\n"," "),
                    ex.Source
                };
                Dual.ShowMsg(fail,ConsoleColor.White,ConsoleColor.Red);
            }
		}
	}
	public class CrasshLog
	{
		public DateTime UTCDateAndTime { get; set; }
        public OutputAndInput Config { get; set; }
        public string Exeption { get; set; }
		public string Sender { get; set; }
		public string Trace { get ; set; }
		public List<string> CommandsLeadingToCrash { get; set; }
		public string LatestLogPath { get; set; }
		public List<string> LatestLog { get; set; }
	}
}
