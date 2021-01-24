    class ClassA {
    }
    class ClassB {
        public void Function<T>() {
                  ......
        }
    class ClassC {
        public void main() {
            ClassB asdf = new ClassB();
            asdf.Function<ClassA>();   // magic
        }
    }
