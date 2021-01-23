    using System;
	using System.Collections.Generic;
						
	public class Program
	{
		public class IndexedTree {
			private readonly IDictionary<string, IndexedTree> _me;
			private object _value;
			private readonly string _splitKey = ".";
			
			public IndexedTree this[string key] {
				get {
					return _me[key];
				}
			}
			
			public object Value { get; set; }
			
			public void Add(string dottedItem) {
				if ( string.IsNullOrWhiteSpace( dottedItem ) ) {
					throw new ArgumentException("dottedItem cannot be empty");
				}
				int index;
				if ( (index = dottedItem.IndexOf( _splitKey ) ) < 0 ) {
					throw new ArgumentException("dottedItem didn't contain " + _splitKey);
				}
				string key = dottedItem.Substring(0, index), rest = dottedItem.Substring(index + 1);
				IndexedTree child;
				if (_me.ContainsKey(key)) {
					child = _me[key];
				} else {
					child = new IndexedTree( _splitKey );
					_me.Add(key, child);
				}
				if (rest.IndexOf(_splitKey) >= 0) {
					child.Add(rest);
				} else {
					// maybe it can be checked if there is already a value set here or not
					// in case there is a warning or error might be more appropriate
					child.Value = rest;
				}
			}
			
			public IndexedTree(string splitKey) {
				_splitKey = splitKey;
				_me = new Dictionary<string, IndexedTree>();
			}
		}
		
		public static void Main()
		{
			IndexedTree tree = new IndexedTree(".");
			tree.Add("Level1.Level2.Level3.Item");
			tree.Add("Level1.Level2.Value");
			Console.WriteLine(tree["Level1"]["Level2"].Value);
			Console.WriteLine(tree["Level1"]["Level2"]["Level3"].Value);
		}
	}
