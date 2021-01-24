    using System.Collections.ObjectModel;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    namespace ConsoleApplication57
    {
        class Program
        {
            static void Main(string[] args)
            {
            }
            public static void ProcessFile(string[] ProcessFile)
            {
                foreach (string filename in ProcessFile)
                {
                    // Used for the output name of the file
                    var dir = Path.GetDirectoryName(filename);
                    var fileName = Path.GetFileNameWithoutExtension(filename);
                    var ext = Path.GetExtension(filename);
                    var folderbefore = Path.GetFullPath(Path.Combine(dir, @"..\"));
                    var lineCount = File.ReadAllLines(@filename).Length;
                    string outputname = folderbefore + "output\\" + fileName;
                    using (StreamWriter Writer = new StreamWriter(dir + "\\" + "output\\" + fileName + "_out" + ext))
                    {
                        int rowCount = 0;
                        using (StreamReader Reader = new StreamReader(@filename))
                        {
                            rowCount++;
                            string inputLine = "";
                            while ((inputLine = Reader.ReadLine()) != null)
                            {
                                if (filename.Contains("RO_"))
                                {
                                    if (rowCount <= 4)
                                    {
                                        Writer.WriteLine(inputLine);
                                    }
                                    if (rowCount == 4) break;
                                }
                                else
                                {
                                    if (rowCount >= 2)
                                    {
                                        Writer.WriteLine(inputLine);
                                    }
                                }
                            } // end of the while
                            Writer.Flush();
                        }
                    }
                } // end of the foreach
            } // end of ProcessFile  
            
        }
     
     
    }
