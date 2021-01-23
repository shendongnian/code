	switch (menyVal)
	{
		case 1:
			Console.WriteLine("\tWrite a title to your post: ");
			// i'd rather declare the string here, so the code and declaration should stick together. (it's not the pascal language ;-))
			string titel= Console.ReadLine();
			Console.WriteLine("\n\tWrite your post: ");
			Console.WriteLine("\t" + tiden.ToShortDateString() + "\n");
			Console.WriteLine("\t" + titel + "\t");
			post = Console.ReadLine();
			
			// here comes the thing:
			// you are formatting it as one element and add that element to the list. 
			// ->> wrong   >>   logg[i] = tiden.ToShortDateString() + "\n" + titel + "\n" + post + "\n";
			// ->> logBook.Add(logg);
			
			// create an array per item....
			string[] arr = new string[2];
			arr[0] = title;
			arr[1] = post;
			
			logBook.Add(arr);
			
			//   i = i + 1;   not needed.
			break;
