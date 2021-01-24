    using System;
    using System.IO;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using System.Diagnostics;
    using System.Xml;
    using System.Xml.Linq;
    using Microsoft.CSharp;
    using System.CodeDom.Compiler;
    
    public static class Namespaces
    {
    	public const string BaseNamespace = "http://www.Question45412824.com";
    	public const string ProjectNamespace = BaseNamespace + "/Project";
    	public const string ExtensionNamespace = BaseNamespace + "/Extension";
    }
    
    // common base class
    [DataContract(Namespace = Namespaces.ProjectNamespace)]
    public class ModuleData : IExtensibleDataObject
    {
    	public ExtensionDataObject ExtensionData { get; set; }
    }
    
    [DataContract(Namespace = Namespaces.ProjectNamespace)]
    public class AData : ModuleData
    {
    	[DataMember]
    	public string A { get; set; }
    }
    
    [DataContract(Namespace = Namespaces.ProjectNamespace)]
    public class BData : ModuleData
    {
    	[DataMember]
    	public string B { get; set; }
    }
    
    [DataContract(Namespace = Namespaces.ProjectNamespace)]
    [KnownType(typeof(AData))]
    [KnownType(typeof(BData))]
    public class Project
    {
    	[DataMember]
    	public List<ModuleData> Data { get; set; }
    }
    
    [DataContract(Namespace = Namespaces.ProjectNamespace)]
    internal class CSubData : ModuleData
    {
    	[DataMember]
    	public string Name { get; set; }
    }
    
    
    [DataContract(Namespace = Namespaces.ExtensionNamespace)]
    public class CData : ModuleData
    {
    	[DataMember]
    	public ModuleData C { get; set; }
    }
    
    class Program
    {
    	static void Main(string[] args)
    	{
    		new TestClass().Test();
    	}
    }
    
    class TestClass
    {
    	public virtual void Test()
    	{
    		// new project object
    		var project1 = new Project()
    		{
    			Data = new List<ModuleData>()
    				{
    					 new AData() { A = "A" },
    					 new BData() { B = "B" },
    					 new CData() { C = new CSubData() { Name = "C" } }
    				}
    		};
    
    		// serialization; make CData explicitly known to simulate presence of "module C"
    		var extraTypes = new[] { typeof(CData), typeof(CSubData) };
    
    		ConsoleAndDebug.WriteLine("\n== Serialization with all types known ==");
    		var xml = project1.SerializeXml(extraTypes);
    		ConsoleAndDebug.WriteLine(xml);
    
    		ConsoleAndDebug.WriteLine("\n== Deserialization and subsequent serialization WITH generic resolver and unknown types ==");
    		TestDeserialize(project1, xml, new GenericDataContractResolver());
    
    		ConsoleAndDebug.WriteLine("\n== Deserialization and subsequent serialization WITHOUT generic resolver and unknown types ==");
    		try
    		{
    			// Demonstrate that the XML cannot be deserialized without the generic resolver.
    			TestDeserialize(project1, xml, new Type[0]);
    			Assert.IsTrue(false);
    		}
    		catch (AssertionFailedException ex)
    		{
    			Console.WriteLine("Caught unexpected exception: ");
    			Console.WriteLine(ex);
    			throw;
    		}
    		catch (Exception ex)
    		{
    			ConsoleAndDebug.WriteLine(string.Format("Caught expected exception: {0}", ex.Message));
    		}
    	}
    
    	public void TestDeserialize<TProject>(TProject project, string xml, Type[] extraTypes)
    	{
    		TestDeserialize<TProject>(xml, extraTypes);
    	}
    
    	public void TestDeserialize<TProject>(string xml, Type[] extraTypes)
    	{
    		var project2 = xml.DeserializeXml<TProject>(extraTypes);
    
    		var xml2 = project2.SerializeXml(extraTypes);
    
    		ConsoleAndDebug.WriteLine(xml2);
    
    		// Assert that the incoming and re-serialized XML are equivalent (no data was lost).
    		Assert.IsTrue(XNode.DeepEquals(XElement.Parse(xml), XElement.Parse(xml2)));
    	}
    
    	public void TestDeserialize<TProject>(TProject project, string xml, DataContractResolver resolver)
    	{
    		TestDeserialize<TProject>(xml, resolver);
    	}
    
    	public void TestDeserialize<TProject>(string xml, DataContractResolver resolver)
    	{
    		var project2 = xml.DeserializeXml<TProject>(resolver);
    
    		var xml2 = project2.SerializeXml(resolver);
    
    		ConsoleAndDebug.WriteLine(xml2);
    
    		// Assert that the incoming and re-serialized XML are equivalent (no data was lost).
    		Assert.IsTrue(XNode.DeepEquals(XElement.Parse(xml), XElement.Parse(xml2)));
    	}
    }
    
    public static partial class DataContractSerializerHelper
    {
    	public static string SerializeXml<T>(this T obj, Type[] extraTypes)
    	{
    		return obj.SerializeXml(new DataContractSerializer(obj == null ? typeof(T) : obj.GetType(), extraTypes));
    	}
    
    	public static string SerializeXml<T>(this T obj, DataContractResolver resolver)
    	{
    		return obj.SerializeXml(new DataContractSerializer(obj == null ? typeof(T) : obj.GetType(), null, int.MaxValue, false, false, null, resolver));
    	}
    
    	public static string SerializeXml<T>(this T obj, DataContractSerializer serializer)
    	{
    		serializer = serializer ?? new DataContractSerializer(obj == null ? typeof(T) : obj.GetType());
    		using (var textWriter = new StringWriter())
    		{
    			var settings = new XmlWriterSettings { Indent = true };
    			using (var xmlWriter = XmlWriter.Create(textWriter, settings))
    			{
    				serializer.WriteObject(xmlWriter, obj);
    			}
    			return textWriter.ToString();
    		}
    	}
    
    	public static T DeserializeXml<T>(this string xml, DataContractResolver resolver)
    	{
    		return xml.DeserializeXml<T>(new DataContractSerializer(typeof(T), null, int.MaxValue, false, false, null, resolver));
    	}
    
    	public static T DeserializeXml<T>(this string xml, Type[] extraTypes)
    	{
    		return xml.DeserializeXml<T>(new DataContractSerializer(typeof(T), extraTypes));
    	}
    
    	public static T DeserializeXml<T>(this string xml, DataContractSerializer serializer)
    	{
    		using (var textReader = new StringReader(xml ?? ""))
    		using (var xmlReader = XmlReader.Create(textReader))
    		{
    			return (T)(serializer ?? new DataContractSerializer(typeof(T))).ReadObject(xmlReader);
    		}
    	}
    }
    
    public static class ConsoleAndDebug
    {
    	public static void WriteLine(object s)
    	{
    		Console.WriteLine(s);
    		Debug.WriteLine(s);
    	}
    }
    
    public class AssertionFailedException : System.Exception
    {
    	public AssertionFailedException() : base() { }
    
    	public AssertionFailedException(string s) : base(s) { }
    }
    
    public static class Assert
    {
    	public static void IsTrue(bool value)
    	{
    		if (value == false)
    			throw new AssertionFailedException("failed");
    	}
    }
    
    class GenericDataContractResolver : DataContractResolver
    {
    	private static readonly Random random_ = new Random();
    	private static readonly Dictionary<Tuple<string, string>, Type> toType_ = new Dictionary<Tuple<string, string>, Type>();
     	private static readonly Dictionary<Type, Tuple<string, string>> fromType_ = new Dictionary<Type, Tuple<string, string>>();
    
    	private Type CreateDummyType(string typeName, string typeNamespace)
    	{
    		var className = $"DummyClass_{random_.Next()}";
    		var code = $"[System.Runtime.Serialization.DataContract(Name=\"{typeName}\", Namespace=\"{typeNamespace}\")] public class {className} : ModuleData {{}}";
    
    		using (var provider = new CSharpCodeProvider())
    		{
    			var parameters = new CompilerParameters();
    			parameters.ReferencedAssemblies.Add("System.Runtime.Serialization.dll");
    			parameters.ReferencedAssemblies.Add(GetType().Assembly.Location); // this assembly (for ModuleData)
    
    			var results = provider.CompileAssemblyFromSource(parameters, code);
    			return results.CompiledAssembly.GetType(className);
    		}
    	}
    
    	// Used at deserialization; allows users to map xsi:type name to any Type 
    	public override Type ResolveName(string typeName, string typeNamespace, Type declaredType, DataContractResolver knownTypeResolver)
    	{
    		var type = knownTypeResolver.ResolveName(typeName, typeNamespace, declaredType, null);
    
    		// resolve all unknown extension datasets; all other should be explicitly known.
    		if (type == null && declaredType == typeof(ModuleData) && typeNamespace == Namespaces.ExtensionNamespace)
    		{
    			// if we already have this type cached, then return the cached one
    			var typeNameAndNamespace = new Tuple<string, string>(typeName, typeNamespace);
    			if (toType_.TryGetValue(typeNameAndNamespace, out type))
    				return type;
    
    			// else compile the dummy type and remember it in the cache
    			type = CreateDummyType(typeName, typeNamespace);
    			toType_.Add(typeNameAndNamespace, type);
    			fromType_.Add(type, typeNameAndNamespace);
    		}
    
    		return type;
    	}
    
    	// Used at serialization; maps any Type to a new xsi:type representation
    	public override bool TryResolveType(Type type, Type declaredType, DataContractResolver knownTypeResolver, out XmlDictionaryString typeName, out XmlDictionaryString typeNamespace)
    	{
    		if (knownTypeResolver.TryResolveType(type, declaredType, null, out typeName, out typeNamespace))
    			return true; // known type
    
    		// is the type one of our cached dummies?
    		var typeNameAndNamespace = default(Tuple<string, string>);
    		if (declaredType == typeof(ModuleData) && fromType_.TryGetValue(type, out typeNameAndNamespace))
    		{
    			typeName = new XmlDictionaryString(XmlDictionary.Empty, typeNameAndNamespace.Item1, 0);
    			typeNamespace = new XmlDictionaryString(XmlDictionary.Empty, typeNameAndNamespace.Item2, 0);
    			return true; // dummy type
    		}
    
    		return false; // unknown type
    	}
    }
