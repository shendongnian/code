    // Complex expressions work too!
    Example outsideExample = new Example();
    Expression<Func<Example, Example>> expression = x => new Example(
        x.Aaa + outsideExample.Bbb,
        x.Ccc + x.Aaa.Length);
    var myVisitor = new MemberExpressionVisitor();
    myVisitor.Visit(expression);
    Console.WriteLine(string.Join(", ", myVisitor.Members)); // This should print out "Aaa, Ccc"
