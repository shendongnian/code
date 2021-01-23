    private void btnReplace_Click(object sender, EventArgs e)
    {
    	// The '@' marks the string as a verbatim string.
        string check = @"[HKEY_CURRENT_USER\SOFTWARE\Thingamahoochie\WinMerge\Settings-Bar1]";
    
    	var linesAfterCheck = File.ReadLines(_path)
    	.SkipWhile(l => l != check) // Skip until check
    	.Skip(1); // Skip line containing check
    
    	foreach (string line in linesAfterCheck)  
    	{
    	    // Code
    	}
    }
