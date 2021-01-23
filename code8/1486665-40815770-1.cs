    public class _2A1Controller : Controller {
        private readonly IUnitOfWork UnitOfWork;
        private readonly IViewAsPdfWrapper viewAsPdf;
    
        public _2A1Controller(IUnitOfWork uow, IViewAsPdfWrapper viewAsPdf) {
            this.UnitOfWork = uow;
            this.viewAsPdf = viewAsPdf;
        }
    
        public ActionResult DetailsPrint(int? id) {
            var a = viewAsPdf;
            a.ViewName = "../Ops/_2A1/Details";
            a.Model = UnitOfWork._2A1s.Get(id.Value);
            var pdfBytes = a.BuildPdf(ControllerContext);
    
            // return ActionResult
            MemoryStream ms = new MemoryStream(pdfBytes);
            return new FileStreamResult(ms, "application/pdf");
        }
    
    }
