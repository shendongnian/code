    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Design;
    using System.Linq;
    using System.Reflection;
    using System.Windows.Forms;
    using System.Windows.Forms.Design;
    
    namespace PropertyGridDataBindingGlyph
    {
        public class ExPropertyGrid : PropertyGrid
        {
            Bitmap dataBitmap;
            public ExPropertyGrid()
            {
                dataBitmap = new Bitmap(typeof(ControlDesigner).Assembly
                     .GetManifestResourceStream("System.Windows.Forms.Design.BoundProperty.bmp"));
                dataBitmap.MakeTransparent();
            }
            protected override void OnSelectedObjectsChanged(EventArgs e)
            {
                base.OnSelectedObjectsChanged(e);
                this.BeginInvoke(new Action(() => { ShowGlyph(); }));
            }
            protected override void OnPropertySortChanged(EventArgs e)
            {
                base.OnPropertySortChanged(e);
                this.BeginInvoke(new Action(() => { ShowGlyph(); }));
            }
            private void ShowGlyph()
            {
                var grid = this.Controls[2];
                var field = grid.GetType().GetField("allGridEntries",
                System.Reflection.BindingFlags.NonPublic |
                System.Reflection.BindingFlags.Instance | BindingFlags.FlattenHierarchy);
                var value = field.GetValue(grid);
                if (value == null)
                    return;
                var entries = (value as IEnumerable).Cast<GridItem>().ToList();
                if (this.SelectedObject is Control)
                {
                    ((Control)this.SelectedObject).DataBindings.Cast<Binding>()
                        .ToList().ForEach(binding =>
                        {
                            var item = entries.Where(x => x.PropertyDescriptor?.Name == binding.PropertyName).FirstOrDefault();
                            var pvSvcField = item.GetType().GetField("pvSvc", BindingFlags.NonPublic |
                                BindingFlags.Instance | BindingFlags.FlattenHierarchy);
                            IPropertyValueUIService pvSvc = new PropertyValueUIService();
                            pvSvc.AddPropertyValueUIHandler((context, propDesc, valueUIItemList) =>
                            {
                                valueUIItemList.Add(new PropertyValueUIItem(dataBitmap, (ctx, desc, invokedItem) => { }, GetToolTip(binding)));
                            });
                            pvSvcField.SetValue(item, pvSvc);
                        });
                }
            }
            private static string GetToolTip(Binding binding)
            {
                var value = "";
                if (binding.DataSource is ITypedList)
                    value = ((ITypedList)binding.DataSource).GetListName(new PropertyDescriptor[] { });
                else if (binding.DataSource is Control)
                    value = ((Control)binding.DataSource).Name;
                else if (binding.DataSource is Component)
                    value = ((Component)binding.DataSource).Site?.Name;
    
                if (string.IsNullOrEmpty(value))
                    value = "(List)";
                return value + " - " + binding.BindingMemberInfo.BindingMember;
            }
        }
    }
