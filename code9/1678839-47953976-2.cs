    List<(int Prop1, string Prop2, double Prop3)> _list;
    void CreateList()
    {
        _list = new List<(int Prop1, string Prop2, double Prop3)>();
        _list.Add((45, "foo", 4.5));  // Positional
        _list.Add((Prop1: 14, Prop2: "bar", Prop3: 3.1)); // Named
    }
