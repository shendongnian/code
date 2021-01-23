        public class MeSecondClass : MyClass
        {
            public override void OnClick(object sender, EventArgs args)
            {
                throw new NotImplementedException();
            }
        }
        public abstract class MyClass
        {
            public abstract void OnClick(object sender, EventArgs args);
        }
        MyClass  a = new MeSecondClass();
