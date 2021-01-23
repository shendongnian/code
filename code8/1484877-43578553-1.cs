    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.IO;
    using Microsoft.SqlServer.Dac.Compare;
    
        namespace SchemaComparer
        {
            class Program
            {
                //The directory where all the scmp files are located
                const string schemaDirectory = "C:\SchemaCompare\\";
        
                static void Main(string[] args)
                {
                    //Loop thru all the scmp from the directory. This set to max 2 thread that run parallel and update together
                    Parallel.ForEach(Directory.GetFiles(schemaDirectory), new ParallelOptions { MaxDegreeOfParallelism = 2 }, (file) =>   
                    {
                        try
                        {
                            // Load comparison from Schema Compare (.scmp) file
                            var comparison = new SchemaComparison(file);
        
                            Console.WriteLine("Processing " + Path.GetFileName(file));
                            Console.WriteLine("Comparing schema...");
        
                            SchemaComparisonResult comparisonResult = comparison.Compare();
        
                            // Publish the changes to the target database
                            Console.WriteLine("Publishing schema...");
        
                            SchemaComparePublishResult publishResult = comparisonResult.PublishChangesToTarget();
        
                            Console.WriteLine(publishResult.Success ? "Publish succeeded." : "Publish failed.");
                            Console.WriteLine(" ");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    });
        
                    Console.ReadLine();
                }
            }
        }
