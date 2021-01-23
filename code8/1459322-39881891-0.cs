    public class SubInneritem
    {
    	public String itemid { get; set; }
    }
    public class Inneritem
    {
    	public List<SubInneritem>  SubInneritems { get; set; }
    }
    public class Outeritem
    {
    	public List<Inneritem> inneritems { get; set; }
    }
    
    public class RootValue
    {
    	public List<Outeritem> outeritems { get; set; }
    }
    
    [TestMethod]
    public void SerializeAndDeserializeTest()
    {
    	var expected = "{\"outeritems\":[{\"inneritems\":[{\"SubInneritems\":[{\"itemid\":\"1\"},{\"itemid\":\"2\"}]}]}]}";
    	var rootValue = new RootValue
    	{
    		outeritems = new List<Outeritem>
    		{
    			new Outeritem
    			{
    				inneritems = new List<Inneritem> { new Inneritem
    				{
    					SubInneritems = new List<SubInneritem>
    					{
    						new SubInneritem {itemid = "1"},new SubInneritem {itemid = "2"}
    					}
    				} }
    			}
    		}
    	};
    
    	var actual = JsonConvert.SerializeObject(rootValue);
    	Assert.AreEqual(expected, actual);
    }
