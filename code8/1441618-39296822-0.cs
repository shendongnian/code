				List<Tag> tags = new List<Tag>()
				{
					new Tag(id: "Tag1", val:true),
					new Tag(id: "Tag2", val:true),
					new Tag(id: "Tag3", val:false)
				};
			
				var dict = new Dictionary<string, bool>(); 
				
				foreach(Tag tag in tags)
				{	
					dict.Add(tag.Id, tag.Val); 
				}
