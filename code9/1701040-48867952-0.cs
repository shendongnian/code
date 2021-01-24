    public static IEnumerable<Type> Traverse(Type enclosingType)
	{
		if (enclosingType.IsPrimitive) // string is not a primitive... think about this condition again
		{
			yield return enclosingType;
		}
		else
		{
			foreach (var type in enclosingType.GetFields().SelectMany(f => Traverse(f.FieldType)))
			{
				yield return type;
			}
		}
	}
