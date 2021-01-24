    public object[] Add_Function()
    {
        return new object[]
        {
            new object[]
            {
                new byte[] { 1, 1, 1 }, new byte[] { 1, 1, 1 }, new byte[] { 2, 2, 2 }
            },
            new object[]
            {
                new byte[] { 1, 1, 255 }, new byte[] { 0, 0, 1 }, new byte[] { 1, 2, 0 }
            }
        };
    }
    [TestCaseSource("Add_Function")]
    public void Add(byte[] a, byte[] b, byte[] expected)
    {
        // arrange
        int len = Math.Max(a.Length, b.Length);
        Array.Resize(ref a, len);
        Array.Resize(ref b, len);
        byte[] result = new byte[len];
        //act
        DoAdd(a, b, result, 0, len - 1);
        //assert
        CollectionAssert.AreEqual(expected, result);
    }
    private void DoAdd(byte[] a, byte[] b, byte[] result, int broughtForward, int index)
    {
        int carriedForward = (a[index] + b[index] + broughtForward) / (byte.MaxValue + 1);
        result[index] =(byte)((a[index] + b[index] + broughtForward) % (byte.MaxValue + 1));
        if (index > 0)
        {
            DoAdd(a,b,result, carriedForward, index-1);
        }
    }
