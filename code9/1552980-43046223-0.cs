    TreeView.MouseRightButtonDown += Tv_MouseRightButtonDown;
    
    void Tv_MouseRightButtonDown(object sender, MouseButtonEventArgs e) {
    	var tvItem = e.Source as TreeViewItem;
    	if (tvItem != null) {
    		tvItem.IsSelected = true;
    	}
    }
