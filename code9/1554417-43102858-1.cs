	foreach (var grouping in duplicates)
	{
        // This will contain the value that was grouped by:
        // - grouping.Key
		foreach (var pair in grouping)
		{
			// These properties are available
			//  - pair.Index
			//  - pair.Text
            // set the FlaggedData property
            pair.Text.FlaggedData = true;
		}
	}
