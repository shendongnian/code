    private static void MethodA()
    {
        int maxValue = 2147483647;
        long longValue = ( maxValue + 1 );
        checked
        {
            int intValue = ( int ) longValue;
        }
    }
    private static void MethodB()
    {
        int maxValue = 2147483647;
        long longValue = ( maxValue + 1 );
        int intValue = checked( ( int ) longValue);
    }
