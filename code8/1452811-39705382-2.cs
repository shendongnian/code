	public class VBScriptEvaluator
	{
		public static dynamic Evaluate(string key, string script, IDictionary<string, object> parameterValuePair = null)
		{
			try
			{
				using (ScriptEngine engine = new ScriptEngine(ScriptEngine.VBScriptLanguage))
				{
					List<object> parameters = new List<object>() { "ADMIN" };
					string extraParameters = string.Empty;
					if (parameterValuePair != null && parameterValuePair.Count > 0)
					{
						extraParameters = "," + string.Join(",", parameterValuePair.Select(e => e.Key));
						foreach (var para in parameterValuePair)
							parameters.Add(para.Value);
					}
					string parsedScript = string.Format(@"Function {0}(NecUserProfile {2})
	{1}
	End Function", key, script, extraParameters);
					ParsedScript parsed = engine.Parse(parsedScript);
					dynamic value = parsed.CallMethod(key, parameters.ToArray());
					return (value != null) ? value.ToString() : string.Empty;
				}
			}
			catch (Exception ex)
			{
				throw;
			}
		}
	}
