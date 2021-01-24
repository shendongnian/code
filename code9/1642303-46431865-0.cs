    {
			const string StartText                  = "PART";
			const string KabelText                  = "KABEL";  
			const string FilenameWithoutCabelNumber = @"...\";
			string fileContent = "";
			int    fileNumber  = 0;
			using (StreamReader reader = File.OpenText(@"...\file.txt"))
			{       
				string line = reader.ReadLine();
				string columnValue = GetParticularColumnName(line);
				//Set columninnehåll till filnamn (String ColumnValue)   
				MessageBox.Show (ColumnValue);
				var ExportfileIncCablenumber ="";
				while ((line = reader.ReadLine()) != null)         
				{   
					if (line.StartsWith(KabelText)) // if line starts with KABEL 
					{   
						ExportfileIncCablenumber =  $"{FilenameWithoutCabelNumber}-{columnValue}({fileNumber}).txt";
						File.WriteAllText(ExportfileIncCablenumber, fileContent);
						
						fileContent = string.Empty;
						columnValue = GetParticularColumnName(line);
						fileNumber++;
					}
					else if (line.StartsWith(StartText)) // if line starts with PART
					{
						fileContent += ((line)+Environment.NewLine);    //writes the active line                                
					}                   
				}
				ExportfileIncCablenumber =  (FilenameWithoutCabelNumber + "-" + columnValue + ".txt");
				File.WriteAllText(ExportfileIncCablenumber, fileContent);
			}
		}
		private static string GetParticularColumnName(string line)
		{
			return line.Split(' ').Last();
		}
