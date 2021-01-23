    public interface IViewAsPdfWrapper {
        string ViewName { get; set; }
        object Model { get; set; }
        byte[] BuildPdf(ControllerContext context);
    }
    public class ViewAsPdfWrapper : IViewAsPdfWrapper {
        private readonly ViewAsPdf view;
        public ViewAsPdfWrapper() {
            view = new ViewAsPdf();
        }
        public string ViewName { get; set; }
        public object Model { get; set; }
        public byte[] BuildPdf(ControllerContext context) {
            view.ViewName = ViewName;
            view.Model = Model;
            return view.BuildPdf(context);
        }
    }
