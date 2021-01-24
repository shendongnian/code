    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Drawing.Design;
    
    namespace PropertyGridDataBindingGlyph
    {
        public class PropertyValueUIService : IPropertyValueUIService
        {
            private PropertyValueUIHandler handler;
            private ArrayList items;
    
            public event EventHandler PropertyUIValueItemsChanged;
            public void NotifyPropertyValueUIItemsChanged()
            {
                PropertyUIValueItemsChanged?.Invoke(this, EventArgs.Empty);
            }
            public void AddPropertyValueUIHandler(PropertyValueUIHandler newHandler)
            {
                handler += newHandler ?? throw new ArgumentNullException("newHandler");
            }
            public PropertyValueUIItem[] GetPropertyUIValueItems(ITypeDescriptorContext context, PropertyDescriptor propDesc)
            {
                if (propDesc == null)
                    throw new ArgumentNullException("propDesc");
                if (this.handler == null)
                    return new PropertyValueUIItem[0];
                lock (this)
                {
                    if (this.items == null)
                        this.items = new ArrayList();
                    this.handler(context, propDesc, this.items);
                    int count = this.items.Count;
                    if (count > 0)
                    {
                        PropertyValueUIItem[] propertyValueUiItemArray = new PropertyValueUIItem[count];
                        this.items.CopyTo((Array)propertyValueUiItemArray, 0);
                        this.items.Clear();
                        return propertyValueUiItemArray;
                    }
                }
                return null;
            }
            public void RemovePropertyValueUIHandler(PropertyValueUIHandler newHandler)
            {
                handler -= newHandler ?? throw new ArgumentNullException("newHandler");
    
            }
        }
    }
