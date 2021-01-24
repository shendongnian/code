    public void JoinSplitCellLines()
    {
        for (var i = 0; i < list.Count; i++)
        {
            if(list[i].StartsWith("\"", StringComparison.CurrentCultureIgnoreCase) && 
               !list[i].EndsWith("\"", StringComparison.CurrentCultureIgnoreCase)){
                while(!list[i+1].EndsWith("\"", StringComparison.CurrentCultureIgnoreCase)){
                        list.RemoveAt(i+1);
                }
                list[i]+=list[i+1];
                list.RemoveAt(i+1);
            }
         }
    }
