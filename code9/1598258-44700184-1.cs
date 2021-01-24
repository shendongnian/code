    public static IMyInterface GetMatchingClass(string className)
        {
            switch (className)
            {
                case "Class1":
                    return new Class1();
                default:
                    return new Class2();
            }
        }
