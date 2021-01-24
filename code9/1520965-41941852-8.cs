    using System;
    using System.Data.SqlTypes;
    
    namespace SqlDecimalMultiplication
    {
        class Program
        {
            private static void DisplayStuffs(SqlDecimal Dec1, SqlDecimal Dec2)
            {
                Console.WriteLine("1 ~ {0}", Dec1.Value);
                Console.WriteLine("1 ~ Precision: {0}; Scale: {1}; IsPositive: {2}", Dec1.Precision, Dec1.Scale, Dec1.IsPositive);
                Console.WriteLine("2 ~ {0}", Dec2.Value);
                Console.WriteLine("2 ~ Precision: {0}; Scale: {1}; IsPositive: {2}", Dec2.Precision, Dec2.Scale, Dec2.IsPositive);
    
                Console.Write("\nRESULT:    ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(Dec1 * Dec2);
                Console.ResetColor();
    
                return;
            }
    
            static void Main(string[] args)
            {
                var dec1 = new SqlDecimal(-0.00000450m);
                var dec2 = new SqlDecimal(0.193m);
    
                Console.WriteLine("=======================\n\nINITIAL:");
                DisplayStuffs(dec1, dec2);
    
    
                dec1 = SqlDecimal.ConvertToPrecScale(dec1, 38, 8);
                dec2 = SqlDecimal.ConvertToPrecScale(dec2, 18, 8);
    
                Console.WriteLine("=======================\n\nAFTER (38, 8) & (18, 8):");
                DisplayStuffs(dec1, dec2);
    
    
                dec1 = SqlDecimal.ConvertToPrecScale(dec1, 18, 8);
    
                Console.WriteLine("=======================\n\nAFTER (18, 8) & (18, 8):");
                DisplayStuffs(dec1, dec2);
    
    
                dec1 = SqlDecimal.ConvertToPrecScale(dec1, 38, 28);
                dec2 = SqlDecimal.ConvertToPrecScale(dec2, 38, 28);
    
                Console.WriteLine("=======================\n\nAFTER (38, 28) & (38, 28):");
                DisplayStuffs(dec1, dec2);
    
                Console.WriteLine("=======================");
                //Console.ReadLine();
            }
        }
    }
