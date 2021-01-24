    var topic = new List<BitArray>();
    string line;
    while ((line = Console.ReadLine()) != null) {
    	topic.Add(new BitArray(line.Select(c => c=='1').ToArray()));
    }
    var res =
       (from t1 in topic
        from t2 in topic
        select t1.Or(t2).Count).Max();
    Console.WriteLine(res);
