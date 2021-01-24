    using System.Linq.Expressions; // include this with your usings at the top of the file
	bool insertDocument(T content, Expression<Func<T, string>> textField)
	{
		string text = textField.Compile().Invoke(obj);
		return client.search(text);
	}
