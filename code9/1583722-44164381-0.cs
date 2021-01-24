    using System;
    using System.Data;
    using System.Data.OleDb;
    using System.IO;
    
    namespace LoadingCSVFile_44078546
    {
        class Program
        {
            static void Main(string[] args)
            {
                getDataTableFromCsvFile(@"M:\StackOverflowQuestionsAndAnswers\LoadingCSVFile_44078546\myfile.txt", "myfile.txt");
            }
    
            public static DataTable getDataTableFromCsvFile(string path, string file)
            {
                string folderPath = Path.GetDirectoryName(path);
                string fileName = Path.GetFileName(path);
                string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\"" + folderPath +
                    "\";Extended Properties=\"text;HDR=Yes;Imex=0;FMT=Delimited;\"";
                DataTable dt = new DataTable();
    
                try
                {
                    OleDbConnection objConn = new OleDbConnection(connectionString);
                    objConn.Open();
    
                    OleDbCommand objCmdSelect = new OleDbCommand("select * from [" + file + "]", objConn);
                    OleDbDataAdapter objAdapter = new OleDbDataAdapter();
    
                    objAdapter.SelectCommand = objCmdSelect;
                    objAdapter.Fill(dt);
                    DataColumn dc0 = dt.Columns[0];
                    DataColumn dc1 = dt.Columns[1];
                    DataColumn dc2 = dt.Columns[2];
                    DataColumn dc3 = dt.Columns[3];
                    objConn.Close();
                }
                catch (Exception ex)
                {
                    //Do something
                }
    
                return dt;
            }
        }
    }
