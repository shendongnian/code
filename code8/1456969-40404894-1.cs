    class Program
    {
        static void Main(string[] args)
        {
            var instance = new Customer();
            Console.WriteLine(instance.ToString());
        }
    }
    //in Customer class
    public override string ToString()
    {
        return fName + lName;
    }
