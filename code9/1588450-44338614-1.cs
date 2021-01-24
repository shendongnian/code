    class Dic : Dictionary<double, double> {
	    //Indexer: 
    	public new double this[double CA] {
		    get => (this as Dictionary<double, double>)[CA];
    		set {
	    		var parent = this as Dictionary<double, double>;
		    	if (parent.ContainsKey(CA))
			    	parent[CA] = value;
			    else
				    parent.Add(CA, value);
		    }
	    }
    }
