    static void Main()
    {
        ProtoBufTest(1);
        for (int i = 0; i < 10; i++)
        {
            ProtoBufTest(1000);
        }
    }
    private static void ProtoBufTest(int numObjects)
    {
        ...
