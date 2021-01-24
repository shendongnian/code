    class IntegerRangeCollection {
    	SortedList<int, int> ranges = new SortedList<int, int>();
    
    	public class Range {
    		public int begin, end;
    	}
    	
    	public IntegerRangeCollection() {
    	}
    
    	public IntegerRangeCollection(int b, int e) {
    		this.Add(b, e);
    	}
    
    	public void Add(int b, int e) {
    		if (ranges.Any()) {
    			if (ranges.ContainsKey(b)) {
    				if (e > ranges[b])
    					ranges[b] = e;
    			}
    			else
    				ranges.Add(b, e);
    			FixUp();
    		}
    		else
    			ranges.Add(b, e); // new ranges list
    	}
    	
    	public void Add(int p) => this.Add(p, p);
    
    	public void Remove(int p) {
    		var r = ranges.Where(pr => pr.Key <= p && p <= pr.Value).First();
    		if (r.Key == p) { // Remove Range begin
    			ranges.Remove(r.Key);
    			if (p+1 <= r.Value)
    				ranges.Add(p+1, r.Value);
    		}
    		else if (p == r.Value) // Remove Range end
    			ranges[r.Key] = p - 1;
    		else { // Split Range
    			ranges[r.Key] = p-1;
    			ranges.Add(p+1, r.Value);
    		}
    	}
    
    	public Range At(int n) {
    		var kvr = ranges.Where(kv => kv.Key <= n && n <= kv.Value);
    		if (kvr.Any()) {
    			var kvrf = kvr.First();
    			return new Range { begin = kvrf.Key, end = kvrf.Value };
    		}
    		else
    			return null;
    	}
    	public bool Contains(int n) => ranges.Where(kv => kv.Key <= n && n <= kv.Value).Any();
    	public bool IsEmpty() => !ranges.Any();
    
    	private bool DoFixUp() { // remove any overlapping ranges
    		foreach (var r in ranges) {
    			foreach (var pr in ranges.Where(pr => r.Key != pr.Key && r.Value == pr.Key - 1)) { // consolidate adjacent ranges
    				ranges.Remove(pr.Key);
    				ranges[r.Key] = pr.Value;
    				return true;
    			}
    			foreach (var pr in ranges.Where(pr => r.Key != pr.Key && pr.Key <= r.Value && r.Value <= pr.Value)) { // overlap end
    				if (pr.Key > r.Key) { // partial overlap, extend beginning
    					ranges.Remove(pr.Key);
    					ranges[r.Key] = pr.Value;
    					return true;
    				}
    				else { // complete overlap, remove
    					ranges.Remove(r.Key);
    					return true;
    				}
    			}
    		}
    
    		return false;
    	}
    
    	private void FixUp() {
    		while (DoFixUp())
    			;
    	}
    }
    
    class ObjectRangeCollection<objType> where objType : class {
    	Dictionary<objType, IntegerRangeCollection> d = new Dictionary<objType, IntegerRangeCollection>();
    	
    	public void Add(int begin, int end, objType obj) {
    		if (d.TryGetValue(obj, out var ranges))
    			ranges.Add(begin, end);
    		else
    			d.Add(obj, new IntegerRangeCollection(begin, end));
    	}
    
    	public void Add(int p, objType obj) => Add(p, p, obj);
    	public void AddRange(ValueTuple<int, int> r, objType obj) => Add(r.Item1, r.Item2, obj);
    	public void AddRange(int[] rs, objType obj) {
    		foreach (var r in rs)
    			this.Add(r, r, obj);
    	}
    
    	public class AtAnswer {
    		public int begin, end;
    		public object tag;
    	}
    	
    	public AtAnswer At(int p) {
    		var possibles = d.Where(kv => kv.Value.Contains(p));
    		if (possibles.Any()) {
    			var kv = possibles.First();
    			var r = kv.Value.At(p);
    			return new AtAnswer { tag = kv.Key, begin = r.begin, end = r.end };
    		}
    		else
    			return null;
    	}
    
    	public objType TagOf(int p) {
    		var possibles = d.Where(kv => kv.Value.Contains(p));
    		if (possibles.Any())
    			return possibles.First().Key;
    		else
    			return null;
    	}
    
    	public void Remove(int p) {
    		var possibles = d.Where(kv => kv.Value.Contains(p));
    		if (possibles.Any()) {
    			foreach (var kv in possibles) {
    				kv.Value.Remove(p);
    				if (kv.Value.IsEmpty())
    					d.Remove(kv.Key);
    			}
    		}
    	}
    
    	public void RemoveWithTag(objType aTag) {
    		d.Remove(aTag);
    	}
    }
