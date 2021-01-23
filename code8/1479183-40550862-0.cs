    [Fact]
    public void IsFloatRoundTrippableToDouble()
    {
        var bits = default(FloatUnion);
        bits.FloatData = float.MinValue;
        var testBits = default(FloatUnion);
        // ReSharper disable once LoopVariableIsNeverChangedInsideLoop
        while (bits.FloatData <= float.MaxValue)
        {
            var d = (double)bits.FloatData;
            testBits.FloatData = (float)d;
            if (bits.IntData != testBits.IntData)
                Assert.True(false);
            bits.IntData -= 1;
        }
    }
    [StructLayout(LayoutKind.Explicit)]
    private struct FloatUnion
    {
        [FieldOffset(0)] public uint IntData;
        [FieldOffset(0)] public float FloatData;
    }
