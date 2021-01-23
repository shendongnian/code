    class Factory
    {
        public static Visitable Create(string userInput)
        {
            switch (userInput)
            {
                case nameof(ClassA):
                    return new ClassA();
                case nameof(ClassB):
                    return new ClassB();
                default:
                    return null;
            }
        }
    }
