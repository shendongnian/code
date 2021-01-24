     List<string> match = new List<string>();
     string line;
     using (StreamReader inputStream = new StreamReader(txtInput))
     {
         int charctersLeftAfterMatch = -1;
         string temp = "";
         while ((line = inputStream.ReadLine()) != null)
         {
             // If first instance is found, update characters to pick up next 2
             if (line.Contains("Line1") || line.Contains("Line 1"))
             {
                  charctersLeftAfterMatch = 3;
                  temp = "";
             }
             // If last line (3rd) has been reached then add to collection
             // Else if lines are still left then concatenate and move ahead
             if (charctersLeftAfterMatch-- == 1)
             {
                  temp += line;
                  match.Add(temp);
             }
             else if (charctersLeftAfterMatch > 0)
             {
                  temp += line;
             }
         }
    }
    // Match contains 2 string's: 
    // [0] Line 1 Line 2 Line 3
    // [1] Line1 Line2 Line3
