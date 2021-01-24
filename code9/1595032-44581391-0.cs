	// Set up mesh
	var block1 = new TransformBlock<int, int>(i => i + 20);
	var block_boadcast = new BroadcastBlock<int>(i => i, new DataflowBlockOptions());
	var block_buffer = new System.Threading.Tasks.Dataflow.BufferBlock<int>();
	var block2 = new ActionBlock<int>(i => Debug.Print("block2:" + i.ToString()));
	var obs = block_buffer.AsObservable();
	var l1 = block1.LinkTo(block_boadcast);
	var l2 = block_boadcast.LinkTo(block2);
	var l3 = block_boadcast.LinkTo(block_buffer);
	// Progress
	obs.Subscribe(i => Debug.Print("progress:" + i.ToString()));
	// Start
	var vals = Enumerable.Range(1, 5);
	foreach (var v in vals)
	{
		block1.Post(v);
	}
	block1.Complete();
