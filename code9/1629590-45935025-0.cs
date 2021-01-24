	public sealed class Foo {
		// Both have to be public, otherwise they don't get deserialized
		[XmlAttribute("bar"), DefaultValue(null)]
		public string _bar;
		[XmlAttribute("abc"), DefaultValue(null)]
		public string _abc;
		
		public string bar {
			get {
				if (_bar != null) {
					return _bar;
				} else {
					return _abc;
				}
			}
		}
	}
