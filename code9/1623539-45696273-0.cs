    string[] arr = s.Split('\n');
    
    List<List<string>> listOfLists = new List<List<string>>(); //dynamic multi-dimensional list
    //list to hold the lines after the line with "21" and that line
    List<string> newList = new List<string>();  
    listOfLists.Add(newList);
    for(int i = 0; i < arr.Length; i++)
    {
        if(arr[i].StartsWith("21"))
        {
            if(newList.Count > 0)
            {                
                newList = new List<string>();  //make a new list for a column
                listOfLists.Add(newList);      //add the list of lines (one column) to the main list
            }
        }
        newList.Add(arr[i]);  //add the line to a column
    } 
