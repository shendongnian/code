    public partial class ThisAddIn
    {
        private Visio.Document _targetDoc = null;
    
        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            Application.MarkerEvent += Application_MarkerEvent;
        }
    
        public void SetDocEvents()
        {
            _targetDoc = Globals.ThisAddIn.Application.ActiveDocument;
                
            // set event handler
            try
            {
                _targetDoc.ShapeAdded += onShapeAdded;
            }
            catch (Exception err)
            {
                System.Diagnostics.Debug.WriteLine(err.Message);
                throw;
            }
        }
