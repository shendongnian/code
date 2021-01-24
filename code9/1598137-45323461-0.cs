    private void objectListView1_ItemChecked(object sender, ItemCheckedEventArgs e)
    {
        //First we need to cast the received object to an OLVListItem
        BrightIdeasSoftware.OLVListItem olvItem = e.Item as BrightIdeasSoftware.OLVListItem;
    	if (olvItem == null)
    		return;    //Unable to cast
    	
        //Now we can cast the RowObject as our class
        MyClass my = olvItem.RowObject as MyClass;
    	if (my == null)
    		return;   //unable to cast
    	
        //We retrieve the jobnumber.  So this is the job number of the item clicked
        int jobNumber = my.Job; 
    
        //Now loop through all of our objects in the ObjectListView
        foreach(var found in objectListView1.Objects)
        {
            //cast it to our type of object
            MyClass mt = found as MyClass;
           
            //Compare to our job number, if greater then we check/uncheck the items
            if (mt.Job > jobNumber)
            {
                if (e.Item.Checked)
                    objectListView1.CheckObject(mt);
                else
                    objectListView1.UncheckObject(mt);
            }
        }
    }
