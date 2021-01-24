    public class ConcreteVisitor : Visitor {
      public override void Visit(B item) {
        // do something
        // and call Visit for base class
        Visit(item.AsBase()); // convert to base type
      }
    }
