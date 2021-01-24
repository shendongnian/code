    StreamReader myFile = new StreamReader(path);
        string input;
        int count = 0;
		Queue queue = new Queue();
        while(!myFile.EndOfStream)
        {
            input = myFile.ReadLine();
            if (!String.IsNullOrWhiteSpace(input))
            {
                WriteLine(input);
				queue.Enqueue(input);
                count++;
            }
        }
        for (int i = 0; i < count; i++)
        {
            grades[i] = int.Parse(queue.Dequeue());
        }
