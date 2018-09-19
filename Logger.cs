using System;
using System.IO;

namespace Backup
{
    public class Logger
    {
        private string logFilePath;

        /// <summary>
        /// Logger file
        /// </summary>
        /// <param name="loggerPath">Path to log file</param>
        public Logger(string loggerPath)
        {
            logFilePath = loggerPath;
            if (!File.Exists(logFilePath))
                File.Create(logFilePath);

            Info("New session");
        }


        /// <summary>
        /// Logs message with "Error" mark
        /// </summary>
        /// <param name="message">Message to log</param>
        public void Error(string message)
        {
            using (StreamWriter streamWriter = new StreamWriter(logFilePath,true))
            {
             streamWriter.WriteLine($"{DateTime.Now} Error: {message}");
            }
        }
        /// <summary>
        /// Logs message with "Debug" mark
        /// </summary>
        /// <param name="message">Message to log</param>
        public void Debug(string message)
        {
            using (StreamWriter streamWriter = new StreamWriter(logFilePath,true))
            {
                streamWriter.WriteLine($"{DateTime.Now} Debug: {message}");
            }
        }
        /// <summary>
        /// Logs message with "Info" mark
        /// </summary>
        /// <param name="message">Message to log</param>
        public void Info(string message)
        {
            using (StreamWriter streamWriter = new StreamWriter(logFilePath,true))
            {
                streamWriter.WriteLine($"{DateTime.Now} Info: {message}");
            }
        }


    }
}