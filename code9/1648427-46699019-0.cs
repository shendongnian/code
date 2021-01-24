    var input1 = new ChoCSVReader("sample1.csv").WithFirstLineHeader();
    var input2 = new ChoCSVReader("sample2.csv").WithFirstLineHeader();
    
    using (var output = new ChoCSVWriter("sampleDiff.csv").WithFirstLineHeader())
    {
        output.Write(input1.OfType<ChoDynamicObject>().Except(input2.OfType<ChoDynamicObject>(), ChoDynamicObjectEqualityComparer.Default));
        output.Write(input2.OfType<ChoDynamicObject>().Except(input1.OfType<ChoDynamicObject>(), ChoDynamicObjectEqualityComparer.Default));
    }
