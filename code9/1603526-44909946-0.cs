    mock.Stub(m => m.DoSthMultipleTimes(Arg<int>.Is.Anything))
        .WhenCalled(mi =>
        {
            // Only for debug; this method is empty in the actual test code.
            Console.WriteLine("Stub called with " + mi.Arguments[0]);
        });
