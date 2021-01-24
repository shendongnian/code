    class Model : ReactiveObject
    {
	    // Other Properties Here...
	    
	    // ObservableAsPropertyHelper makes it easy to map
	    // an observable sequence to a normal property.
	    public double TotalLength => totalLength.Value;
	    readonly ObservableAsPropertyHelper<double> totalLength;
	    public Model()
	    {
	        // Create an observable that resolves whenever a distance changes or
	        // gets added. 
	        // You would probably need CreateObservable()
	        // to use Observable.FromEventPattern to convert the
	        // CollectionChanged event to an observable.
	        var distanceChanged = CreateObservable();
			
			// Every time that a distance is changed:
		    totalLength = distanceChanged
			    // 1. Recalculate the new length.
			    .Select(distances => CalculateTotalLength(distances))
		
				// 2. Save it to the totalLength property helper.
				// 3. Send a PropertyChanged event for the TotalLength property.
			    .ToProperty(this, x => x.TotalLength);
	    }
    }
