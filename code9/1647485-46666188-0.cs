    public class Parent {
        public Parent(Child child, GrandChild grandChild) {}
    }
    public class Child {
        public Child(GrandChild grandchild) {}
    }
    public class GrandChild {}
    kernel.Bind<Parent>().ToSelf().DefinesNamedScope("scope");
    kernel.Bind<GrandChild>().ToSelf().InNamedScope("scope");
    kernel.Get<Parent>();
