     public string str = null;
		public Overview (string g)
		{
            str = g;
            this.Children.Add(new Home()
            {
                Title = "Home",
                Icon = "",
            });
            this.Children.Add(new EarnPoints(str)
            {
                Title = "Earn More",
                Icon = "",
            });
