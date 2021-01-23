    public abstract class SomeeClass{
        public SomeMethod(){
            CallMeMethod();
        }
    
        public abstract TestMeClass CreateTestMeClass();
    
        private void CallMeMethod() {
            TestMeClass testMeClass = CreateTestMeClass();
            testMeClass.TransformMe();
        }
    }
