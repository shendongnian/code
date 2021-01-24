    private void button1_Click_1(object sender, EventArgs e) // converting data grid value to single string
    {
    
    	StringBuilder file = new StringBuilder();
    	for (int i = 0; i < dataGridView2.Rows.Count; i++)
    	{
    		for (int j = 0; j < dataGridView2.Rows[i].Cells.Count; j++)
    		{
                var val = dataGridView2.Rows[i].Cells[j].Value;
    			if (val == null)
    				continue;//IF NULL GO TO NEXT CELL, MAYBE YOU WANT TO PUT EMPTY SPACE
    			var s=val.ToString();
    			file.Append(s.Replace(Environment.NewLine," "));
    		}
    		file.AppendLine();//NEXT ROW WILL COME INTO NEXT LINE
    	}
    
    	using (StreamWriter sw = new 
                       StreamWriter(@"C:\Users\Desktop\VS\Tfiles\file.txt"))
    	{
    		sw.Write(file.ToString());
    	}	
    }
