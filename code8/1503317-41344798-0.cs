    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    using System.IO;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.dat";
            static void Main(string[] args)
            {
                DataTable datatable = new DataTable(); //just for testing, use your current table
                FileStream stream = new FileStream(FILENAME, FileMode.Create);
                BinaryWriter writer = new BinaryWriter(stream, Encoding.UTF8);
                foreach (DataRow row in datatable.AsEnumerable())
                {
                    writer.Write(row.Field<byte[]>(0));
                }
                writer.Flush();
                writer.Close();
            }
            
        }
        
    }
