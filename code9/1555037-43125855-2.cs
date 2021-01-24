    For instance, the following dictionary will always serialize its keys literally, without renaming, even if [`CamelCasePropertyNamesContractResolver`](http://www.newtonsoft.com/json/help/html/T_Newtonsoft_Json_Serialization_CamelCasePropertyNamesContractResolver.htm) is in use:
        <JsonDictionary(NamingStrategyType := GetType(LiteralKeyDictionaryNamingStrategy))> _
        Public Class LiteralKeyDictionary(Of TValue)
        	Inherits Dictionary(Of String, TValue)
        End Class
        
        Public Class LiteralKeyDictionaryNamingStrategy
        	Inherits DefaultNamingStrategy
        
        	Public Sub New()
        		ProcessDictionaryKeys = False
        	End Sub
        End Class
