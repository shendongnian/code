    finally
    {
    	// Close connection
    	oledbConn.Close();
    	oledbConn.Dispose();
        System.Runtime.InteropServices.Marshal.ReleaseComObject(oledbConn);
    }
