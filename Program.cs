using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using line_counter;

long CountLinesLINQ(string filename)  
    => File.ReadLines(filename).Count();

List<string> allowedExtentions = new() { ".rs" };
List<string> trackedFiles = new();
string path = Directory.GetCurrentDirectory();
Crawler crawler = new();

Console.WriteLine("\n\nTracking file with extension: ");
foreach (string extension in allowedExtentions)
{
    Console.WriteLine(" > " + extension);
}
Thread.Sleep(500);
Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine("This may take a while, greatly depends on the directory that was chosen.");

Console.ForegroundColor = ConsoleColor.White;
Console.WriteLine("\nFiles found with the correct extension: ");
crawler.CrawlDirectory(path, out List<string> files, out List<string> _);
foreach (string file in files)
{
    if (allowedExtentions.Contains(Path.GetExtension(file)))
    {
        Console.WriteLine(" > " + file);
        trackedFiles.Add(file);
    }
}

Console.WriteLine("\nDone crawling! Got all files with a extension in the list.");
Thread.Sleep(500);
Console.WriteLine("Starting to count all lines of text in those files.");
long totalLines = 0;
foreach (string file in trackedFiles)
{
    totalLines += CountLinesLINQ(file);
}

Console.ForegroundColor = ConsoleColor.Blue;
Console.WriteLine("Total amount of lines: " + totalLines, Console.ForegroundColor);
Thread.Sleep(500);
Console.ForegroundColor = ConsoleColor.White;
Console.WriteLine("\nPress any key to exit...\n");
Console.ReadKey();