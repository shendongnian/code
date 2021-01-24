    public interface IPurchaseOrderRepository {
      PurchaseOrder Get(int orderNumber);
      void DoSomethingElse(int orderNumber);
    }
    public class PurchaseOrderRepository: Repository<PurchaseOrder, int> {
      public void DoSomethingElse(int orderNumber) {.......}
    }
     
    MyDependencyInjection.Register<IPurchaseOrderRepository, PurchaseOrderRepository>();
