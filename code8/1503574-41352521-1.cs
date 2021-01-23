	/// <summary>
	/// Read json from string into class with DataContract properties
	/// </summary>
	/// <typeparam name="T">DataContract class</typeparam>
	/// <param name="json">JSON as a string</param>
	/// <param name="encoding">Text encoding format (example Encoding.UTF8)</param>
	/// <param name="settings">DataContract settings (can be used to set datetime format, etc)</param>
	/// <returns>DataContract class populated with serialized json data</returns>
	public static T FromString<T>( string json, Encoding encoding, DataContractJsonSerializerSettings settings ) where T : class {
		T result = null;
		try {
			DataContractJsonSerializer ser = new DataContractJsonSerializer( typeof( T ), settings );
			using ( Stream s = new MemoryStream( ( encoding ?? Encoding.UTF8 ).GetBytes( json ?? "" ) ) ) {
				result = ser.ReadObject( s ) as T;
			}
		} catch ( SerializationException se ) {
			Debug.WriteLine( se.Message );
		} catch ( Exception e ) {
			Debug.WriteLine( e.Message );
		}
		return result;
	}
