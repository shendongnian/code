    // First ListView
    ListViewFirst.Items.Add("Apple");
    ListViewFirst.Items.Add("Orange");
    ListViewFirst.Items.Add("Banana");
    ListViewFirst.Items.Add("Melon");
    ListViewFirst.Items.Add("WaterMelon");
    
    // Copy to second list view using items index 
    var index = 4;
    var item = ListViewFirst.Items[index].Clone() as ListViewItem;
    ListViewSecond.Items.Add(item);
