    public class MyThingie : MyBaseClass<TheActualData>
    {
    }
    public class TheActualData : ILockable
    {
        public string Foo {get;set;}
        public void FreezeDataForCalculations() { ...???...}
        public void ThawAfterCalculations() { ....???.... }
    }
