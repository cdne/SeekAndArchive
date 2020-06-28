using System;
using System.Collections.Generic;
using System.IO;

namespace SeekAndArchive
{
    internal class Program
    {
        private static List<DetectChanges> detectChangesList = new List<DetectChanges>();
        

        private static void Main(string[] args)
        {
            FindFile fileFinder = new FindFile();

            Console.WriteLine("------------------- Searching for file {0} -------------------", args[1]);
            Console.WriteLine("Please wait...");
            fileFinder.SearchDirectory(args[0], args[1]);

            fileFinder.GetFilePath();

            for (int i = 0; i < fileFinder.GetFileFullPath().Count; i++)
            {
                detectChangesList.Add(new DetectChanges());
            }

            List<string> filePaths = fileFinder.GetFileFullPath();

            for (int i = 0; i < fileFinder.GetFileFullPath().Count; i++)
            {
                detectChangesList[i].MonitorChanges(filePaths[i]);
            }

          
            Console.ReadLine();

        }
    }
}