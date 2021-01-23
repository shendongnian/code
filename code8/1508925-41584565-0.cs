    navBarControl1.LinkClicked += navBarControl1_LinkClicked;
    //...
    void navBarControl1_LinkClicked(object sender, NavBarLinkEventArgs e) {
        if(e.Link.Item == navBarItem1)
            gridControl1.MainView = gridView1;
        if(e.Link.Item == navBarItem2)
            gridControl1.MainView = cardView1;
    }
