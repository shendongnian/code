	public class GenericDataSet<T> where T : class, new()
	{
	    public T KeepElementsData()
	    {
	        var item = new T();
	        //Propertys durchlaufen
	        foreach (var propertyInfo in item.GetType().GetProperties())
	        {
	            item.GetType().GetProperty(propertyInfo.Name).SetValue(item, "TestData");  //this works
	        }
	        //Fields durchlaufen
	        foreach (var fieldInfo in item.GetType().GetFields())
	        {
	            object fieldObject = Activator.CreateInstance(fieldInfo.FieldType);
	            foreach (var fieldProperty in fieldInfo.FieldType.GetProperties())
	            {
	                fieldProperty.SetValue(fieldObject, "TestData not work", null); // this doesent work
	            }
	            fieldInfo.SetValue(item, fieldObject);
	        }
	        return item;
	    }
	}
