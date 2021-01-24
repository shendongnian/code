    public class SomeUIObject : BaseUIObject<SomeObject>
    {
        public override void Setup(SomeObject someObject)
        {
            base.Setup(someObject);
            SomeUIObjectSpecificRoutine();
        }
        // rest of concrete class code...
    }
