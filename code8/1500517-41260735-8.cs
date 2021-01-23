    public class TableRenderer : BaseHtmlRenderer<TableItem>
    {
        // we need to be able to render individual cells
        private Dictionary<Type, Action<StringBuilder, object>> _renderers;
    
        public override void Append(StringBuilder html, TableItem element)
        {
            RenderHeaderRowStart(html);        
            foreach (var col in element.HeaderCols)
            {
                var cellRenderer = _renderers[col.GetType()];
                cellRenderer.Append(html);
            }
            RenderHeaderRowEnd(html);
            
            ...
        } 
    }
    
