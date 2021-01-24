    public class HtmlNode : Node
    {
        protected override string ToText()
        {
            base.ToText(); // Will not compile: Cannot call abstract base member
        }
    }
