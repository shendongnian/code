	namespace Namespace2.Style
	{
		public partial class Colors : ResourceDictionary
		{
			public Colors()
			{
				InitializeComponent();
				Add("Color1", Color.FromHex(MyColors.COLOR_1));
                // ...
			}
		}
	}
