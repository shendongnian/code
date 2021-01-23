      String s1 = "010000001";
      String s2 = "1A000001A";
      String s3 = s1.Replace("01", "0C");
      String s4 = s2.Replace("1A", "15");
      Console.WriteLine(s1 + " -> " + s3 + "\n\r" + s2 + " -> " + s4);
      Console.ReadKey();
