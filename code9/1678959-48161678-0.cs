    public sealed class MyClassMap : ClassMap<MyClass> {
        public MyClassMap() {
            AutoMap();
            Map(m => m.Field1).ConvertUsing(m => $"\"{m.Field1}\"");
            Map(m => m.Field2).ConvertUsing(m => $"\"{m.Field2}\"");
            Map(m => m.Field6).ConvertUsing(m => $"\"{m.Field6}\"");
        }
    }
