    private static IReadOnlyDictionary<string, byte> _validRevisions
        = new Dictionary<string, byte>
           {
               { "1.0", 0x00 },
               { "1.1", 0x01 },
               { "1.2", 0x02 },
               { "1.3", 0x03 }
            };
    public static IReadOnlyDictionary<string, byte> ValidRevisions => _validRevisions;
