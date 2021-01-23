    foreach (var document in _documents) {
	    var methods = document.GetSyntaxRootAsync().Result.DescendantNodes().OfType<MemberAccessExpressionSyntax>();
	    foreach (var m in methods.Where(x => x.Name is GenericNameSyntax)) {
	        var genSyntax = m.Name as GenericNameSyntax;
	        if (genSyntax?.Identifier.Text == "CreateRequest") {
		        var args = genSyntax.TypeArgumentList.Arguments;
		        if (args.Count == 3) {
		            var item1 = args[0] as IdentifierNameSyntax;
		            var item2 = args[1] as IdentifierNameSyntax;
		            if (item1 != null && item2 != null) {
			            var c1 = ReflectionTestHelper.GetClassesWithKeyword(item1.Identifier.Text).SingleOrDefault(x => x.Name == item1.Identifier.Text)
			                ?? ReflectionTestHelper.GetEnumsWithKeyword(item1.Identifier.Text).SingleOrDefault(x => x.Name == item1.Identifier.Text);
			            var c2 = ReflectionTestHelper.GetClassesWithKeyword(item2.Identifier.Text).SingleOrDefault(x => x.Name == item2.Identifier.Text)
			                ?? ReflectionTestHelper.GetEnumsWithKeyword(item2.Identifier.Text).SingleOrDefault(x => x.Name == item2.Identifier.Text);
			            if (c1 == null)
			                errors.Add("Unable to find Class for mapping :: " + item1.Identifier.Text);
			            if (c2 == null)
			                errors.Add("Unable to find Class for mapping :: " + item2.Identifier.Text);
			            if (c1 != null && c2 != null) {
			                var map = Mapper.Configuration.FindTypeMapFor(c1, c2);
			                if (map == null) {
				                var location = genSyntax.GetLocation().GetMappedLineSpan();
				                var line = location.Span.Start.Line + 1;
				                var errormessage = new StringBuilder();
				                errormessage.AppendLine("No AutoMapper map found for :: " + item1.Identifier.Text + " -> " + item2.Identifier.Text);
				                errormessage.AppendLine("\tLocation: " + document.FilePath + "[Line:" + line + "]");
				                errormessage.AppendLine("\tMethod: " + genSyntax.Parent);
				                errors.Add(errormessage.ToString());
			                }
    			        }
		            }
	    	    }
	        }
    	}
    }
