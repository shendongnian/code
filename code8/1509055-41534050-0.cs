     int num1;
     int num2;
    public virtual void setproblem()
    {
        Random random = new Random();
        num1 = random.Next(100);
        num2 = random.Next(100);
        int sum = num1 + num2;
    }
    public virtual void askuserforanswer()
    {
        int answer;
        Console.WriteLine("Enter your answer");
        answer = Convert.ToInt32(Console.ReadLine());
    }
    public virtual void displayproblem()
    {
        Console.WriteLine( num1.ToString() + " + " + num2.ToString() + " = ?");
    }
}
