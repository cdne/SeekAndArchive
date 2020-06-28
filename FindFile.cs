using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SeekAndArchive
{
    internal class FindFile
    {
        private  List<string> pathList;
        private static int fileLenght;

        public FindFile()
        {
            pathList = new List<string>();
        }


        /// <summary>
        /// Search computer directories
        /// </summary>
        /// <param name="directory"></param>
        /// <param name="file"></param>
        public void SearchDirectory(string directory, string file)
        {
            fileLenght = file.Length;
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
            }
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
            }
        }

        /// <summary>
        /// Return list with file paths
        /// </summary>
        /// <returns></returns>
        public List<string> GetFileFullPath()
        {
            return pathList;
        }

        public void GetFilePath()
        {
            List<string> tempList = new List<string>();

            for (int i = 0; i < pathList.Count; i++)
            {
                string modifyPath = pathList[i].Substring(0, pathList[i].Length - fileLenght);
                Console.WriteLine(modifyPath);
                tempList.Add(modifyPath);
            }

            pathList = tempList;
        }
    }
}