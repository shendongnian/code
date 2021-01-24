    switch (c?.GetType().FullName) {
        case "MyNamespace.Class1": {
            return ParseClass1((MyNamespace.Class1)c);
        }
        case "MyNamespace.Class2": {
            return ParseClass2((MyNamespace.Class2)c);
        }
        ...
    }
