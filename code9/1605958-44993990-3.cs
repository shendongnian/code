    List<string> list1 = new List<string> { "Mango", "Banana", "Orange", "Apple", "BlackBerry" };
    List<string> list2 = new List<string> { "Apple", "Cherry", "Kiwifruit", "Banana", "Papaya" };
 
    // giving the capacity to insure add costs O(1)
    Dictionary<string, int> words = new Dictionary<string, int>(list1.Count + list2.Count);
            
    addToDictionary(words, list1);
    addToDictionary(words, list2);
