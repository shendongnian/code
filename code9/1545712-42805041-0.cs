    private void ChangeVisibilityBasedOnMode( ref object[] v) {
    	if (matchSomeRunTimeCondition) {
    		List<string> PropertiesToHide = new List<string> {
    			"FormID",
    			"jrxml_Path",
    		};
    		foreach (var vObject in v) {
    			var properties = GetProperties(vObject);
    			foreach (var p in properties) {
    				foreach (string hideProperty in PropertiesToHide ) {
    					if (p.Name.ToLower() == hideProperty.ToLower()) {
    						setBrowsableProperty(hideProperty, false, vObject);
    					}
    				}
    			}
    		}
    	}
    }
    private void setBrowsableProperty(string strPropertyName, bool bIsBrowsable, object vObject) {
    	try {
    		PropertyDescriptor theDescriptor = TypeDescriptor.GetProperties(vObject.GetType())[strPropertyName];
    		BrowsableAttribute theDescriptorBrowsableAttribute = (BrowsableAttribute)theDescriptor.Attributes[typeof(BrowsableAttribute)];
    		FieldInfo isBrowsable = theDescriptorBrowsableAttribute.GetType().GetField("Browsable", BindingFlags.IgnoreCase | BindingFlags.NonPublic | BindingFlags.Instance);
    		isBrowsable.SetValue(theDescriptorBrowsableAttribute, bIsBrowsable);
    	} catch (Exception) { }
    }
