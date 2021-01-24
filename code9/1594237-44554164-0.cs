    public class MyIntermediaryDict
    {
	    [MessagePackKnownCollectionItemTypeAttribute( "MyAbstractBase", typeof( MyImpl ) )]
    	public Dictionary<int, MyAbstractBase> intermediary_dict;
};
    class MySerializableClass
    {
	    public Dictionary<int, MyIntermediaryDict> myDict;
    }
