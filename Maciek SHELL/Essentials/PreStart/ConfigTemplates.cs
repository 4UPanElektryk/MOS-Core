﻿namespace MShell.Essentials
{
    public class AppConfig
    {
        public bool AutoUpdate { get; set; }
        public bool UpdateToBeta { get; set; }
        public bool DevMode { get; set; }
        public string BindFile { get; set; }
        public void Reset()
        {
            AutoUpdate = true;
            UpdateToBeta = false;
            DevMode = false;
            BindFile = "binds.json";
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
