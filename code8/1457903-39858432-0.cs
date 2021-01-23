    public class CalculatedProperty<TComponent, TValue> : PropertyDescriptor
    {
    	private Func<TComponent, TValue> func;
    	public CalculatedProperty(string name, Func<TComponent, TValue> func)
    		: base(name, null)
    	{
    		this.func = func;
    	}
    	public override Type ComponentType { get { return typeof(TComponent); } }
    	public override bool IsReadOnly { get { return true; } }
    	public override Type PropertyType { get { return typeof(TValue); } }
    	public override bool CanResetValue(object component) { return false; }
    	public override object GetValue(object component) { return func((TComponent)component); }
    	public override void SetValue(object component, object value) { throw new InvalidOperationException(); }
    	public override bool ShouldSerializeValue(object component) { return false; }
    	public override void ResetValue(object component) { throw new InvalidOperationException(); }
    }
