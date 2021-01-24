	...
    foreach (var file in directory.GetFiles("*"))
    {
        fileCount++;
        Console.WriteLine("  [" + DateTime.Now.ToShortTimeString() + "]" + " Working through file: {" + file + "} {" + fileCount + "/" + directory.GetFiles("*").Count() + "}");
		System.IO.StreamReader file = new System.IO.StreamReader(filepath + @"\" + file.ToString());
		
		while(!file.EndOfStream)
        {
			int passwordBatchCount = 0;
			List<Password> entitysBatch = new List<Password>();
			
			while ((string line = file.ReadLine()) != null && passwordBatchCount < BATCH_SIZE)
			{
				entitysBatch.Add(new Password { password = line });
				passwordBatchCount++;
			}
			
			collection.InsertManyAsync(entitysBatch);
		}
		
        file.Close();
        }
    }
	
	...
