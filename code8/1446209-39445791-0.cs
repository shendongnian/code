    public void Main()
    		{
                 string myPath = @"\\wsdkdib00\!_Download\";
                  Directory.GetFiles(myPath);
                  if (Path.GetExtension(myPath) == "T_D_FD_TESTUA_QWE_")
                  {
                      Dts.TaskResult = (int)ScriptResults.Success;
                  }
    		}
