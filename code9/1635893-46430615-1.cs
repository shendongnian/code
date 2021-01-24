    private void ProcessIList(IList list, XElement element) {
        ProcessIEnumerable(list, element);
    }
    private void ProcessISerializeList(ISerializeList list, XElement element) {
        ProcessIEnumerable(list, element);
        Map(element, list);
    }
    private void ProcessIEnumerable(IEnumerable list, XElement element) {
		var itemTypeName = "";
		foreach (var item in list) {
			if (itemTypeName == "") {
				var type = item.GetType();
				var setting = type.GetAttribute<SerializeAsAttribute>();
				itemTypeName = setting != null && setting.Name.HasValue() ? setting.Name : type.Name;
			}
			var instance = new XElement(itemTypeName.AsNamespaced(Namespace));
			Map(instance, item);
			element.Add(instance);
		}
	}
