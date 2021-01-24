        [assembly:ExportRenderer(typeof(RoundedEditor),
        typeof(RoundedEditorRenderer))]
        namespace RoundedEditorDemo.Droid
        {
            public class RoundedEditorRenderer:EditorRenderer
            {
                protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
                {
                    base.OnElementChanged(e);
                    if (Control != null)
                    {
                        Control.Background = Xamarin.Forms.Forms.Context.GetDrawable(Resource.Drawable.RoundedEditText);
                    }
                }
            }
        }
