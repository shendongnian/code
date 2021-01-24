    public class MyServiceAutoDataAttribute : AutoDataAttribute
    {
        public MyServiceAutoDataAttribute() :
            base(new Fixture().Customize(new MyServiceCustomization()))
        {
        }
    }
