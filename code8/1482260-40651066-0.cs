    public enum PublicData : int
    {
	    CardNo = 0,
	    CardName = 1,
	    Address = 2,
    }
    public class PublicdataCollection
    {
	    private readonly string[] _inner;
	    public string this[PublicData index]
	    {
		    get { return _inner[(int)index]; }
		    set { _inner[(int) index] = value; }
	    }
	    public PublicdataCollection(int count)
	    {
		    _inner = new string[count];
	    }
    }
