	using UnityEngine;
	using System.Collections.Generic;
	using System.Xml;
	using System.Xml.Serialization;
	using System.IO;
	using System;
	public struct Connectors {
		[XmlElement("name")]
		public string connectorName;
		[XmlElement("count")]
		public int connectorCount;
	}
	public struct Montage
	{
		[XmlElement("mainObject")]
		[XmlElement("name")]
		public string name;
		[XmlElement("connectors")]
		[XmlElement("connector")]
		public List<Connectors> connectors;
	}
	[XmlRoot("MontageConfig")]
	public class ConfigScene
	{
		[XmlArray("Parameters")]
		[XmlArrayItem("Parameter")]
		public List<Montage> questions = new List<Montage>();
		public static ConfigScene Load(string path)
		{
			try
			{
				XmlSerializer serializer = new XmlSerializer(typeof(ConfigScene));
				using (FileStream stream = new FileStream(path, FileMode.Open))
				{
					//Debug.Log(serializer.Deserialize(stream) as ConfigScene);
					return serializer.Deserialize(stream) as ConfigScene;
				}
			}
			catch (Exception e)
			{
				UnityEngine.Debug.LogError("Exception loading config file: " + e);
				return null;
			}
		}
	}
