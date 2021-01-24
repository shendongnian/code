    string StupidDate = "0d1333141b10";
    string p1 = "0" + Helpers.ArbitraryToDecimalSystem(StupidDate.Substring(6, 2), 13);
    if (p1.Length == 3) { p1 = p1.Substring(1, 2); }
    string p2 = "0" + Helpers.ArbitraryToDecimalSystem(StupidDate.Substring(2, 2), 5);
    if (p2.Length == 3) { p2 = p2.Substring(1, 2); }
    string p3 = "0" + Helpers.ArbitraryToDecimalSystem(StupidDate.Substring(4, 2), 7);
    if (p3.Length == 3) { p3 = p3.Substring(1, 2); }
    string p4 = "0" + Helpers.ArbitraryToDecimalSystem(StupidDate.Substring(0, 2), 17);
    if (p4.Length == 3) { p4 = p4.Substring(1, 2); }
    string p5 = "0" + Helpers.ArbitraryToDecimalSystem(StupidDate.Substring(10, 2), 21);
    if (p5.Length == 3) { p5 = p5.Substring(1, 2); }
    string p6 = "0" + Helpers.ArbitraryToDecimalSystem(StupidDate.Substring(8, 2), 19);
    if (p6.Length == 3) { p6 = p6.Substring(1, 2); }
    string DateString = "20" + p1 + "_" + p2 + "_" + p3 + "_" + p4 + "_" + p5 + "_" + p6;
