    var res = from a in db.Articles.AsEnumerable()
			  from tag in a.Tags.Split(',')
			  select new {
			      Id = a.Id,
				  Title = a.Title,
				  Tags = a.Tags,    // you probably don't want this
		          Tag = tag
		      };
