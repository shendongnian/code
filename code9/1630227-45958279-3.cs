    StringBuilder sbText = new StringBuilder();
	using (var reader = new System.IO.StreamReader(textFile)) {
		while ((line = reader.ReadLine()) != null) {
			if (line.Contains(stringToSearch)) {
				//possibly better to do this in a loop
                sbText.AppendLine(reader.ReadLine());
                sbText.AppendLine(reader.ReadLine());
				sbText.AppendLine("Your Text");
                break;//I'm not really sure if you want to break out of the loop here...
			}else {
				sbText.AppendLine(line);
			}
		}
	}  
