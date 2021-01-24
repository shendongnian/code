    public class ConcreteVisitor : Visitor {
      public override void VisitB(B item) {
        VisitA(item);
      }
    }
