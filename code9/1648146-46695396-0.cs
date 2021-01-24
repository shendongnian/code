    public static class ObjectExtensions
    {
        public static IDictionary<string, object> ToDictionary(this object value)
        {
            return TypeDescriptor.GetProperties(value.GetType()).Cast<PropertyDescriptor>().ToDictionary(property => property.Name, property => property.GetValue(value));
        }
    }
    [Test]
    public void TestDictionary()
    {
    	var param = new TestClass { Bar = "Bar", Foo = "Foo" }.ToDictionary();
    	param.Add("Id", 99);
    
    	using (
    		var conn = new SqlConnection(@"Data Source=.\sqlexpress;Integrated Security=true; Initial Catalog=foo"))
    	{
    		var result = conn.Query("select Foo = @Foo, Id = @Id", param).First();
    		Assert.That(result.Id, Is.EqualTo(99));
    	}
    }
