    List<string> listArray = new List<string>();
    listArray.Add("This is TEXT");
    listArray.Add("Convert it to words");
    // this is the array holding all words
    var result = listArray.SelectMany(el => el.Split(" ".ToCharArray())).ToArray();
 
    // this puts , between any words in result to output it ...
    Console.WriteLine(string.Join(",", result));
    Console.ReadLine();
