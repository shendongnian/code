    public class HtmlPageEventHelper : PdfPageEventHelper
    {
        List<PDFFragmentViewModel> _fragments;
        FieldInfo context;
        public HtmlPageEventHelper(List<PDFFragmentViewModel> fragments)
        {
            this._fragments = fragments;
            context = typeof(XMLWorker).GetField("context", BindingFlags.NonPublic | BindingFlags.Static);
        }
        public override void OnEndPage(PdfWriter writer, iTextSharp.text.Document document)
        {
            [...]
            // parse
            XMLWorker worker = new XMLWorker(cssPipeline, true);
            XMLParser parser = new XMLParser(worker);
    
            LocalDataStoreSlot contextSlot = (LocalDataStoreSlot) context.GetValue(worker);
            object contextData = Thread.GetData(contextSlot);
            Thread.SetData(contextSlot, null);
            try
            {
                foreach (var _frag in _fragments)
                {
                    ColumnText ct = new ColumnText(writer.DirectContent);
        
                    //using (var reader = new StringReader(_frag.Content))
                    //{
                    //    parser.Parse(reader);
                    //}
        
                    _instance.ParseXHtml(new ColumnTextElementHandler(ct), new StringReader(_frag.Content));
                    //ct.SetSimpleColumn(document.Left, document.Top, document.Right, document.GetTop(-20), 10, Element.ALIGN_MIDDLE);
                    ct.SetSimpleColumn(
                        _frag.LLX.HasValue ? document.GetLeft(_frag.LLX.Value) : document.Left,
                        _frag.LLY.HasValue ? document.GetTop(_frag.LLY.Value) : document.Top,
                        _frag.URX.HasValue ? document.GetRight(_frag.URX.Value) : document.Right,
                        _frag.URY.HasValue ? document.GetBottom(_frag.URY.Value) : document.Bottom,
                        _frag.Leading, _frag.Alignment);
                    ct.Go();
                }
            }
            finally
            {
                Thread.SetData(contextSlot, contextData);
            }
        }
    }
