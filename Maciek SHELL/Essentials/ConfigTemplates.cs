﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maciek_SHELL.Essentials
{
    public class AppConfig
    {
        public bool AutoUpdate { get; set; }
        public string License { get; set; }
        public bool? DevMode { get; set; }
        public void Reset()
        {
            AutoUpdate = false;
            License = "null";
        }
        public AppConfig()
        {
            
        }
    }
    public class UserConfig
    {
        public string File { get; set; }
        public string FileBackup { get; set; }
        public void Reset()
        {
            File = "Users.dat";
            FileBackup = "Backup_Users.dat";
        }
        public UserConfig()
        {
            
        }
    }
    public class LogsConfig
    {
        public string Prefix { get; set; }
        public string Path { get; set; }
        public bool Enabled { get; set; }
        public void Reset()
        {
            Prefix = "LOG";
            Path = "Logs\\";
            Enabled = true;
        }
        public LogsConfig()
        {

        }
    }
}
