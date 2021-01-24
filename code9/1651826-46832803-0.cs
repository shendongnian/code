    var pbkdf2WithTwoCalls = new Rfc2898DeriveBytes(...)
    var pbkdf2WithOneCall = new Rfc2898DeriveBytes(sameParametersAsAbove);
    byte[] twoCallA = pbkdf2WithTwoCalls.GetBytes(32);
    byte[] twoCallB = pbkdf2WithTwoCalls.GetBytes(16);
    byte[] oneCall = pbkdf2WithOneCall.GetBytes(32 + 16);
    if (!oneCall.SequenceEquals(twoCallA.Concat(twoCallB))
        throw new TheUniverseMakesNoSenseException();
