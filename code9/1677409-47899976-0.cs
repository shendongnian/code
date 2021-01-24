    using System;
    using System.Linq;
    using System.IO;
    
    public class Program
    {
    	public static void Main()
    	{
            // some strings that are like paths
    		var dirs = new[] 
            {
                @"C:\temp\image\a.jpg", @"C:\temp\image\b.bmp", @"c:\temp\bin\my.exe", 
                @"c:\temp\document\resume.doc", @"c:\temp\document\timetable.xlsx"
            };
            // this will use a static method to extract only the path-part
    		var fullDirs = dirs.Select(d => Path.GetDirectoryName(d)).ToList();
            // this will use the same method but split the result at the default systems
            // path-seperator char and use only the last part, only uses distinct values
    		var lastDirsDistinct = dirs.Select(d => Path.GetDirectoryName(d)
                        .Split(Path.DirectorySeparatorChar).Last()
                    ).Distinct().ToList();
    
            // joins the list with linebreaks and outputs it
    		Console.WriteLine(string.Join("\n", fullDirs));
    		
            // joins the list with linebreaks and outputs it    		
            Console.WriteLine(string.Join("\n", lastDirsDistinct ));
    	}
    }
