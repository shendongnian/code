    public class UglyThing<K,E>
	{
		private Dictionary<K, UglyThing<K, E>> dicdic = new Dictionary<K, UglyThing<K, E>>();
		public UglyThing<K, E> this[K key] 
		{ 
			get 
			{
				if (!this.dicdic.ContainsKey(key)) { this.dicdic[key] = new UglyThing<K, E>(); }
				return this.dicdic[key];
			} 
			set
			{
				this.dicdic[key] = value;
			} 
		}
		public E Value { get; set; }
	}
