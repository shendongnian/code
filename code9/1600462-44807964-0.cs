    public partial class ThisAddIn
    {
        private readonly Ribbon _ribbon = new Ribbon();
        protected override Microsoft.Office.Core.IRibbonExtensibility CreateRibbonExtensibilityObject()
        {
            return this._ribbon;
        }
    }
