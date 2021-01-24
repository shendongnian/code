        private async void btnClear_Clicked(object sender, EventArgs e)
        {
            MyData data = (MyData)this.BindingContext;
            await ClearProperties(data);
        }
        
        private async Task ClearProperties<T>(T instance)
        {
            await ClearProperties(typeof(T), instance);
        }
        private async Task ClearProperties(Type classType, object instance)
        {
            foreach (PropertyInfo property in classType.GetRuntimeProperties()) 
            {
                object value = null;
                try
                {
                    value = property.GetValue(instance, null);
                }
                catch (Exception)
                {
                    //Debug.WriteLine(ex.Message);
                }
                if (value != null && property.PropertyType != typeof(String))
                    await ClearProperties(property.PropertyType, value);
                else if (value != null && (String)value != "")
                    property.SetValue(instance, null);
            }
        }
