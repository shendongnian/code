    if(rezultat)
    {        
    	ImageList imageList = new ImageList();
    	imageList.Images.Add(Image.FromFile("D:\\C#\\Przypominacz2 — kopia (4)\\przypominacz\\przypominacz\\Resources\\checked.png"));
    	listView1.SmallImageList = imageList;
    	
    	for (int i = 0; i < listView1.Items.Count; i++ )
        {
        	if (listView1.Items[i].Selected)
    			listView1.Items[i].ImageIndex = 0;
        }
    }
