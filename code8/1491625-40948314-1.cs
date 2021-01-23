    private static T Make<T>() {
        return (T)Activator.CreateInstance(typeof(T));
    }
    public FirstObj First(string one, string two) {
        return rpc == null ? Make<FirstObj>() : rpc.First(one, two);
    }
    public SecondObj Second(string one) {
        return rpc == null ? Make<SecondObj>() : rpc.Second(one);
    }
    public ThirdObj Third() {
        return rpc == null ? Make<ThirdObj>() : rpc.Third();
    }
