    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Data;
    using System.Data.SqlServerCe;
    
    namespace ConsoleApp5 {
      class Program {
        static void Main( string[] args ) {
          string tableName = "ZTVC_MF_S_VALCHA";
          string sourceString = "Data Source = C:\\Users\\David\\source\\repos\\ConsoleApp5\\ConsoleApp5\\bin\\Debug\\XXX.sdf";
          string destString = "Data Source = C:\\Users\\David\\source\\repos\\ConsoleApp5\\ConsoleApp5\\bin\\Debug\\YYY.sdf";
    
          using ( SqlCeConnection sourceConn = new SqlCeConnection() ) {
            SqlCeCommand sourceCmd = sourceConn.CreateCommand();
            sourceCmd.CommandType = CommandType.Text;
            sourceCmd.Parameters.AddWithValue( "tableName", tableName );
            sourceConn.ConnectionString = sourceString;
            sourceConn.Open();
    
            using ( SqlCeConnection destConn = new SqlCeConnection() ) {
              destConn.ConnectionString = destString;
              destConn.Open();
    
              DoesTableExist( tableName, destConn );
              DataTable dt=GetDataFromTable( tableName, sourceConn );
              CopyTableSchema( tableName, dt, destConn );
              FillTableCopy( tableName, dt, destConn );
              DeleteTable( tableName, destConn );
              Console.ReadKey();
            }
    
          }
        }
        private static void FillTableCopy(  string tabName, DataTable dt, SqlCeConnection destConn) {
            List<string> dTypesList = new List<string>();
            int dTypesListIndexCounter = 0;
            string sqlCmd = "";
            foreach ( DataRow row in dt.Rows ) {
              sqlCmd = "INSERT INTO " + tabName + "(";
              int colHeadCounter = 0;
              int colHeadLast = dt.Columns.Count;
              foreach ( DataColumn colHead in dt.Columns ) {
                string dType = colHead.DataType.ToString().ToLower().Substring( 7 );
                dTypesList.Add( dType );
                if ( ++colHeadCounter == colHeadLast ) {
                  sqlCmd += colHead + " ";
                }
                else {
                  sqlCmd += colHead + ", ";
                }
              }
              sqlCmd += ") VALUES(";
              //Console.Write( sqlCmd );
              colHeadCounter = 0;
              colHeadLast = row.ItemArray.Length;
              foreach ( var item in row.ItemArray ) {
                var temp = item.ToString();
                if ( temp.Count() == 0 ) {
                  if ( ++colHeadCounter == colHeadLast ) {
                    sqlCmd += ( "null " );
                  }else {
                    sqlCmd += ( "null, " );
                  }
                }else if ( dTypesList[dTypesListIndexCounter] == "string"
                 || dTypesList[dTypesListIndexCounter] == "char"
                 || dTypesList[dTypesListIndexCounter] == "datetime"
                 || dTypesList[dTypesListIndexCounter] == "single"
                 || dTypesList[dTypesListIndexCounter] == "guid" ) {
                  if ( ++colHeadCounter == colHeadLast ) {
                    sqlCmd += ( "'" + item + "' " );
                  }else {
                    sqlCmd += ( "'" + item + "', " );
                  }
                }else {
                  if ( ++colHeadCounter == colHeadLast ) {
                    sqlCmd += ( item + " " );
                  }else {
                    sqlCmd += ( item + ", " );
                  }
                }
                dTypesListIndexCounter++;
              }
              sqlCmd += ")";
              //Console.Write( sqlCmd );
              //Console.WriteLine();
              SqlCeCommand cmd = new SqlCeCommand( sqlCmd, destConn );
              cmd.ExecuteNonQuery();
            }
            //Console.WriteLine(cmd);
          Console.WriteLine( "Data copy executed." );
        }
        private static void DeleteTable( string tableName, SqlCeConnection pathConn) {
            string sqlCmd = "DROP TABLE " + tableName;
            SqlCeCommand cmd = new SqlCeCommand( sqlCmd, pathConn );
            cmd.ExecuteNonQuery();
            Console.WriteLine( tableName + " deleted." );
        }
        private static void CopyTableSchema( string tableName, DataTable dt, SqlCeConnection destConn ) {
            string sqlCmd = "Create table " + tableName + "(";
            int colHeadCounter = 0;
            int colHeadLast = dt.Columns.Count;
            /*sqlce supported types: bigint, integer,smallint,tinyint,bit,numeric, money, float, real, datetime,
             * national character, national character varying, ntext, nchar, binary,varbinary, image, uniqueidentifier,
             * identity, rowguidcol, timestamp/rowversion */
            foreach ( DataColumn colHead in dt.Columns ) {
              string dType = colHead.DataType.ToString().ToLower().Substring( 7 );
    
              ////still needs all type conversions mapped
              if ( dType == "int16" ) {
                dType = "smallint";
              }
              else if ( dType == "int32" ) {
                dType = "int";
              }
              else if ( dType == "int64" ) {
                dType = "bigint";
              }
              else if ( dType == "string" ) {
                dType = "nvarchar(4000)";
              }
              else if ( dType == "boolean" ) {
                dType = "bit";
              }
              else if ( dType == "byte" ) {
                dType = "tinyint";
              }
              else if ( dType == "byte[]" ) {
                dType = "binary";
              }
              else if ( dType == "char" ) {
                dType = "nchar";
              }
              else if ( dType == "datetime" ) {
                dType = "datetime";
              }
              else if ( dType == "decimal" ) {
                dType = "money";
              }
              else if ( dType == "double" ) {
                dType = "float";
              }
              else if ( dType == "sbyte" ) {
                dType = "tinyint";
              }
              else if ( dType == "single" ) {
                dType = "real";
              }
              else if ( dType == "guid" ) {
                dType = "uniqueidentifier";
              }
              else {
                Console.WriteLine();
                Console.WriteLine( "Add new type to type conversion" );
                Console.ReadKey();
                Environment.Exit( 0 );
              }
    
              if ( ++colHeadCounter == colHeadLast ) {
                sqlCmd += colHead + " " + dType;
              }
              else {
                sqlCmd += colHead + " " + dType + ", ";
              }
            }
            sqlCmd += ")";
            //Console.WriteLine( sqlCmd );
            SqlCeCommand cmd = new SqlCeCommand( sqlCmd, destConn );
            cmd.ExecuteNonQuery();
            Console.WriteLine( "Copy of " + tableName + " created." );
        }
        private static DataTable GetDataFromTable( string tableName, SqlCeConnection sourceConn ) {
          SqlCeCommand sourceCmd = sourceConn.CreateCommand();
          sourceCmd.CommandText = "Select * from " + tableName;
          SqlCeDataAdapter sourceAdp = new SqlCeDataAdapter( sourceCmd );
          DataTable dt = new DataTable();
          sourceAdp.Fill( dt );
          //Console.WriteLine( "The SqlCeDataAdapter succesfully filled " + dt.Rows.Count + " rows in the DataSet!" );
          return dt;
        }
        private static bool DoesTableExist(string tableName, SqlCeConnection destConn) {
          bool doesIt = false;
          SqlCeCommand destCmd = destConn.CreateCommand();
          destCmd.CommandType = CommandType.Text;
          destCmd.CommandType = CommandType.Text;
          destCmd.CommandText = "SELECT 1 FROM Information_Schema.Tables WHERE TABLE_NAME = @tableName";
          destCmd.Parameters.AddWithValue( "tableName", tableName );
          object result = destCmd.ExecuteScalar();
          if ( result != null ) {
            doesIt = true;
          }
          return doesIt;
        }
      }
    }
    
    
    
    
    
    
        
