    protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
        {
        // Make a stateList where we store all stateIDs. 
        List<int> stateList = new List<int>();
    
        // Loop through all items and check if they are selected. If yes then we add them to our list of selected items.
        foreach (ListItem state in ddlState.Items)
        {
         if(state.selected){
         {
        //we add the ID of the state. 
         stateList.Add(state.ID)
         }
        }
     // get all city's assosiated with the states in the stateList
    }
