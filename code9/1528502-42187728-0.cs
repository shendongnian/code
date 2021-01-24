        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listBox1.SelectedIndex==0)//Which is Mammals list
            {
                listBox2.DataSource = reptileList;
            }
            else//Which is Reptiles list
            {
                listBox2.DataSource = mammalList;
            }
        }
