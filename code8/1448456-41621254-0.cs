    [assembly: ExportRenderer(typeof(MasterDetailPage), typeof(CustomMasterDetailRenderer))]
    namespace Your.Name.Space
    {
        public class CustomMasterDetailRenderer : MasterDetailPageRenderer
        {
            public override void AddView(Android.Views.View child)
            {
                child.GetType().GetRuntimeProperty("TopPadding").SetValue(child, 0);
                var padding = child.GetType().GetRuntimeProperty("TopPadding").GetValue(child);
    
                base.AddView(child);
            }
        }
    }
