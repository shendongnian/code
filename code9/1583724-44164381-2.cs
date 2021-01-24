    using System;
    using System.Data;
    using System.Data.OleDb;
    using System.IO;
    using System.Collections.Generic;
    
    namespace LoadingCSVFile_44078546
    {
        class Program
        {
            static void Main(string[] args)
            {
                DoItAgain(@"M:\StackOverflowQuestionsAndAnswers\LoadingCSVFile_44078546\sample.txt");
            }
    
            private static DataTable DoItAgain(string path)
            {
                string folderPath = Path.GetDirectoryName(path);
                string fileName = Path.GetFileName(path);
                string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\"" + folderPath +
                    "\";Extended Properties=\"text;HDR=Yes;FMT=Delimited;\"";
                DataTable dt = new DataTable();
    
                try
                {
                    OleDbConnection objConn = new OleDbConnection(connectionString);
                    objConn.Open();
    
                    OleDbCommand objCmdSelect = new OleDbCommand("select * from [" + fileName + "]", objConn);
                    OleDbDataAdapter objAdapter = new OleDbDataAdapter();
    
                    objAdapter.SelectCommand = objCmdSelect;
                    objAdapter.Fill(dt);
                    objConn.Close();
                }
                catch (Exception ex)
                {
                    //Do something
                }
    
                List<string> tmpList = new List<string>();
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow item in dt.Rows)//ietrate through the record set
                    {
                        for (int i = 0; i < dt.Columns.Count; i++)//iterate throught the columns a the record
                        {
                            /*
                             * I don't know how you want to validate the path
                             * So here's something you should replace with your own
                             */
                            if (item[i].ToString().Contains("\\"))
                            {
                                tmpList.Add(item[i].ToString());//add the path to the List<>
                            }
                        }
                    }
                }
    
                /*
                 * tmpList now hold the image paths
                 */
    
                return dt;
            }
    
        }
    }
