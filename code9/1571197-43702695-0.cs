                String path = "D:\\";
    			List<String> temp1 = new List<string>();
    			List<String> temp2 = new List<string>();
    			temp1.AddRange(Directory.GetFiles(path));
    			Console.WriteLine(path);
    			foreach (string file in temp1)
    			{
    				string temp = "\\";
    				int padCount = path.Length+temp.Length;//(path.Length + file.Length + temp.Length + 1); //+1 because it counts temp as only one character.
    				temp=temp.PadLeft(padCount, '-');
    				temp2.Add(temp + Path.GetFileName(file));
    				Console.WriteLine(temp + Path.GetFileName(file));
    			}
