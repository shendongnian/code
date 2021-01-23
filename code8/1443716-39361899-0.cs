    static object _lock = new object();
    public void READ_MAPPING_FILE_PATHS(string path , int A429, int ACSB)
    {
       lock(_lock)
       {
          // do something
       }
    }
