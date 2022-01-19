# Line counter

Line counter is a program written in C# .NET 6. Its goal is very simple to count all the lines in all the document that you have selected in folder where you call it.

## How to use

1. Navigate to the folder where you want to sum all lines
2. Call the executeable, most likely ``line_counter.exe``
   - Tip: put the executable in you enviroment variables.

If you want to only count certain file extension, you can add them as flags to the command

Example: ``line_counter.exe .rs .py`` Now you are only counter files that end with ``.rs`` or ``.py``

## Program structure

Since it is a small program, the only two files you need to pay attention to are
 - `Crawler.cs` Logic for recursively getting all files from folder
 - `Program.cs` Entry point of program