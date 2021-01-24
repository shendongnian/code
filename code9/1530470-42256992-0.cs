    public static void AreEqual(int expected, int actual) {
        var equalToConstraint = Is.EqualTo(expected);
        var result = equalToConstraint.ApplyTo(actual);
        if (!result.IsSuccess) {
            NumExceptions++;
        }
    }
