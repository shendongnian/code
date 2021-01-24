    [assembly: ExportRenderer(typeof(MasterDetailPage), typeof(NoSpaceMasterDetailPageRenderer))]
    
    namespace Droid.Renderers
    {
        public class NoSpaceMasterDetailPageRenderer : MasterDetailPageRenderer
        {
            /// <summary>
            /// When adding a view, tweak the top padding if necessary.
            /// According to:
            /// https://github.com/xamarin/Xamarin.Forms/blob/589adbd3ef145ec85f9fe64eda008251c1cdb745/Xamarin.Forms.Platform.Android/AppCompat/MasterDetailPageRenderer.cs
            /// The TopPadding is always set for the detail. This works fine when the master detail is shown normally, but
            /// if it is inside a navigation page (such as the inspection view) then you get extra unwanted padding.
            /// The 'fix' is to set the top padding to 0 for the detail, only of course the types and fields are hidden from us...
            /// </summary>
            /// <param name="child">Child.</param>
            public override void AddView(Android.Views.View child)
            {
                try
                {
                    var isMasterField = child.GetType().GetField("_isMaster", BindingFlags.NonPublic | BindingFlags.Instance);
                    if (isMasterField == null) return;
    
                    var isMaster = isMasterField.GetValue(child);
                    if ((bool)isMaster) return;
    
                    var parentField = child.GetType().GetField("_parent", BindingFlags.NonPublic | BindingFlags.Instance);
                    if (parentField == null) return;
    
                    var parent = parentField.GetValue(child) as MasterDetailPage;
                    if (parent == null || !(parent.Parent is NavigationPage)) return;
    
                    var topPaddingProperty = child.GetType().GetProperty("TopPadding", BindingFlags.Public | BindingFlags.Instance);
                    if (topPaddingProperty != null)
                        topPaddingProperty.SetValue(child, 0);
                }
                finally
                {
                    base.AddView(child);
                }
            }
        }
    }
