using System;
using System.IO;
using System.Runtime.Serialization.Json;

namespace Backup
{
  internal class Program
  {
    public static void Main(string[] args)
    {
      string settingsPath=null;
      if (args.Length != 0) //if arguments were passed to programm
      {
        if(File.Exists(args[0]))
        settingsPath = args[0];
      }

      if (settingsPath == null)
      {
        Console.WriteLine("Enter path to settings file:");
        settingsPath = Console.ReadLine();
      }

      Settings settings = Settings.Parse(settingsPath);
      if (settings.LoggerPath == null)
      {
        settings.LoggerPath = $"{DateTime.Now.ToString().Replace('.', '_').Replace(':', '_')}.log"; //if logger path is not declared
      }
      Logger logger = new Logger(settings.LoggerPath);
      try
      {
        Backuper backuper = new Backuper(settings.DirsToBackup,settings.BackupDir, logger);
        backuper.Backup();
      }
      catch (Exception e)
      {
        logger.Error(e.Message);
      }


    }
  }
}