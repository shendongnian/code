    Console.Write("1");
    while (testsDone <= line) {
        if (PrimeCheck(num) == true) {        
            if (testsDone < line) { Console.Write(","); }
            Console.Write("{0}", num);
        }
        testsDone++;
        num++;
    }
