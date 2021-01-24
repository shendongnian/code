    private int findIndexForItem(string name)
    {
    	int ind = -1;
        for (int i = 0; i < listView1.Items.Count; i++)
        {
    		if (listView1.Items[i].Text.Equals(name))
    		{
    			ind = i;
                break;
    		}
    	}
        return ind;
    }
