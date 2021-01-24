    public void MoveToTop(ListBox lb, int index) {
    	var item = lb.Items[index];
    	lb.Items.RemoveAt(index);
    	lb.Items.Insert(0, item);
    	lb.Refresh();
    }
    
    public void MoveToBottom(ListBox lb, int index) {
    	var item = lb.Items[index];
    	lb.Items.RemoveAt(index);
    	lb.Items.Add(item);
    	lb.Refresh();
    }
