    public void Initialize(RulleSet initRule)
        {
            var initializableObject = this.GetType().GetProperty(initRule.ObjectName).GetValue(this,null);
            //If object not initialized, we need to create it
            if (initializableObject == null)
            {
                initializableObject =
                    Activator.CreateInstance(this.GetType().GetProperty(initRule.ObjectName).PropertyType);
                PropertyInfo propertyInfo = this.GetType().GetProperty(initRule.ObjectName);
                propertyInfo.SetValue(this, Convert.ChangeType(initializableObject, propertyInfo.PropertyType), null);
            }
            //If we have object, we created it or it already axist doesn't matter we set property
            if (initializableObject != null)
            {
                var initializableProperty =
                    initializableObject.GetType().GetProperty(initRule.PropertyName).GetValue(initializableObject, null);
                initializableProperty = Activator.CreateInstance(initializableObject.GetType().GetProperty(initRule.PropertyName).PropertyType);
                PropertyInfo propertyInfo = initializableObject.GetType().GetProperty(initRule.PropertyName);
                propertyInfo.SetValue(initializableObject, Convert.ChangeType(initializableProperty, propertyInfo.PropertyType), null);
            }
        }
