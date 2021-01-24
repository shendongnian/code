     private void button_compare_Click(object sender, EventArgs e)
     {
           String directory = @"C:\.......\";
           String[] linesA = File.ReadAllLines(Path.Combine(directory, "test1.txt"));
           String[] linesB = File.ReadAllLines(Path.Combine(directory, "test2.txt"));
        
           List<string> onlyB = new List<string>();
        
           for (int i = 0; i < linesA.Length; i++)
           {
              if (!linesA[i].Equals(linesB[i])) 
              {
                 onlyB.Add("line " + i + ": " + linesB[i]);
              }
           }
    
           File.WriteAllLines(Path.Combine(directory, "Result2.txt"), onlyB);
      }
