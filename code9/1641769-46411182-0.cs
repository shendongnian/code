     var timer = new System.Threading.Timer(async (ev) => {
	
	     using (StreamWriter sw = File.AppendText(path + @"\log_test.txt")) {
        	   sw.WriteLineAsync("-------- LOG BEGIN --------" + Environment.NewLine);
                try {
                    bool sync = await AzureSync.Begin();
                }
                catch (Exception ex) {
                    sw.WriteLine(DateTime.Now + "**** ERROR ****" + Environment.NewLine);
                    sw.WriteLine(ex.ToString() + Environment.NewLine);
                    throw ex;
                }
            }
     }, null, TimeSpan.Zero, TimeSpan.FromMinutes(2));
