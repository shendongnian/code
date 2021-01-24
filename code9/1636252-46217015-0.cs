    public class PurchaseOrderController : Controller
    {    
       private IPurchaseOrder interfaceRepository;
        public PurchaseOrderController()
        {
            if (interfaceRepository==null)
            {
                this.interfaceRepository= new Repository();
            }
        }
        int maxId=interfaceRepository.GetMaxPK(a=>a.POMSTID);
    }
