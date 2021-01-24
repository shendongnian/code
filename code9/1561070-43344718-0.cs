    public class ClassA {
    
        public ClassA() {
            // Do some generic initialization here
            this.ClassB = new ClassB();
            this.ClassC = new ClassC();
        }
    
        // Always call the base constructor using : this()
        public ClassA(string name, int age) : this() {
            this.Name = name;
            this.Age = age;
        }
    
        // chain to another, 'simpler' constructor by doing  : this(name, age)
        public ClassA(string name, int age, ClassB classB) : this(name, age) {
            this.ClassB = classB;
        }
    
        public ClassA(string name, int age, ClassB classV, ClassC classC) : this(name, age, classV) {
            this.ClassC = classC;
        }
        public string Name { get; set; }
        public int Age { get; set; }
        public ClassB ClassB { get; set; }
        public ClassC ClassC { get; set; }
    }
    public class ClassB {
        public string School { get; set; }
        public string Class { get; set; }
    }
    public class ClassC {
        public string Area { get; set; }
        public string Suburb { get; set; }
    }
