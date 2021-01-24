    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using RDotNet;
    using System.IO;
    
    using commonTools;
    
    namespace RDesk
    {
        class Program
        {
    
    
    
    
            static void Main(string[] args)
            {
    
    
                // set the environment for RDotNet dll
                var envPath = Environment.GetEnvironmentVariable("PATH");
                var rBinPath = @"C:\Program Files\R\R-3.4.1\bin\i386";
                Environment.SetEnvironmentVariable("PATH", envPath + Path.PathSeparator + rBinPath);
    
                // create one instance of RDotNet dll
                REngine engine = REngine.CreateInstance("RDotNet");
                engine.Initialize();
    
                // some test data - alternative 1- from .NET array to R vector.
                NumericVector group1 = engine.CreateNumericVector(new double[] { 30.02, 29.99, 30.11, 29.97, 30.01, 29.99 });
                engine.SetSymbol("group1", group1);
    
                // some test data - alternative 2 - from direct coding to R vector.
                NumericVector group2 = engine.Evaluate("group2 <- c(29.89, 29.93, 29.72, 29.98, 30.02, 29.98)").AsNumeric();
    
                #region: t-test as an example
                string testCommand = "t.test(group1, group2)";
                GenericVector tTest = engine.Evaluate(testCommand).AsList();
                double p = tTest["p.value"].AsNumeric().First();
    
                // present the results on console
                Console.WriteLine("Group1: [{0}]", string.Join(", ", group1));
                Console.WriteLine("Group2: [{0}]", string.Join(", ", group2));
                Console.WriteLine("P-value = {0:0.000}", p);
                #endregion
    
    
                #region: adf test as another example
    
    
                string adfTestCommand
                = " library(tseries) " + System.Environment.NewLine
                + " library(forecast) " + System.Environment.NewLine
                + "adfTest = " + @"adf.test(group1,alternative=""stationary"", k=0)" 
                + System.Environment.NewLine// df test
                ;
    
                // get the result
                // engine.Evaluate(RCommand);
                GenericVector adfTest = engine.Evaluate(RCommand).AsList();
    
                #endregion.
    
    
    
    
                // you should always dispose of the REngine properly.
                // After disposing of the engine, you cannot reinitialize nor reuse it
                engine.Dispose();
    
            }
        }
    }
