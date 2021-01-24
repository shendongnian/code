    public static double CalculateTax(double taxRate)
    {
        double tax = subtotal * taxRate;
        Console.WriteLine($"Tax: {tax}");
        return tax;
    }
