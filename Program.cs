using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using line_counter;

long CountLinesLINQ(string filename)  
    => File.ReadLines(filename).Count();

List<string> allowedExtensions = args.ToList().Any() ? args.ToList() : new();
List<string> trackedFiles = new();
string path = Directory.GetCurrentDirectory();
Crawler crawler = new();


if (allowedExtensions.Count > 0)
{
    Console.WriteLine("\nTracking file with extension: ");
    foreach (string extension in allowedExtensions)
    {
        Console.WriteLine(" > " + extension);
    }
}
else
{
    Console.WriteLine("\n\nTracking all files.");
}
Thread.Sleep(500);
Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine("This may take a while, greatly depends on the directory that was chosen.");

Console.ForegroundColor = ConsoleColor.White;
crawler.CrawlDirectory(path, out List<string> files, out List<string> _);
if (allowedExtensions.Count > 0)
{
    Console.WriteLine("\nFiles found with the correct extension: ");
    foreach (string file in files)
    {
        if (allowedExtensions.Contains(Path.GetExtension(file)))
        {
            Console.WriteLine(" > " + file);
            trackedFiles.Add(file);
        }
    } 
}
else
{
    Console.WriteLine("\nGot all files in sight!");
    trackedFiles = files;
}

Console.WriteLine("\nDone crawling! Got all files with a extension in the list.");
Thread.Sleep(500);
Console.WriteLine("Starting to count all lines of text in those files...");
long totalLines = 0;
List<string> errors = new List<string>();
var current = "";
try
{
    foreach (var file in trackedFiles)
    {
        current = file;
        totalLines += CountLinesLINQ(file);
    }
}
catch
{
    
    errors.Add(current);
}
Console.ForegroundColor = ConsoleColor.Red;
if (errors.Any()) Console.WriteLine("Files that were unable to be opened");
foreach (var error in errors)
{
    Console.WriteLine(" > " + error);
}

Console.ForegroundColor = ConsoleColor.Blue;
Console.WriteLine("Total amount of lines: " + totalLines, Console.ForegroundColor);
Thread.Sleep(500);
Console.ForegroundColor = ConsoleColor.White;
Console.WriteLine("\nPress any key to exit...\n");
Console.ReadKey();