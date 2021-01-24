	//To write textbox values to file (may be used on form close)
	using (System.IO.StreamWriter sw = new StreamWriter("values.txt"))
	{
		foreach (var control in this.Controls)
		{
			if (control is TextBox)
			{
				TextBox txt = (TextBox)control;
				sw.WriteLine(txt.Name + ":" + txt.Text);
			}
		}
	}
	
	
	//To read textbox values from file (may be used on form load)
	using (System.IO.StreamReader sr = new StreamReader("values.txt"))
	{
		string line = "";
		while((line=sr.ReadLine()) != null)
		{
			//Ugly, but work in every case
			string control = line.Substring(0, line.IndexOf(':') );
			string val =  line.Substring(line.IndexOf(':') + 1);
			if(this.Controls[control] != null)
			{
				((TextBox)this.Controls[control]).Text = val;
			}
		}
	}
