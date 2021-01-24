    public List<string> GetFileList(string path)
    {	
	    int count = 0;
	    var temp1 = Directory.GetFiles(path);
	    List<string> temp2 = new List<string>();
	
	    foreach (string file in temp1)
	    {
		    string temp = "\\";
		    int padCount = (path.Length + file.Length + temp.Length + 1); //+1 because it counts temp as only one character.
		    temp = temp.PadLeft(padCount, '-');
		    temp2.Add(temp + Path.GetFileName(temp1[count]));
		    count++;
	    }
	
	    return temp2;
    }
