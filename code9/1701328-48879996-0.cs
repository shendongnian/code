	using System.Configuration;
	namespace SerialApp
	{
		public class JobSection : ConfigurationSection
		{
			[ConfigurationProperty("jobs", IsDefaultCollection = true)]
			public JobCollection Jobs
			{
				get
				{
					JobCollection hostCollection = (JobCollection)base["jobs"];
					return hostCollection;
				}
			}
		}
		public class JobCollection : ConfigurationElementCollection
		{
			public new JobConfigElement this[string name]
			{
				get
				{
					if (IndexOf(name) < 0) return null;
					return (JobConfigElement)BaseGet(name);
				}
			}
			public JobConfigElement this[int index]
			{
				get { return (JobConfigElement)BaseGet(index); }
			}
			public int IndexOf(string name)
			{
				name = name.ToLower();
				for (int idx = 0; idx < base.Count; idx++)
				{
					if (this[idx].Name.ToLower() == name)
						return idx;
				}
				return -1;
			}
			public override ConfigurationElementCollectionType CollectionType
			{
				get { return ConfigurationElementCollectionType.BasicMap; }
			}
			protected override ConfigurationElement CreateNewElement()
			{
				return new JobConfigElement();
			}
			protected override object GetElementKey(ConfigurationElement element)
			{
				return ((JobConfigElement)element).Name;
			}
			protected override string ElementName
			{
				get { return "job"; }
			}
		}
		public class JobConfigElement : ConfigurationElement
		{
			public JobConfigElement() { }
			[ConfigurationProperty("name", DefaultValue = "Name")]
			public string Name
			{
				get { return (string)this["name"]; }
				set { this["name"] = value; }
			}
			[ConfigurationProperty("sftpName", DefaultValue = "sftp")]
			public string SftpName
			{
				get { return (string)this["sftpName"]; }
				set { this["sftpName"] = value; }
			}
			[ConfigurationProperty("jobName", DefaultValue = "jobName")]
			public string JobName
			{
				get { return (string)this["jobName"]; }
				set { this["jobName"] = value; }
			}
		}
	}
	
