    int ComplexMathMethod(int startPos, int endPos,
        int backgroundStartPos, int backgroundEndStart,
        int squareStartPos) // …and other positions… )
    {
        CheckPosition(() => startPos);
        CheckPosition(() => endPos);
        CheckPosition(() => backgroundStartPos);
        CheckPosition(() => backgroundEndStart);
        CheckPosition(() => squareStartPos);
        // …and so on…  
        return 0;
    }
    void CheckPosition(Expression<Func<int>> positionExpression)
    {
        var name = ((MemberExpression) positionExpression.Body).Member.Name;
        var value = positionExpression.Compile().Invoke();
        Console.WriteLine($"Name = {name}, value ={value}");
    }
