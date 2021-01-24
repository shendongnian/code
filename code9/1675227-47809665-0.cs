    DateTime lastClickDate = DateTime.Now;
    int xPosition = Cursor.Position.X;
    int yPosition = Cursor.Position.Y;  
    private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
    {
        //You can change the value 1200 as you want.
        if ((DateTime.Now - lastClickDate).TotalMilliseconds < 1200)
        {
            //Just for example I have given as equals it is better to allow
            //some variation since mouse may be moved a little during clicks          
            if(Cursor.Position.X==xPosition && Cursor.Position.Y==yPosition)
            {   
                MessageBox.Show("double clicked");
            } 
        }
        this.Text = (DateTime.Now - lastClickDate).TotalMilliseconds.ToString();
        lastClickDate = DateTime.Now;
    }
