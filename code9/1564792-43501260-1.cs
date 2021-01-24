	Label DraggingLabel;
	private void Label_MouseDown(object sender, MouseButtonEventArgs e)
	{
		DraggingLabel = sender as Label;
		if (e.LeftButton == MouseButtonState.Pressed)
			DragDrop.DoDragDrop(DraggingLabel, DraggingLabel.Content, DragDropEffects.Copy);
	}
	private void Label_Drop(object sender, DragEventArgs e)
	{
		Label originalsource = e.OriginalSource as Label;
		Label lblToDrop = sender as Label;
		string fromContent = lblToDrop.Content.ToString();
		lblToDrop.Content = (string)e.Data.GetData(DataFormats.StringFormat);
		DraggingLabel.Content = fromContent;
	}
