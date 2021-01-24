    var f1Lines = File.ReadAllLines(@"f:\public\temp\temp1.txt");
    var f2LineInf1 = File.ReadLines(@"f:\public\temp\temp2.txt")
        .Where(line => f1Lines.Any(line.StartsWith));
            
    File.WriteAllLines(@"f:\public\temp\result.txt", f2LineInf1);
