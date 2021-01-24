    public class Item
    {
    	private string _text;
    	private string[] _array;
    	public object Value => (object)_text ?? (object)_array;
    	
    	public Item(string text) { _text = text; }
    	public Item(string[] array) { _array = array; }
    }
