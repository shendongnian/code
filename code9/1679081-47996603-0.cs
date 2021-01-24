    public class Form : Block
    {
        // public override void Initialize...
        public override void Render(Context context, TextWriter writer)
        {
            context.Stack(() =>
            {
                context["form_obj"] = new FormObject();
                result.Write("<form>");
                base.Render(context, result);
                result.Write("</form>");
            }
        }
    }
