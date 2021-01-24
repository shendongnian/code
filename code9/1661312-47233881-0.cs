    private static int[] ChooseOperands(int n)
    {
            int[] operands = new int[n];  
            Console.Write("Enter first operand: ");
            operands[0] = int.Parse(Console.ReadLine());
            Console.Write("Enter second operand: ");
            operands[1] = int.Parse(Console.ReadLine());
            return operands;
    }
