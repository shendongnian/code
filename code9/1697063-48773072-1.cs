            AssignHex4("FF", out byte r1);
            AssignHex4("FFFF", out short r2);
            AssignHex4("FFFFFFFF", out int r3);
            AssignHex4("FFFFFFFFFFFFFFFF", out long r4);
            AssignHex4("FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF", out BigInteger r5);
            Console.WriteLine("Convert in reflection function returns:" + r1 + ", " + r2 + ", " + r3 + ", " + r4 + ", " + r5);
