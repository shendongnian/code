		public string dataOutput
		{
			get
			{
				return string.Join(",", data.Select(x => string.Format("\"{0}\":\"{1}\"", x.Key, x.Value)));
			}
		}
