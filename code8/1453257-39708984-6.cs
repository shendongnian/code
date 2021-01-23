	struct ObjectCount : IEquatable<ObjectCount>
	{
		public object Object { get; }
		public int Count { get; }
		
		public ObjectCount(object o, int c)
		{
			Object = o;
			Count = c;
		}
		
		public bool Equals(ObjectCount o) =>
		   object.Equals(Object, o.Object) && Count == o.Count;
		   
		public override bool Equals(object o) =>
		   (o as ObjectCount?)?.Equals(this) == true;
		
		// this hash combining will work but you can do better.
        // it is not actually used by any of this code.
		public override int GetHashCode() =>
		   (Object?.GetHashCode() ?? 0) ^ Count.GetHashCode();
	}
