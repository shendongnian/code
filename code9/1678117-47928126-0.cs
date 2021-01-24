    private static void ThisWorksFine()
    {
        typeof(Program).GetField("s_numbers", BindingFlags.NonPublic | BindingFlags.Static)
            .SetValue(null, null);
    }
