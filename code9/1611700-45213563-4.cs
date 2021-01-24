	List<byte> allBytesList = new List<byte>();
	allBytesList.AddRange(TransformBytes(   6000, 2));
	allBytesList.AddRange(TransformBytes(     19, 4));
	allBytesList.AddRange(TransformBytes(1000000, 4));
	allBytesList.AddRange(TransformBytes( 100000, 4));
	allBytesList.AddRange(TransformBytes(      4, 1));
	Console.WriteLine(" All -> : " + String.Join(" ", allBytesList.Select(x => x.ToString("X2"))));
