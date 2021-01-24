    'public class TwoLineLabelRenderer : LabelRenderer
    {
    protected override void OnElementChanged(ElementChangedEventArgs e)
    {
    base.OnElementChanged(e);
    
                    if (Control != null)
                    {
                        Control.LayoutChange += (s, args) =>
                        {
                            Control.Ellipsize = TextUtils.TruncateAt.End;
                            Control.SetMaxLines(2);
                        };
                    }
                }
            }
