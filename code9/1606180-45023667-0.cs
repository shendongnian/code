    ArrayList list = new ArrayList();
    while (i<list.Count)
    {
         //creates a new linklabel 
        LinkLabel label = new LinkLabel();
        label.Text = list[i]+"";
    
        label.Location = new System.Drawing.Point(x, y);
        label.Click += dynamic_LinkClicked;
        y += 30;
    
       labels[i] = label;
       this.Controls.Add(labels[i]);
       i++;
    }
