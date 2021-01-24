        public static void DebugLayout(this View self, int indent = 0)
	    {
			// write info about me first
		    var indents = new string('\t', indent);
			System.Diagnostics.Debug.WriteLine(indents + self.GetType().Name);
            // check if I'm a view group
			var vg = self as ViewGroup;
		    if (vg == null) return;
            // enumerate my children
		    var children = Enumerable.Range(0, vg.ChildCount).Select(x => vg.GetChildAt(x));
            // recurse on each child
		    foreach (var child in children)
			    DebugLayout(child, indent+1);
	    }
