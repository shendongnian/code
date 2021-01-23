	private void BtnSearch_Click(object sender, RoutedEventArgs e)
	{
		var mails = new List<EmailEntity>();    
		using (var op = new OperationContext())
		{
			IQueryable<EmailEntity> query = op.EmailEntities;
			if (!string.IsNullOrEmpty(SearchEmailTxt.Text))
				query = query.Where(item => item.Address == SearchEmailTxt.Text);
			if (!string.IsNullOrEmpty(SearchEmailIdTxt.Text))
				query = query.Where(item => item.Id == Convert.ToInt16(SearchEmailIdTxt.Text));
			if (SearchEmailGroupCombo.SelectedItem != null)
				query = query.Where(item => item.EmailGroup.ToString() == SearchEmailGroupCombo.SelectedItem.ToString());
			var result=query.ToList();
			result.ForEach(mails.Add);
			EmailDataGrid.ItemsSource = mails;
		}
	}
