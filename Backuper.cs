using System;
using System.IO;
using System.IO.Compression;

namespace Backup
{
    public class Backuper
    {
        private string[] backupDirs;
        private string backupDir;
        public Logger ActiveLogger { get; set; }


        /// <summary>
        ///
        /// </summary>
        /// <param name="backupDirs">Directories to be backuped</param>
        /// <param name="backupFile">Directory</param>
        /// <param name="logger">Active logger(if null, StaticLogger will be used)</param>
        public Backuper(string[] backupDirs, string backupDir, Logger logger)
        {
            this.backupDirs = backupDirs;
            this.backupDir = backupDir;
            ActiveLogger = logger;
            if (!Directory.Exists(backupDir))
                Directory.CreateDirectory(backupDir);
        }

        private void Log(string message, string mode)
        {

        }

        /// <summary>
        /// Initializing backup process
        /// </summary>
        public void Backup()
        {

            ActiveLogger.Info("Backup started");
            string date = DateTime.Now.ToString().Replace('.','_').Replace(':','_');

                foreach (string dir in backupDirs)
                {
                    if (!Directory.Exists(dir))
                    {
                        ActiveLogger.Error($"{dir} does not exist");
                        continue;
                    }

                    string zipName = $"{backupDir}\\Backup_{new DirectoryInfo(dir).Name}{date}.zip";
                    if (File.Exists(zipName)) //if zip file already exists, generate new one
                    {
                        for (int i = 2;; i++)
                        {
                            zipName = $"{backupDir}\\Backup_{new DirectoryInfo(dir).Name}{date}_{i}.zip";
                            if (!File.Exists(zipName))
                                break;
                        }

                    }
                    ZipFile.CreateFromDirectory(dir,zipName);
                    ActiveLogger.Debug($"{dir} backuped");
                }

            ActiveLogger.Info($"Backup ended\n");

        }
    }
}