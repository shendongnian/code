     Stream myStream;
     openFileDialog1.FileName = string.Empty;
     openFileDialog1.InitialDirectory = "C:\\";
       if (openFileDialog1.ShowDialog() == DialogResult.OK)
       {
         if (extension.Equals(".TXT", compareType))
         {
            try
            {
              using (myStream = openFileDialog1.OpenFile())
              {        
               string path = Path.GetDirectoryName(openFileDialog1.FileName);
         StreamReader reader = new StreamReader(openFileDialog1.FileName);
         string line;
         while ((line = reader.ReadLine()) != null)
           {
              string[] value = line.Split('-'); //Split line based on delimiter
              _pointList.Add(new Parameter(value[0], value[1], value[2], value[3], value[4], value[5]));
           }
