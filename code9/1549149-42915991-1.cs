    int groupSize = 1000;
	//Batch the data
	var batches = tracker.Parse()
      .Select((contact, index) => new { contact, index })
      .GroupBy(_ => _.index / groupSize, _ => _.contact);
    //Process the batches.
    foreach (var batch in batches) {
        //Each batch would be IEnumerable<TContact>
		ProcessBatch(batch);
	}
