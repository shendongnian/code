    //result list
    List<DocData> docDataList = new List<DocData>();
    
    //get clipboard data
    string clipboardData = Clipboard.GetText(TextDataFormat.Text);
    
    //split it to array of lines using Environment.NewLine (\r\n);
    string[] reportLines = clipboardData.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
    
    if (reportLines.Length < 4) //just an example of checking if there's enough lines
    	throw new Exception("wrong number of lines");
    
    //get correct indexes by reading header (positioned on third line, index 2) - in case order changes
    int createdIndex = GetColumnIndex(reportLines[2], "Created by");
    int PODateIndex = GetColumnIndex(reportLines[2], "PO Date");
    int documentIndex = GetColumnIndex(reportLines[2], "Document");
    
    //when you have indexes, loop through remaining lines, starting at fifth (index 4) and get data from that "columns"
    for (int i = 4; i<reportLines.Length; i++)
    {
    	//now split current line by pipes
    	string[] lineData = reportLines[i].Split('|');
    	//create instance of your class and add data from specific indexes
    	DocData docData = new DocData()
    	{
    		CreatedBy = lineData[createdIndex].Trim(), //also, trim ending spaces,
    		PODate = lineData[PODateIndex].Trim(),
    		Document = lineData[documentIndex].Trim()
    	};
    	docDataList.Add(docData);
    }
    public int GetColumnIndex(string headerLine, string columnName)
    {
    	List<string> headerNames = headerLine.Split('|').ToList(); //split header columns using pipe |.
    
    	//get index of column by trimming and searching throught header column names
    	return headerNames.IndexOf(headerNames.FirstOrDefault(h => h.Trim().Equals(columnName, StringComparison.InvariantCultureIgnoreCase)));
    
    }
