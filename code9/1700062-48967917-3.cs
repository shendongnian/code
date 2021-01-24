	public static void ExportFlatExcel<T>(IEnumerable<T> dataCollection, FileInfo file, string worksheetName)
	{
		using (var package = new ExcelPackage(file))
		{
			var worksheet =
				package.Workbook.Worksheets.FirstOrDefault(excelWorksheet => excelWorksheet.Name == worksheetName) ??
				package.Workbook.Worksheets.Add(worksheetName);
			const BindingFlags flags = BindingFlags.Instance | BindingFlags.Public;
			var props = typeof (T).GetProperties(flags);
			//Map the properties to types
			var rootTree = new Branch<PropertyInfo>(null);
			var stack = new Stack<KeyValuePair<PropertyInfo, IBranch<PropertyInfo>>>(
				props
					.Reverse()
					.Select(pi =>
						new KeyValuePair<PropertyInfo, IBranch<PropertyInfo>>(
							pi
							, rootTree
							)
					)
				);
			//Do a non-recursive traversal of the properties
			while (stack.Any())
			{
				var node = stack.Pop();
				var prop = node.Key;
				var branch = node.Value;
				//Print strings
				if (prop.PropertyType == typeof (string))
				{
					branch.AddNode(new Leaf<PropertyInfo>(prop));
					continue;
				}
				//Values type do not have properties
				var childProps = prop.PropertyType.GetProperties(flags);
				if (!childProps.Any())
				{
					branch.AddNode(new Leaf<PropertyInfo>(prop));
					continue;
				}
				//Add children to stack
				var child = new Branch<PropertyInfo>(prop);
				branch.AddNode(child);
				childProps
					.Reverse()
					.ToList()
					.ForEach(pi => stack
						.Push(new KeyValuePair<PropertyInfo, IBranch<PropertyInfo>>(
							pi
							, child
							)
						)
					);
			}
			//Go through the data
			var rows = dataCollection.ToList();
			for (var r = 0; r < rows.Count; r++)
			{
				var currRow = rows[r];
				var col = 0;
				foreach (var child in rootTree.Children)
				{
					var nodestack = new Stack<Tuple<INode, object>>();
					nodestack.Push(new Tuple<INode, object>(child, currRow));
					while (nodestack.Any())
					{
						var tuple = nodestack.Pop();
						var node = tuple.Item1;
						var currobj = tuple.Item2;
						var branch = node as IBranch<PropertyInfo>;
						if (branch != null)
						{
							currobj = branch.Data.GetValue(currobj, null);
							branch
								.Children
								.Reverse()
								.ToList()
								.ForEach(cnode => nodestack.Push(
									new Tuple<INode, object>(cnode, currobj)
									));
							continue;
						}
						var leaf = node as ILeaf<PropertyInfo>;
						if (leaf == null)
							continue;
						worksheet.Cells[r + 2, ++col].Value = leaf.Data.GetValue(currobj, null);
						if (r == 0)
							worksheet.Cells[r + 1, col].Value = leaf.Data.Name;
					}
				}
			}
			package.Save();
			package.Dispose();
		}
	}
