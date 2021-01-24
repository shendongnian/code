    var encoded = true;
    var input = "{x;ƒ~sq{j|tLtuq";
    var output = Decode(input);
    Console.WriteLine($"input \"{input}\", output \"{output}\"");
    private static string Decode(string input)
    {
        int[] error = { 2, 9, 5, 4, 1, 6, 7, 12, 19, 3, 1, 0, 21, 17 };
        var buffer = new char[input.Length];
        if (encoded)
        {
            int count = 0;
            for(var x=input.Length-1;x>=0;x--)
            {
                buffer[x] = (char) ((Convert.ToInt16(input[x])-48 + error[count]) & 0xFF);
                count++;
                if (count>=error.Length)
                    count=0;
            }
            return new string(buffer)
        }
        return input;
    }
