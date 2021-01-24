C#
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
C#
public static class Extentions
{
	public static bool IsValidJson(this string value)
	{
		try
		{
			var json = JContainer.Parse(value);
			return true;
		}
		catch
		{
			return false;
		}
	}
}
