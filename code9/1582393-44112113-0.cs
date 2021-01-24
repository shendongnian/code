    foreach (string linkItem in linkList)
    {
        Literal l1 = new Literal();
        l1.Text = "<li>";
        ListOfLinks.Controls.Add(l1);
    
        //add linkbutton
    
        Literal l2 = new Literal();
        l2.Text = "</li>";
        ListOfLinks.Controls.Add(l2);
    }
