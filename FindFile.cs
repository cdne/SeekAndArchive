using System;
using System.Collections.Generic;
using System.IO;

namespace SeekAndArchive
{
    internal class FindFile
    {
        private readonly List<string> pathList;

        public FindFile()
        {
            pathList = new List<string>();
        }

        /// <summary>
        /// Add to list file paths which contains the provided file
        /// </summary>
        /// <param name="directory"> iterated directory</param>
        /// <param name="file"></param>
        public void SearchFilesInDirectory(string directory, string file)
        {
            try
            {
                foreach (var fileInDirectory in Directory.GetFiles(directory))
                {
                    if (fileInDirectory.Contains(file))
                    {
                        pathList.Add(fileInDirectory);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error when searching for file: " + ex.Message);
            }
        }

        /// <summary>
        /// Search computer directories
        /// </summary>
        /// <param name="directory"></param>
        /// <param name="file"></param>
        public void SearchDirectory(string directory, string file)
        {
            try
            {
                foreach (var dir in Directory.GetDirectories(directory))
                {
                    SearchFilesInDirectory(dir, file);
                    SearchDirectory(dir, file);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error when searching for directory: " + ex.Message);
            }
        }

        /// <summary>
        /// Return list with file paths
        /// </summary>
        /// <returns></returns>
        public List<string> GetPathList()
        {
            return pathList;
        }
    }
}