    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Data.OleDb;
    using FileHelpers;
    using FileHelpers.Events;
    namespace VOISTATread
    {
    // string delimiterString = "\t";
    class Program
    {
        //private static DataTable[] ar;
        static void Main(string[] args)
        {
                    
            string fileNamePath = @"C:\Pmod.data\data\DATABASES\SAHCNA1\data\M8\20170807\";
            string fileName = "038851711563975.voistat";
            
            Console.WriteLine("fileNamePath:"+fileNamePath);
            Console.WriteLine("fileName:" + fileName);
            Console.ReadLine();
            
            var engine = new FileHelperEngine<PatientVOIstat>();
            var result = engine.ReadFile(fileNamePath + fileName);
            
            {
                // The engine is IEnumerable
               
                foreach (var VOI in result)
                {
                    // your code here
                    Console.WriteLine("Volume, mL: "+VOI.Volume);
                    Console.WriteLine("Area, cm2: "+VOI.SurfaceArea);
                    Console.WriteLine("Fractal dimension: "+VOI.FractalDimension);
                }
            }
            Console.WriteLine("End of data reached");
            Console.ReadLine();
        }
               
    }
     
    
    }
