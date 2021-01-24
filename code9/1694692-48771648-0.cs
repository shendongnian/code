    public class DivRoleTableTagWorker : TableTagWorker
    {
        public DivRoleTableTagWorker(IElementNode element, ProcessorContext context) : base(element, context)
        {
        }
        public override void ProcessEnd(IElementNode element, ProcessorContext context)
        {
            base.ProcessEnd(element, context);
            if (GetElementResult().GetType() == typeof(Table))
            {
                Table table = (Table)GetElementResult();
                table.GetAccessibilityProperties().SetRole(StandardRoles.DIV);
                for (int i = 0; i < table.GetNumberOfRows(); i++)
                {
                    for (int j = 0; j < table.GetNumberOfColumns(); j++)
                    {
                        Cell cell = table.GetCell(i, j);
                        if (cell != null)
                        {
                            cell.GetAccessibilityProperties().SetRole(StandardRoles.DIV);
                        }
                    }
                }
            }
        }
    }
