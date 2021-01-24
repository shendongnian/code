	private void listView1_MouseMove(object sender, MouseEventArgs e)
	{
		if (e.Button == MouseButtons.Left)
		{
			ListView listView = ((ListView)sender);
			ListViewItem listViewItem = listView.GetItemAt(e.X, e.Y);
			if (listViewItem != null)
			{
				listView.DoDragDrop(listViewItem, DragDropEffects.Move);
			}
		}
	}
