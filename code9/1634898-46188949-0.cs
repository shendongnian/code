    using System;
    using System.IO;
    using sds = Microsoft.Research.Science.Data;
    using Microsoft.Research.Science.Data.Imperative;
    
    
    namespace NetCDFConsoleApp
    {
        class Program
        {
            static void Main(string[] args)
            {
                /// Gets the path to the NetCDF file to be used as a data source.
                var dataset = sds.DataSet.Open("D:\\NetCDF\\test.nc?openMode=readOnly");
                            
                string dt = (string)dataset.Metadata["START_DATE"];
    
                Single[,,] dataValues = dataset.GetData<Single[,,]>("ACPR");
    
                for (int iTime = 50; iTime < 60; iTime++)
                {
                    for (int iLongitude = 130; iLongitude < 150; iLongitude++)
                    {
                        for (int iLatitude = 130; iLatitude < 140; iLatitude++)
                        {
                            // write output data
                            float thisValue = dataValues[iTime,iLatitude,iLongitude];                                                
                            Console.WriteLine(dt.ToString() + ',' + iTime.ToString() + ',' + iLatitude.ToString() + ',' + iLongitude.ToString() + ',' + thisValue.ToString());
    
                        }                 
                    }
                }            
                Console.ReadLine();
            }           
        }
    }             
