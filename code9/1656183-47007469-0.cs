    string Text = richTextBox1.Text;
	Text = Text.Replace(Enviroment.NewLine, "");
	string NewText = "";
	for(int i = 0; i < Text.Length; i++){
		if( i % 5 == 0)// Insert a line break every 5 characters
	    	NewText += Enviroment.NewLine;
		
		NewText += Text[i];
	}
