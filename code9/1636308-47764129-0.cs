    using System;
    using System.Security.Cryptography;
    using System.Text;
    
    public class Program
    {
    	public static void Main()
    	{
    		Console.WriteLine(SHA256HexHashString("{\"CorporateID\":\"BCAAPI2016\",\"SourceAccountNumber\":\"0201245680\",\"TransactionID\":\"00000001\",\"TransactionDate\":\"2017-09-13\",\"ReferenceID\":\"refID\",\"CurrencyCode\":\"IDR\",\"Amount\":\"10000\",\"BeneficiaryAccountNumber\":\"0201245681\",\"Remark1\":\"Transfer Test\",\"Remark2\":\"Online Transfer\"}"));
    	}
    
    	private static string ToHex(byte[] bytes, bool upperCase)
    	{
    		StringBuilder result = new StringBuilder(bytes.Length * 2);
    		for (int i = 0; i < bytes.Length; i++)
    			result.Append(bytes[i].ToString(upperCase ? "X2" : "x2"));
    		return result.ToString();
    	}
    
    	private static string SHA256HexHashString(string StringIn)
    	{
    		string hashString;
    		using (var sha256 = SHA256Managed.Create())
    		{
    			var hash = sha256.ComputeHash(Encoding.Default.GetBytes(StringIn));
    			hashString = ToHex(hash, false);
    		}
    
    		return hashString;
    	}
    }
