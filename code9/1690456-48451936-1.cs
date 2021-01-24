    [TestMethod]
    public void TestMethod1()
    {
         
        var parser = new ExpressionParser();
        parser.Functions["add"] = (arguments) => 
            arguments.Aggregate(0.0, (acc, argument) => acc + argument.ToObject<double>());
        parser.Functions["split"] = (arguments) => JArray.FromObject(arguments.Single().ToString().Split(","));
        parser.Functions["regex"] = RegexFunc;
        Assert.AreEqual(4.0, parser.Evaluate("[add(2,2)]"));
        Assert.AreEqual(7.0, parser.Evaluate("[add(2,2,3)]"));
        Assert.AreEqual(3.0, parser.Evaluate("[add(2,2,-1)]"));
        Assert.AreEqual(4.0, parser.Evaluate("[add(2,2,0,0)]"));
        var stdout = File.ReadAllText("stdout.txt");
        var test = parser.Evaluate("[split(regex(\"testfoo\",\"test(.*)\",\"$1\"))]");
        Assert.AreEqual("[\"foo\"]",test.ToString( Newtonsoft.Json.Formatting.None));
        parser.Functions["stdout"] = (arguments) => stdout;
        parser.Functions["numbers"] = (arguments) => new JArray(arguments.SelectMany(c => c).Select(c => double.Parse(c.ToString())));
        var AABB = parser.Evaluate("[numbers(split(regex(stdout(2),\"\\('AABB: ', (.*?)\\)\",\"$1\")))]");
       
        CollectionAssert.AreEqual(new[] { 480000, 6150000, -1580, 530000, 6200000, 755 }, AABB.ToObject<int[]>());
    }
