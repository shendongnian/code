    List<string> listArray = new List<string>();
    listArray.Add("This is TEXT");
    listArray.Add("Convert it to words");
    var result = listArray.SelectMany(el => el.Split(" ".ToCharArray())).ToArray();
 
    Console.WriteLine(string.Join(",", result));
    Console.ReadLine();
