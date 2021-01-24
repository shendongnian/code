    public void ProcessEntities()
    {
        foreach(DBDictionaryEntry obj in MyNOD)
        {
            //Add each objectID to your exclusion List
            //if it's already there, everything inside the if statement is skipped!
            if(exclusionList.Add(obj.Value))
            {
                 //do your object modification here
            }
        }
        //All entities have been processed now
        //clear the list and wait for the next event
        exclusionList.Clear();
    }
