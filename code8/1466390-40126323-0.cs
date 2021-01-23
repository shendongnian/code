    class GenertedEnv
    {
        public List<Action> myList;
    }
    static void AnonymousFunction(GeneratedEnv env, /* Plus other lambda parameters*/)
    {
        var z = env.myList.Count;
        ...
    }
