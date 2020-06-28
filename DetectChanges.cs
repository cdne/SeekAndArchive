using System;
using System.IO;

namespace SeekAndArchive
{
    internal class DetectChanges
    {
        public string FilePath { get; set; }

        public void MonitorChanges(string path)
        {
            FilePath = path;

            FileSystemWatcher fileSystemWatcher = new FileSystemWatcher();
            fileSystemWatcher.Path = path;
            fileSystemWatcher.Created += FileSystemWatcher_Created;
            fileSystemWatcher.Renamed += FileSystemWatcher_Renamed;
            fileSystemWatcher.Deleted += FileSystemWatcher_Deleted;
            fileSystemWatcher.Changed += FileSystemWatcher_FileContentChanged;
            fileSystemWatcher.EnableRaisingEvents = true;

        }

        private static void FileSystemWatcher_Created(object sender, FileSystemEventArgs args)
        {
            Console.WriteLine("File created: {0}", args.Name);
        }

        private static void FileSystemWatcher_Renamed(object sender, FileSystemEventArgs args)
        {
            Console.WriteLine("File renamed: {0} in path {1}", args.Name, args.FullPath);
        }

        private static void FileSystemWatcher_Deleted(object sender, FileSystemEventArgs args)
        {
            Console.WriteLine("File deleted: {0} in path {1}", args.Name, args.FullPath);

        }

        private static void FileSystemWatcher_FileContentChanged(object sender, FileSystemEventArgs args)
        {
            Console.WriteLine("File changed: {0} in path {1}", args.Name, args.FullPath);

        }
    }
}