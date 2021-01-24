	var num1 = new HugeInt("11112222333399998888777123123");
	var num2 = new HugeInt("00194257297549");
	
	Console.WriteLine(num1.Plus(num2).ToString()); // Writes 11112222333399999083034420672
	Console.WriteLine(num1.CompareTo(num2)); // Writes -1 since num1 > num2
