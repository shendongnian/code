        public void EnableDisableProperty(string PropertyName,bool IsReadOnly)
		{
			PropertyDescriptor _propDescriptor = TypeDescriptor.GetProperties(this.GetType())[PropertyName];
			ReadOnlyAttribute _readOnlyAttribute = (ReadOnlyAttribute)
										  _propDescriptor.Attributes[typeof(ReadOnlyAttribute)];
			FieldInfo _fieldToChange = _readOnlyAttribute.GetType().GetField("isReadOnly",
											 System.Reflection.BindingFlags.NonPublic |
											 System.Reflection.BindingFlags.Instance);
			_fieldToChange.SetValue(_readOnlyAttribute, IsReadOnly);
		}
