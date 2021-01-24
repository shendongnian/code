    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Data.SqlTypes;
    using System.IO;
    
    namespace StackOverflow.ConsoleTester
    {
        public class Program
        {
            private const String SqlConnectionString = @"Server={Server};Database={Database};User={User};Password={Password};";
    
            public static void Main(String[] args)
            {
                using (var db = new SqlConnection(SqlConnectionString))
                {
                    var sqlCommand = new SqlCommand("DELETE FROM dbo.BinaryTest;", db) { CommandType = CommandType.Text };
    
                    db.Open();
    
                    sqlCommand.ExecuteNonQuery();
                }
    
                using (var db = new SqlConnection(SqlConnectionString))
                {
                    var serializedData = new Dictionary<String, String> {{"key1", "value1"}, {"key2", "value2"}};
    
                    var binaryData = WriteBinaryData(serializedData);
    
                    var sqlCommand = new SqlCommand("INSERT INTO dbo.BinaryTest (BinaryData) VALUES (@BinaryData);", db) { CommandType = CommandType.Text };
    
                    var parameter = new SqlParameter("BinaryData", SqlDbType.VarBinary) {Value = binaryData};
    
                    sqlCommand.Parameters.Add(parameter);
    
                    db.Open();
    
                    sqlCommand.ExecuteNonQuery();
                }
    
                Dictionary<String, String> deserializedData = null;
    
                using (var db = new SqlConnection(SqlConnectionString))
                {
                    var sqlCommand = new SqlCommand("SELECT BinaryData FROM dbo.BinaryTest", db) { CommandType = CommandType.Text };
    
                    db.Open();
    
                    var reader = sqlCommand.ExecuteReader();
    
                    while (reader.Read())
                    {
                        deserializedData = ReadBinaryData(reader.GetSqlBinary(0));
                    }
                }
    
                if (deserializedData != null)
                {
                    foreach (var item in deserializedData)
                    {
                        Console.WriteLine($"Key: {item.Key}; Value: {item.Value}");
                    }
                }
    
                Console.ReadKey();
            }
    
            private static Byte[] WriteBinaryData(Dictionary<String, String> data)
            {
                var memoryStream = new MemoryStream();
                var binaryWriter = new BinaryWriter(memoryStream);
    
                foreach (var item in data)
                {
                    binaryWriter.Write(item.Key);
                    binaryWriter.Write(item.Value);
                }
    
                var binaryData = memoryStream.ToArray();
    
                return binaryData;
            }
    
            private static Dictionary<String, String> ReadBinaryData(SqlBinary data)
            {
                var model = new Dictionary<String, String>();
    
                var memoryStream = new MemoryStream(data.Value);
                var binaryReader = new BinaryReader(memoryStream);
    
                while (binaryReader.BaseStream.Position != binaryReader.BaseStream.Length)
                {
                    model.Add(binaryReader.ReadString(), binaryReader.ReadString());
                }
    
                return model;
            }
        }
    }
