		var s = "This is a string";
		var len1 = s.Length;
		var len2 = System.Text.Encoding.Unicode.GetByteCount(s);
		var len3 = System.Text.Encoding.ASCII.GetByteCount(s);
		Console.WriteLine("'{0}' has {1} characters and is {2} bytes with Unicode encoding and {3} bytes with ASCII encoding.", s, len1, len2, len3);
