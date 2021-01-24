    public class TableViewWithFooterRenderer : TableViewRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<TableView> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement != null)
            {
                if (Control != null)
                {
                    //Add footer to the whole TableView
                    var lv = Control as Android.Widget.ListView;
                    var footerview = ((LayoutInflater)Context.GetSystemService(Context.LayoutInflaterService))
                        .Inflate(Resource.Layout.TableViewFooter, null, false);
                    lv.AddFooterView(footerview);
                }
            }
        }
    }
