    string mainstring = "[def].[ijk] = [abc].[def].[ijk]";
	
	string pattern = "[lmn].[def].[ijk]";
	
	string []  parts = mainstring.Split('=');
	
	parts[0] = parts[0].Replace("[def].[ijk]",pattern);
	
	string newmainString = String.Join("=", parts);
	
	newmainString.Dump();
