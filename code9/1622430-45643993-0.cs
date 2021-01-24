        public class ObjFlag {  public bool Found { get; set; } }
        public void DoSomething(Action action)
        {
            action();
        }
        public void Sample()
        {
            var objFlag = new ObjFlag { Found = false };
            DoSomething(() => objFlag.Found = true);
            Assert.IsTrue(objFlag.Found);
        }
