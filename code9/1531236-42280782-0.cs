    Console.Writeline("[Server] Message of client received");
    string vowels = string.Empty; // start with an empty string
    for (int i = 0; i < totalBytes; i++)
    {
       aChar = Convert.ToChar(incomingDataBuffer[i]);
       Console.Write(aChar);
       // if it's a vowel add it to the "vowels" string
       if("aeiouAEIOU".Contains(aChar)) vowels += aChar;
    }
    Console.Write(vowels); // print it out
