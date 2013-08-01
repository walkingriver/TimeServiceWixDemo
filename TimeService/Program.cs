using System;
using System.ServiceProcess;
using log4net;

namespace TimeService
{
    static class Program
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(Program));

        static  Program()
        {
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Logger.Error(e.ExceptionObject);
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            if (Environment.UserInteractive)
            {
                using (var adapter = new TimeServiceAdapter())
                {
                    Logger.Debug("Application starting interactively.");
                    adapter.Start();
                    Console.WriteLine("Service is running. Press ENTER to Exit.");
                    Console.ReadLine();
                    adapter.Stop();
                }
            }
            else
            {
                Logger.Debug("Application starting as a Windows service.");
                var servicesToRun = new ServiceBase[]
                {
                    new TimeService()
                };
                ServiceBase.Run(servicesToRun);
            }

            Logger.Debug("Application shutting down.");
        }
    }
}
