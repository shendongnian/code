    // Initialise our variables
    object list1 = new int[5]; // Int32[]
    object list2 = Array.CreateInstance(elementType: typeof(int),
                                        lengths: new[] { 0 },
                                        lowerBounds: new[] { 1 });
    var type1 = list1.GetType();
    var type2 = list2.GetType();
    Debug.WriteLine("type1: " + type1.FullName);
    Debug.WriteLine($"type1: IsArray={type1.IsArray}; ElementType={type1.GetElementType().FullName}; Is Int32[]: {type1 == typeof(Int32[])}");
    Debug.WriteLine("type2: " + type2.FullName);
    Debug.WriteLine($"type2: IsArray={type2.IsArray}; ElementType={type2.GetElementType().FullName}; Is Int32[]: {type2 == typeof(Int32[])}");
    // To make this useful, lets join the elements from the two lists
    List<Int32> outputList = new List<int>();
    outputList.AddRange(list1 as int[]);
    if (type2.IsArray && type2.GetElementType() == typeof(Int32))
    {
        // list2 can be safely be cast to an Array because type2.IsArray == true
        Array arrayTemp = list2 as Array;
        // arrayTemp can be cast to IEnumerable<Int32> because type2.GetElementType() is Int32.
        // We have also skipped a step and cast ToArray
        Int32[] typedList = arrayTemp.Cast<Int32>().ToArray();
        outputList.AddRange(typedList);
    }
    // TODO: do something with these elements in the output list :)
