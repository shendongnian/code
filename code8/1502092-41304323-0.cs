	public class ListViewExRenderer : ListViewRenderer
	{
		public override void LayoutSubviews()
		{
			(Control as UITableView).SectionIndexColor = UIColor.Red;
			(Control as UITableView).SectionIndexBackgroundColor = UIColor.Blue;
            base.LayoutSubviews();
		}
	}
