    public class Route
    {
        private string Name;
    }
    
    public class RouteSelectedArgs : EventArgs
    {
        public Route Selected { get; set; }
    }
    public interface IRouteSelection
    {
        event EventHandler<RouteSelectedArgs> RouteSelected;
    }
    public interface IRouteDetails { }
    public class RouteWizard
    {
        public UserControl view { get; set; }
        private IRouteSelection _selection;
        private IRouteDetails _details;
        public RouteWizard(IRouteSelection selection, IRouteDetails details)
        {
            _selection = selection;
            _details = details;
            _selection.RouteSelected += Selection_RouteSelected;
            view = MakeView(_selection);
        }
        private void Selection_RouteSelected(object sender, RouteSelectedArgs e)
        {
            _selection.RouteSelected -= Selection_RouteSelected;
            view = MakeView(_details, e.Selected);
        }
        private UserControl MakeView(params object[] args)
        {
            ////magic
            throw new NotImplementedException();
        }
    }
