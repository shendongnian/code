    IQueryable<Solution> result = db.Solutions
    	.Select(s => new {
    	    s.Id,
    		s.Title,
    		s.Subtitle,
    		Multimedia = new
    		{
    			s.Multimedia.ID,
                s.Multimedia.Name,
                s.Multimedia.Path,
                Preview = MultimediasController.ConvertVideo(m),
                Extension = MultimediasController.GetExtension(m),
                s.Multimedia.Type,
    		}
    	});
