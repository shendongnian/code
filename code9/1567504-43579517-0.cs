    private void btnNext_Click(object sender, EventArgs e)
    {   
            if (intIndex <= listView1.Items.Count)
            {
              intIndex++;
              string line = listView1.Items[intIndex].SubItems[4].Text; //picks list item
              rtbCurrentLine.Text = line;
            }  
     }
