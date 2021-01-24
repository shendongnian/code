    .BeforeMap((s, d) =>
    {
    	// we are going to check if any child has been moved from 1 parent to another, and
    	// if so, move the child before the mapping takes place, this way AutoMapper.Collections will not
    	// mark the object as orphaned in the first place!
    	foreach (var srcParent in s.Sections)
    	{
    		// only loop through old measures, so ID will not be zero
    		foreach (var srcChild in srcParent.Children.Where(e => e.Id != 0))
    		{
    			// check if the srcChild is in the same dest parent?
    			var destChild = d.Sections.SelectMany(e => e.Children).Where(e => e.Id == srcChild.Id).FirstOrDefault();
    			
    			// make sure destination measure exists
    			if (destChild != null)
    			{
    				// does the destination child section id match the source section id? If not, child has been moved
    				if (destChild.ParentId != srcParent.Id)
    				{
    					// now we need to move the child into the new parent, so lets find the destination
    					// parent that the child should be moved into
    					var oldParent = destChild.Parent;
    					var newParent = d.Sections.Where(e => e.Id == srcParent.Id).FirstOrDefault();
    
    					// remove child from children collection on oldSection and add to newSection
    					oldParent.Children.Remove(destChild);
    
    					// if newParent is NULL, it is because this is a NEW section, so we need to add this new section
                        // NOTE: Root is my based level object, so your will be different
    					if (newParent == null)
    					{
    						newParent = new Parent();
    						d.Sections.Add(newParent);
    						newParent.Root = d;
    						newParent.RootId = d.Id;
    					}
    					else
    					{
    						// change references on the child
    						destChild.Parent = newParent;
    						destChild.ParentId = newParent.Id;
    					}
    
    					newParent.Children.Add(destChild);
    				}
    			}
    		}
    	}
    })
