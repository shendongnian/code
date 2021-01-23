    string line = reader.ReadLine();
    if ( listView1.InvokeRequired ) {
        listView1.Invoke((MethodInvoker)delegate {
	        listView1.Items.Add(line); // runs on UI thread
        });
    }
    else {
        // we're already on UI thread - work on ListView1 directly
	    listView1.Items.Add(line);
    }
