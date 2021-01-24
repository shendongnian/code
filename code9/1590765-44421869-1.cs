    using System.Threading.Tasks;
    public static async Task FirstClassMethod() 
    {
        await SecondClass. SecondClassMethod();
        await ThirdClass. ThirdClassMethod();
        ...
    }
