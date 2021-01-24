    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="current">Dont throw in IENumerables !</param>
    /// <returns></returns>
    public static T Foo<T>(this Object current) where T : class, new() {
    		if (current is IEnumerable) {
    			throw new NotSupportedException($"Type  {current.GetType()} is not supported!");
    		}
    		//...
    }
