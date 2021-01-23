    IEnumerable<FileInfo> list1 = dir1.GetFiles("*.*", SearchOption.AllDirectories);
    IEnumerable<FileInfo> list2 = dir2.GetFiles("*.*", SearchOption.AllDirectories);
    IEnumerable<FileInfo> DifferentFiles;
    //if neww dir has more files than old dir
    int j;
    foreach ( var dir in list1 )
    {
    	j=1;
    	for (int i=0; i<list2.count; i++) 
    	{	
    		if (!compare.Equals(dir1,list2[i])) j++
    	}
    	if (j==list2.count){
    		//dir1 is not in list2
    		DifferentFiles.Add(dir1);
    	}
    }
    /*
    //Add this code to know if there are directories in List2  that are not in list1
    //ass the first for is not proving it. 
    foreach ( var dir2 in list2 )
    {
    	j=1;
    	for (int i=0; i<list1.count; i++) 
    	{	
    		if (!compare.Equals(dir2,list1[i])) j++
    	}
    	if (j==list1.count){
    		//dir2 is not in list1
    		if(!DifferentFiles.Contains(dir2)) DifferentFiles.Add(dir2);	
    	}
    }
    */
    
    StreamWriter file = new StreamWriter(Result);
    //if 2 for is not added
    file.WriteLine("The following files in the new Directory are not in the Old one:");
    //if 2 for is added
    	//file.WriteLine("The following files are not in both directories");
    file.WriteLine("");
    foreach(var result in DifferentFiles)
    {
    	file.WriteLine(result.Name + "\n", true);
            Console.WriteLine(result.Name);
    }
    file.Close();
