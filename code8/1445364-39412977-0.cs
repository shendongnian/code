	public static KeyValuePair<K, V> After<K, V>( this Dictionary<K, V> dictionary, K key ) {
		Int32 position = dictionary.Keys.ToList().IndexOf( key );
		if( position == -1 )
			throw new ArgumentException( "No match.", "key" );
		position++;
		if( position >= dictionary.Count )
			position = 0;
		K k = dictionary.Keys.ToList()[ position ];
		V v = dictionary.Values.ToList()[ position ];
		return new KeyValuePair<K, V>( k, v );
	}
	public static KeyValuePair<K, V> After<K, V>( this Dictionary<K, V> dictionary, V value ) {
		Int32 position = dictionary.Values.ToList().IndexOf( value );
		if( position == -1 )
			throw new ArgumentException( "No match.", "value" );
		position++;
		if( position >= dictionary.Count )
			position = 0;
		K k = dictionary.Keys.ToList()[ position ];
		V v = dictionary.Values.ToList()[ position ];
		return new KeyValuePair<K, V>( k, v );
	}
	public static KeyValuePair<K, V> Before<K, V>( this Dictionary<K, V> dictionary, K key ) {
		Int32 position = dictionary.Keys.ToList().IndexOf( key );
		if( position == -1 )
			throw new ArgumentException( "No match.", "key" );
		position--;
		if( position < 0 )
			position = dictionary.Count - 1;
		K k = dictionary.Keys.ToList()[ position ];
		V v = dictionary.Values.ToList()[ position ];
		return new KeyValuePair<K, V>( k, v );
	}
	public static KeyValuePair<K, V> Before<K, V>( this Dictionary<K, V> dictionary, V value ) {
		Int32 position = dictionary.Values.ToList().IndexOf( value );
		if( position == -1 )
			throw new ArgumentException( "No match.", "value" );
		position--;
		if( position < 0 )
			position = dictionary.Count - 1;
		K k = dictionary.Keys.ToList()[ position ];
		V v = dictionary.Values.ToList()[ position ];
		return new KeyValuePair<K, V>( k, v );
	}
