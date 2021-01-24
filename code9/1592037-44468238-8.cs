		private bool _ignoreMe;
		public void ClassName()
		{
            var b = this.GetType().GetField(nameof(_ignoreMe), BindingFlags.NonPublic | BindingFlags.Instance).DeclaringType;
		}
