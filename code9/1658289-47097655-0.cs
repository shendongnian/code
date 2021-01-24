    public interface MyInterface
    {
        int Prop1 { get; set; }
        string Prop2 { get; set; }
        void CopyFrom(MyInterface obj);
    }
    
    public class A: MyInterface
    {
        public int Prop1 { get; set; }
        public string Prop2 { get; set; }
        public void CopyFrom(MyInterface obj)
        {
            this.Prop1 = obj.Prop1;
            this.Prop2 = obj.Prop2;
        }
    }
    public class B: MyInterface
    {
        public int Prop1 { get; set; }
        public string Prop2 { get; set; }
        public void CopyFrom(MyInterface obj)
        {
            this.Prop1 = obj.Prop1;
            this.Prop2 = obj.Prop2;
        }
    }
    
    public static class CopyUtils
    {
        public static void Copy(MyInterface src, MyInterface dst)
        {
            var props = typeof(MyInterface).GetProperties();
            foreach(var prop in props)
            {
                prop.SetValue(dst, prop.GetValue(src, null), null);
            }        
        }
    }
