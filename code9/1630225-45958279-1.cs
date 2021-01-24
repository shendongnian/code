    StringBuilder sbText = new StringBuilder();
	using (var reader = new System.IO.StringReader(textFile)) {
		while ((line = reader.ReadLine()) != null) {
			if (line.Contains(stringToSearch)) {
				//possibly better to do this in a loop
                reader.ReadLine();
				reader.ReadLine();
				reader.ReadLine();
				sbText.AppendLine("Your Text");
                break;//I'm not really sure if you want to break out of the loop here...
			}else {
				sbText.AppendLine(line);
			}
		}
	}  
