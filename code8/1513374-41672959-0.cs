    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;
    namespace HashSetSerializationTest
    {
	class Program
	{
		static void Main(string[] args)
		{
			var set = new HashSet<int>();
			set.Add(5);
			set.Add(12);
			set.Add(-50006);
			Console.WriteLine("Enter the file-path:");
			string path = Console.ReadLine();
			Serialize(path, set);
			HashSet<int> deserializedSet = (HashSet<int>)Deserialize(path);
			foreach (int number in deserializedSet)
			{
				Console.WriteLine($"{number} is in original set: {set.Contains(number)}");
			}
			Console.ReadLine();
		}
        
		static void Serialize(string path, object theObjectToSave)
		{
			using (Stream stream = File.Create(path))
			{
				var formatter = new BinaryFormatter();
				formatter.Serialize(stream, theObjectToSave);
			}
		}
		static object Deserialize(string path)
		{
			using (Stream stream = File.OpenRead(path))
			{
				var formatter = new BinaryFormatter();
				return formatter.Deserialize(stream);
			}
		}
	}
    }
