            if (txtNodeName.Text==String.Empty)
            {
                MessageBox.Show("Please enter the Node Name in Textbox");
                txtNodeName.Focus();
            }
            else
            {
                string n = txtNodeName.Text;
                if (treeView1.SelectedNode == null)
                {
                    treeView1.Nodes.Add(n, n);
                }
                else
                {
                    treeView1.SelectedNode.Nodes.Add(n, n);
                }
            }
        }
            BinaryFormatter bf = new BinaryFormatter();
            int i=1; 
           private void btnSerialize_Click(object sender, EventArgs e) //serialization is done here
            {
                i = 1;
            Stream file = File.Create(filename);
            ArrayList ar = new ArrayList();
            foreach (TreeNode tn in treeView1.Nodes)
            {
                ar.Add(tn);                                     //conver tree to arraylist
            }
            bf.Serialize(file, ar);
            file.Close(); 
        }
           
            private void btnDeserialize_Click(object sender, EventArgs e) //deserialization is done here
            {
               
                if (i == 1)
                {
                    treeView1.Nodes.Clear();
                    Stream file = File.Open(filename, FileMode.Open);
                    TreeNode tr = null;
                    object obj = null;
                    try
                    {
                        obj = bf.Deserialize(file);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    ArrayList ar = obj as ArrayList;
                    foreach (TreeNode tl in ar)
                    {
                        if (tr == tl)
                            tr = tl;
                        treeView1.Nodes.Add(tl);
                    }
                    file.Close();
                    i++;
         
