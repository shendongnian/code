    private void TravelTreeView()
        {
            //Items is the class I created and ObjectList is the List<>
            foreach (Items obj in ObjectList)
            {
                //Check to see if the item already exists
                if (!TreeView1.Nodes.ContainsKey(obj.Name))
                {
                    var node = new TreeNode();
                    node.Text = obj.Name;
                    //Imagelist has 7 images
                    node.SelectedImageIndex = 0;
                    node.ImageIndex = obj.NameImage;
                    node.Nodes.Add(obj.AgeImage, "Age: " + obj.Age, 5);
                    node.Nodes.Add(obj.ZodiacImage, "Zodiac: " + obj.Zodiac, 6);
                    node.Nodes.Add(obj.JobImage, "Job: " + obj.Job, 7);
    
                    TreeView1.Nodes.Add(node);
                }
            }
        }
