     private void BindTree(IEnumerable<MyObject> list, TreeNode parentNode, string previousNode)
		    {
		        var myObjects = list as IList<MyObject> ?? list.ToList();
		        var nodes = myObjects.Where(x => (parentNode == null ? x.ParentId == "[].[].[(root)]" : x.ParentId == parentNode.Value));
			    
			    var listOfNodeNames = new List<string>();
			
			    foreach (var node in nodes)
			    {
				
				
				    var newNode = new TreeNode(node.Name, node.Id);
				
				   
				
				    BindTree(myObjects, newNode, previousNode);
			    }
			
		    }
