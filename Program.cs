using System;

namespace SeekAndArchive
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            FindFile fileFinder = new FindFile();
            fileFinder.SearchDirectory(args[0], args[1]);
            foreach (var item in fileFinder.GetPathList())
            {
                Console.WriteLine(item);
            }
        }
    }
}