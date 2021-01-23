    var template = "Read text1 <%GetName%> Read text2 <%GetID%> Read tex3 <%GetNumber%>";
	var parsed = template.ParseTemplate(new Dictionary<string, object> {
		{ "GetName", "Matías" },
		{ "GetID", "114894" },
		{ "GetNumber", "282893" }
	});
