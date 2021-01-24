    using (var sr = new StreamReader(fileInput))
    while ((line = sr.ReadLine()) != null)
          {
            LineNumber++;
            if(LineNumber < 1)//if reading header record
            {
            //skip
            }
            else
            {
            //not reading header line
            //check if the line meets your criteria
              if(line == "my anticipated value")
              {
                  line.Split(',')[0];//pull index 0 from the array on strings created by split
              }
            }
         }
