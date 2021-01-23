    int j=0;
    string line = null;
    List<string> finalstring = new List<string>();
    for (int i = 0; i < stringArray.Count; i++)
    {
       j = 0;  // <-- you failed to reinitialize 'j' 
       if(stringArray[i] == stringArray2[j])
       {
          //line = stringArray2[i];
      
          //if only first charracter is needed
          finalstring.Add(new string(stringArray2[i][0], 1));
          //if complete string is needed
          //finalstring.Add(stringArray2[i]);
          j++;
       }
    }
