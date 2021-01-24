    public class ExampleFactory: IExampleFactory 
    {
        IExampleA CreateExampleA()
        {
            //instantiating concrete object A with its dependencies
            return concreteA;
        }
        IExampleB CreateExampleB();
        {
            //instantiating concrete object B with its dependencies
            return concreteB;
        }
    }
