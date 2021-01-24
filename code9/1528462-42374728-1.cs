    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Core.Metadata.Edm;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations.Model;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using System.Linq;
    public class IndexNameConvention : IStoreModelConvention<EntityType>
    {
    	public void Apply(EntityType item, DbModel model)
    	{
    		// Build index info, consolidating indexes with the same name
    		var indexInfo = new List<IndexInfo>();
    		foreach (var p in item.Properties)
    		{
    			foreach (var mp in p.MetadataProperties)
    			{
    				var a = mp.Value as IndexAnnotation;
    				if (a == null) continue;
    				foreach (var index in a.Indexes)
    				{
    					var info = index.Name != null ? indexInfo.FirstOrDefault(e => e.Name == index.Name) : null;
    					if (info == null)
    					{
    						info = new IndexInfo { Name = index.Name };
    						indexInfo.Add(info);
    					}
    					else
    					{
    						var other = info.Entries[0].Index;
    						if (index.IsUnique != other.IsUnique || index.IsClustered != other.IsClustered)
    							throw new Exception("Invalid index configuration.");
    					}
    					info.Entries.Add(new IndexEntry { Column = p, Annotaion = mp, Index = index });
    				}
    			}
    		}
    		if (indexInfo.Count == 0) return;
    		// Generate new name where needed
    		var entitySet = model.StoreModel.Container.EntitySets.First(es => es.ElementType == item);
    		foreach (var info in indexInfo)
    		{
    			var columns = info.Entries.OrderBy(e => e.Index.Order).Select(e => e.Column.Name);
    			if (info.Name == null || info.Name == IndexOperation.BuildDefaultName(columns))
    			{
    				bool unique = info.Entries[0].Index.IsUnique;
    				var name = string.Format("{0}_{1}_{2}", unique ? "UX" : "IX", entitySet.Table, string.Join("_", columns));
    				if (name.Length > 128) name = name.Substring(0, 128);
    				if (info.Name == name) continue;
    				foreach (var entry in info.Entries)
    				{
    					var index = new IndexAttribute(name);
    					if (entry.Index.Order >= 0)
    						index.Order = entry.Index.Order;
    					if (entry.Index.IsUniqueConfigured)
    						index.IsUnique = entry.Index.IsUnique;
    					if (entry.Index.IsClusteredConfigured)
    						index.IsClustered = entry.Index.IsClustered;
    					entry.Index = index;
    					entry.Modified = true;
    				}
    			}
    		}
    		// Apply the changes
    		foreach (var g in indexInfo.SelectMany(e => e.Entries).GroupBy(e => e.Annotaion))
    		{
    			if (g.Any(e => e.Modified))
    				g.Key.Value = new IndexAnnotation(g.Select(e => e.Index));
    		}
    	}
    
    	class IndexInfo
    	{
    		public string Name;
    		public List<IndexEntry> Entries = new List<IndexEntry>();
    	}
    
    	class IndexEntry
    	{
    		public EdmProperty Column;
    		public MetadataProperty Annotaion;
    		public IndexAttribute Index;
    		public bool Modified;
    	}
    }
