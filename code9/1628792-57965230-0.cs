csharp
public abstract class Model<TSelf>
	where TSelf : Model<TSelf>
{
	public ICollection<TSelf> Items { get; }
	protected Model(TSelf self, ICollection<TSelf> items)
	{
		if ((self == null) || (items == null))
		{
			throw new ArgumentNullException();
		}
		if (self != this)
		{
			throw new ArgumentException();
		}
		Items = items;
		Items.Add(self);
	}
}
----------
**Derived class implementation:**
csharp
public sealed class ModelImplementation
	: Model<ModelImplementation>
{
	private ModelImplementation(ModelImplementation self)
		: base(self, new List<ModelImplementation>()) { }
}
----------
The bread and butter of this technique is the `ModelFactory` class, which takes an uninitialized object and manually calls the appropriate constructor on it. Support for additional constructor parameters can be implemented by modifying the `GetConstructor` and `Invoke` calls.
You should call `ModelFactory.Create<ModelImplementation>()` to get a new `ModelImplementation` in lieu of the `new` keyword.
**Factory class implementation:**
csharp
public static class ModelFactory
{
	public static Model<TSelf> Create<TSelf>()
		where TSelf : Model<TSelf>
	{
		var result = FormatterServices
			.GetUninitializedObject(typeof(TSelf));
		result.GetType()
			.GetConstructor(
				BindingFlags.Instance | BindingFlags.NonPublic,
				null,
				new[] { typeof(TSelf) },
				null)
			.Invoke(
				result,
				new[] { result });
		return (TSelf)result;
	}
}
