    private static bool IsMostlyUpper (string message)
    {
        if (message.Length > 13) {
            int step = 1 + message.Length / 100; // integer division.
            // 1 for message length < 100
            // 2 for message length < 200
            // 3 for message length < 300
            int limit = message.Length / step / 3;
            int upperCase = 0;
            for (int i = 0; i < message.Length; i += step) {
                if (Char.IsUpper(message[i])) {
                    upperCase++;
                    if (upperCase >= limit) {
                        return true;
                    }
                }
            }
        }
        return false;
    }
