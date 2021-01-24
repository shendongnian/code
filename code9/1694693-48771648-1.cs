    public class AccessibilityTagWorkerFactory : DefaultTagWorkerFactory
    {
    public override ITagWorker GetCustomTagWorker(IElementNode tag, ProcessorContext context)
        {
            bool hasClass = false;
            foreach (var attribute in tag.GetAttributes())
            {
                if (attribute.GetKey() == "class")
                {
                    hasClass = true;
                }
            }
            if (hasClass && tag.GetAttribute(AttributeConstants.CLASS).Contains("make-h1"))
            {
                return new HRoleSpanTagWorker(tag, context, StandardRoles.H1);
            }
            if (hasClass && tag.GetAttribute(AttributeConstants.CLASS).Contains("make-h2"))
            {
                return new HRoleSpanTagWorker(tag, context, StandardRoles.H2);
            }
            if (hasClass && tag.GetAttribute(AttributeConstants.CLASS).Contains("make-table-div"))
            {
                return new DivRoleTableTagWorker(tag, context);
            }
            return base.GetCustomTagWorker(tag, context);
        }
    }
