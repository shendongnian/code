     var sb = new StringBuiler();
     foreach (DataRepeaterItem c in dataRepeater1.Controls)
     {
        sb.AppendLine(((Label)c.Controls["label5"]).Text);
     }
    
     ss+= sb;
