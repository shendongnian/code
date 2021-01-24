    public class SampleClass : ISampleInterface {
        //...
    }
    public class FakeDerivedClass : BaseClass {
       ISampleInterface sampleField = new SampleClass;
       protected override ISampleInterface SampleProperty {
           get {
               return sampleField;
           }
       }
    } 
