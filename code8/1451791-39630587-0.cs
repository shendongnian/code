    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Data.SqlClient;
    using System.Data;
    using System.Configuration;
    namespace Test
    {
        class Program
        {
            static void Main(string[] args)
            {
                //prepare for  splitting the long text and writing into database
                string originalData = "EE12 2014-05-17 22:05:36.260 2 3 1234567890123456789012345678912345678945790842";
                string [] constantField = originalData.Split(' ');
                //previous line results as follow:
                //[0] EE12
                //[1] 2014-05-17
                //[2] 22:05:36.260
                //[3] 2
                //[4] 3
                //[5] 1234567890123456789012345678912345678945790842
                StringBuilder splitingCharacters = new StringBuilder(constantField[5]);
                splitingCharacters.Append(constantField[5]);
               // splitting and writing
               SqlParameter[] sqlParams = new SqlParameter[4];
                sqlParams[0] = new SqlParameter("@column1",SqlDbType.Char,constantField[0].Length);
                sqlParams[1] = new SqlParameter("@column2", SqlDbType.Char, constantField[1].Length + constantField[2].Length+1);
                sqlParams[2] = new SqlParameter("@column3", SqlDbType.Char, constantField[3].Length);
                sqlParams[3] = new SqlParameter("@column4", SqlDbType.Char, constantField[4].Length);
    
                sqlParams[0].Value = constantField[0];
                sqlParams[1].Value = string.Format("{0} {1}", constantField[1], constantField[2]);
                sqlParams[2].Value = constantField[3];
                sqlParams[3].Value = constantField[4];
    
                while (splitingCharacters.Length > 0)
                {
                    using (SqlConnection sqlConn = new SqlConnection("your connection sql "))
                    {
                        SqlCommand sqlComm = new SqlCommand("insert into table1 (column1,column2,column3,column4,column5) values (@column1,@column2,@column3,@column4,@column5)", sqlConn);
                        sqlComm.CommandType = CommandType.Text;
                        sqlComm.Parameters.AddRange(sqlParams);
                        //Spliting the text from left to right.
                        sqlComm.Parameters.Add(new SqlParameter("@column5",SqlDbType.Char,4).Value = splitingCharacters.ToString(0, 4));
                        splitingCharacters.Remove(0, 4);
                        sqlConn.Open();
                        int result = sqlComm.ExecuteNonQuery();
                    }
                }
            }
        }
    }
