public static class TestExpect
{
public static void CollectionContainsOnlyExpectedElements<T>(IEnumerable<T> collectionToTest, params Func<T, bool>[] inspectors)
{
	int expectedLength = inspectors.Length;
	T[] actual = collectionToTest.ToArray();
	int actualLength = actual.Length;
	if (actualLength != expectedLength)
		throw new CollectionException(collectionToTest, expectedLength, actualLength);
	List<Func<T, bool>> allInspectors = new List<Func<T, bool>>(inspectors);
	int index = -1;
	foreach (T elementToTest in actual)
	{
		try
		{
			index++;
			Func<T, bool> elementInspectorToRemove = null;
			foreach (Func<T, bool> elementInspector in allInspectors)
			{
				if (elementInspector.Invoke(elementToTest))
				{
					elementInspectorToRemove = elementInspector;
					break;
				}
			}
			if (elementInspectorToRemove != null)
				allInspectors.Remove(elementInspectorToRemove);
			else
				throw new CollectionException(collectionToTest, expectedLength, actualLength, index);
		}
		catch (Exception ex)
		{
			throw new CollectionException(collectionToTest, expectedLength, actualLength, index, ex);
		}
	}
}
}
The difference here is that for a collection 
 string[] collectionToTest = { "Bob", "Kate" };
Both the following lines will not produce a `CollectionException`
 TestExpect.CollectionContainsOnlyExpectedElements(collectionToTest, x => x.Equals("Bob"), x => x.Equals("Kate"));
 TestExpect.CollectionContainsOnlyExpectedElements(collectionToTest, x => x.Equals("Kate"), x => x.Equals("Bob"));
Whereas using `Assert.Collection` - Only the first of the above two lines will work as the collection of inspectors is evaluated in order. 
There is a potential performance impact using this method, but if you are only testing fairly small sized collections (as you probably will be in a unit test), you will never notice the difference.
