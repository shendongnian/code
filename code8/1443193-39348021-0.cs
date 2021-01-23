    public class Class1 {
        public string Ok { get; set; }
    }
    public class Class2 {
        private Class1 cls;
        public int Test { get; set; }
        public string Ok {
            get { return cls.Ok; }
            set { cls.Ok = value; }
        }
        public Class2(Class1 cls) {
            this.cls = cls;
        }
    }
    var cls = new Class2(new Class1 {
        Ok = "Text"
    });
    cls.Test = 3;
    var s = Url.Action("Page", "Controller", cls); // Result: /Controller/Page?Test=3&Ok=Text
