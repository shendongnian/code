    private void SetupConditionalMethods()
    {
        bool runConditionals = true;
        if (runConditionals)
        {
            ConditionalSomeMethod = SomeMethod;
            ConditionalSomeMethod2 = SomeMethod2;
        }
        else
        {
            ConditionalSomeMethod = null;
            ConditionalSomeMethod2 = null;
        }
    }
