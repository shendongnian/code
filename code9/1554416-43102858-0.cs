	foreach (var grouping in duplicates)
	{
        // This will contain the value that was grouped by:
        // - grouping.Key
		foreach (var pair in grouping)
		{
            // set the FlaggedData property
            pair.Text.FlaggedData = true;
			// These properties are available
			//  - pair.Index
			//  - pair.Text
		}
	}
