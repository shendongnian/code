    public class D1 : A
    {
         public override double[] Calculate(OutputType outputType)
         {
              Contract.Requires(outputType == OutputType.Scaled || outputType == OutputType.NonScaled, "Output type must be either scaled or non-scaled");
    
              // Do stuff here
    
              return result; // double[]
         }
    }
