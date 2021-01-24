        var inputText = "hello-my-name is Anna_B and I'm 30_years-old";
        var length = 15;
        var expectedString = new StringBuilder();
        for (int i = 0; i < inputText.Length; i += length)
        {
            expectedString.AppendLine(inputText.Substring(i, Math.Min(inputText.Length - i, length)));
        }
        Console.WriteLine(expectedString);
