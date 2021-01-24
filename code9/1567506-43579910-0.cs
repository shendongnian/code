    using System;
    using System.Drawing;
    using System.Collections;
    using System.Data;
    using System.Data.SqlClient;
    using System.IO;
    .... 
  
    FileStream fs;                          // Writes the BLOB to a file.
    BinaryWriter bw;                        // Streams the BLOB to the FileStream object.
    int bufferSize = 100;                   // Size of the BLOB buffer.
    byte[] outbyte = new byte[bufferSize];  // The BLOB byte[] buffer to be filled by GetBytes.
    long retval;                            // The bytes returned from GetBytes.
    long startIndex = 0;                    // The starting position in the BLOB output.
    SqlDataReader myReader = connection.ExecuteReader(<your query here>);
    while (myReader.Read())
    {
        fs = new FileStream("my.bmp", FileMode.OpenOrCreate, FileAccess.Write);
        bw = new BinaryWriter(fs);
        startIndex = 0;
        retval = myReader.GetBytes(1, startIndex, outbyte, 0, bufferSize);
        while (retval == bufferSize)
        {
             bw.Write(outbyte);
             bw.Flush();
             startIndex += bufferSize;
             retval = myReader.GetBytes(1, startIndex, outbyte, 0, bufferSize);
        }
        bw.Write(outbyte, 0, (int)retval);
        bw.Flush();
        bw.Close();
        fs.Close();
    }
    myReader.Close();
    connection.Close();
