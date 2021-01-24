    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Diagnostics;
    using System.IO;
    
    static class Program {
    
        static void Main()
        {
        	var pathDir = @"C:\Main\Directory\Path\External";
        	var varFile = @"C:\Main\Directory\Path\file.tmp";
        	var progExt = @"C:\Main\Directory\Path\Program.exe";
        	
        	var commandBase = string.Format("/C echo {0} && echo {1} && echo {2} && echo ",
        		pathDir, varFile, progExt);
        		
        	var commands = Directory
        		.GetFiles(@pathDir, "*.patch")
        		.Select(file => string.Format("{0}{1}&& pause",	commandBase, file));
        		
        	foreach (var c in commands){
        		Process.Start("CMD.exe", c);
        	}
        }
    }
