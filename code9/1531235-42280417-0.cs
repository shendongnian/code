    // The input.
    // Your question is a little unclear and I couldn't understand how you get this string...
    var message = "[Server] Message of         client received";
    // Iterate over each character
	for (int i = 0; i < message.Length; i++)
	{
        // Check if character is a vowel and output if it is
		if ("aeiouAEIOU".IndexOf(message[i]) >= 0)
			Console.Write(message[i]);
	}
