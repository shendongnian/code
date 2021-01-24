        private void TravelTreeView()
        {
            // better to do this to avoid too many repaints
            TreeView1.BeginUpdate();
    
            TreeView1.Nodes.Clear();
            //Items is the class I created and ObjectList is the List<>
            foreach (Items obj in ObjectList)
            {
               TreeNode node = new TreeNode();
    
               node.Text = obj.Name;
               //Imagelist has 7 images
               node.SelectedImageIndex = 0;
               node.ImageIndex = obj.NameImage;
               node.Nodes.Add(obj.AgeImage, "Age: " + obj.Age, 5);
               node.Nodes.Add(obj.ZodiacImage, "Zodiac: " + obj.Zodiac, 6);
               node.Nodes.Add(obj.JobImage, "Job: " + obj.Job, 7);
           
               // add an expanded Node
               node.Expand();
    
               TreeView1.Nodes.Add(node);
           }
           // we are done with the updates to TreeView
           TreeView1.EndUpdate();
        }
