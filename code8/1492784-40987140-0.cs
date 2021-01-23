	public abstract class AutoEncryptorBase<T>
	{
		protected T _value;
	}
	
	public class AutoEncryptor<T> : AutoEncryptorBase<T?> where T : struct
	{
	}
	
	public class TextAutoEncryptor : AutoEncryptorBase<string>
	{
	}
	
