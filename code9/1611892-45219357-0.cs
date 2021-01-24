    string[] textFile = File.ReadAllLines(@"path");
    List<string> textFile2 = new List<string>();
    for (int i = 0; i < textFile.Length; i++)
    {
        textFile2.Add(textFile[i].Split(' '));
    }
    foreach (string number in textFile2)
    {
        Console.Write(number + " ");
    }
