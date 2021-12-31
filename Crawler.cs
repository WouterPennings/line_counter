using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace line_counter
{
    public class Crawler
    {
        public void CrawlDirectory(string startDirectory, out List<string> files, out List<string> folders)
        {
            List<string> newFolders = new();
            List<string> newFiles = new();
            newFolders.Add(startDirectory);
            try
            {
                newFiles.AddRange(Directory.GetFiles(startDirectory).ToList());
                foreach (string sub in Directory.GetDirectories(startDirectory))
                {
                    newFolders.Add(sub);
                    newFolders.AddRange(GetSubDirectoriesContent(sub, out List<string> newFiles2));
                    newFiles.AddRange(newFiles2);
                }
            }
            catch { }
            
            files = newFiles;
            folders = newFolders;
        }
        
        private List<string> GetSubDirectoriesContent(string dir, out List<string> files)
        {
            List<string> folders = new();
            List<string> newFiles = new();
            newFiles.AddRange(Directory.GetFiles(dir).ToList());
            try
            {
                string[] subDirs = Directory.GetDirectories(dir);
                foreach (string sub in subDirs)
                {
                    folders.Add(sub);
                    folders.AddRange(GetSubDirectoriesContent(sub, out List<string> newFiles2));
                    newFiles.AddRange(newFiles2);
                }
            }
            catch { }

            files = newFiles;
            return folders;
        }
    }
}