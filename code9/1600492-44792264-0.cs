	public partial class LeTableViewCell : UITableViewCell
	{
		public static readonly NSString Key = new NSString("LeTableViewCell");
		public static readonly UINib Nib;
		static LeTableViewCell()
		{
			Nib = UINib.FromName("LeTableViewCell", NSBundle.MainBundle);
		}
		protected LeTableViewCell(IntPtr handle) : base(handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}
	}
