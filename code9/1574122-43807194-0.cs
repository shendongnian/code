    for (int i = listView1.SelectedItems.Count - 1; i >= 0; i--)
    {
    	ImageList imageList = new ImageList();
    	imageList.Images.Add(Image.FromFile("D:\\C#\\Przypominacz2 — kopia (4)\\przypominacz\\przypominacz\\Resources\\checked.png"));
    	listView1.SmallImageList = imageList;
    	var listViewItem = listView1.Items.Add("Item with image");
    	//set image index to your listViewItem
    	listViewItem..ImageIndex = 0;
    }
