    public static class X
    {
    	public static IObservable<T> GetStateMachine(this IObservable<T> source, string identifierSequence)
    	{
    		//State is held in an anonymous type: 
    		//  Index shows what character we're waiting on, 
    		//  Buffer holds characters that have arrived that we aren't ready yet for
    		//  Output holds characters that can be safely emitted.
    		return source
    			.Scan(new { Index = 0, Buffer = ImmutableDictionary<int, ImmutableList<T>>.Empty, Output = Enumerable.Empty<T>() },
    			(state, item) =>
    			{
    				//Function to be called recursively upon receiving new item
    				//If we can pattern match the first item, then it is moved into Output, and concatted recursively with the next possible item
    				//Otherwise just return the inputs
    				(int Index, ImmutableDictionary<int, ImmutableList<T>> Buffer, IEnumerable<T> Output) GetOutput(int index, ImmutableDictionary<int, ImmutableList<T>> buffer, IEnumerable<T> results)
    				{
    					if (index == identifierSequence.Length)
    						return (index, buffer, results);
    
    					var key = identifierSequence[index];
    					if (buffer.ContainsKey(key) && buffer[key].Any())
    					{
    						var toOuptut = buffer[key][buffer[key].Count - 1];
    						return GetOutput(index + 1, buffer.SetItem(key, buffer[key].RemoveAt(buffer[key].Count - 1)), results.Concat(new[] { toOuptut }));
    					}
    					else
    						return (index, buffer, results);
    				}
    
    				//Before calling the recursive function, add the new item to the buffer
    				var modifiedBuffer = state.Buffer.ContainsKey(item.Identifier)
    				   ? state.Buffer
    				   : state.Buffer.Add(item.Identifier, ImmutableList<T>.Empty);
    
    				var remodifiedBuffer = modifiedBuffer.SetItem(item.Identifier, modifiedBuffer[item.Identifier].Add(item));
    
    				var output = GetOutput(state.Index, remodifiedBuffer, Enumerable.Empty<T>());
    				return new { Index = output.Index, Buffer = output.Buffer, Output = output.Output };
    			})
    		    // Use Dematerialize/Notifications to detect and emit end of stream.
    		    .SelectMany(output =>
    		    {
    			    var notifications = output.Output
    				    .Select(item => Notification.CreateOnNext(item))
    					.ToList();
    			    if (output.Index == identifierSequence.Length)
    				   	notifications.Add(Notification.CreateOnCompleted<T>());
    			   	return notifications;
    		   	})
    		   	.Dematerialize();
    	}
    }
