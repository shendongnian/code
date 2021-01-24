    if (testDel != null) {
        foreach (var del in testDel.GetInvocationList()) {
           Console.WriteLine(del.Target);
           Console.WriteLine(del.Method);
        }
    }
