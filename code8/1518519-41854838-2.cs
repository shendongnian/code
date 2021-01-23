    private void ReadRecurcive(TreeNodeCollection nodes, Form form)
    {
        foreach (TreeNode tn in nodes)
        {
            if(tn.IsSelected)
            {
               //This is the function you need to call from form2.  
               form.ReadData(null);
            }
    
            ReadRecurcive(tn.Nodes, form);
        }
    }
