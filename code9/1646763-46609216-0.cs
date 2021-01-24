    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    namespace ConsoleApp1
    {
        class Program
        {
            static void Main(string[] args)
            {
            //Read file
            var fileContents = File.ReadAllText("file.txt");
            //split on carriage returns and line feeds, remove empty entries.
            var lines = fileContents.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            //Split each line on Tab
            var splitLines = lines.Select(l => l.Split(new[] { '\t' }, StringSplitOptions.RemoveEmptyEntries));
            //splitLines is now an array of arrays.  Each splitLine entry is a line, and each entry of each splitline element is
            //a single field... so we should be able to sort how we want, e.g. by first field then by second field:
            var sortedLines = splitLines.OrderBy(sl => sl[0]).ThenBy(sl => sl[1]);
            //put back together as TSV - put tabs back.
            var linesWithTabsAgain = sortedLines.Select(sl => string.Join("\t", sl));
            //put carriage returns/linefeeds back
            var linesWithCRLF = string.Join("\r\n", linesWithTabsAgain);
            File.WriteAllText("newFile.txt",linesWithCRLF);
        }
    }
    }
