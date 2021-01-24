    public class CMonoBehavour : MonoBehaviour
    {
        public int SomeHelperProperty1 { get; private set; }
        public int SomeHelperProperty2 { get; private set; }
        public int SomeHelperProperty3 { get; private set; }
        public int SomeHelperProperty4 { get; private set; }
    }
    
    public class ThirtPartyLibraryWrapperClass : CMonoBehavour
    {
        public int SomeHelperProperty5 { get; private set; }
        public int SomeHelperProperty6 { get; private set; }
    }
    
    //The first class have 4 properties
    public class ExampleUseage1 : CMonoBehavour
    {
        
    }
        //The first class have 6 properties
    public class ExampleUseage2 : ThirtPartyLibraryWrapperClass
    {
        
    }
