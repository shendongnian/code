    var aTest = a as Test1;
    if (aTest != null)
        aTest.True_1();
    else
    {
        var aTest2 = a as Test2;
        if (aTest2 != null)
        {
            aTest2.True_2();
        }
    }
