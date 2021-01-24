    public class TableProcessor : Table
    {
        const string NO_ROW_SPLIT = "no-row-split";
       
        public override IList<IElement> End(IWorkerContext ctx, Tag tag, IList<IElement> currentContent)
        {
            IList<IElement> result = base.End(ctx, tag, currentContent);
            var table = (PdfPTable)result[0];
            if (tag.Attributes.ContainsKey(NO_ROW_SPLIT))
            {
                // if not set,  table **may** be forwarded to next page
                table.KeepTogether = false;
                // next two properties keep <tr> together if possible
                table.SplitRows = true;
                table.SplitLate = true;
            }
            return new List<IElement>() { table };
        }
    }
