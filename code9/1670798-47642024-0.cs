    public List<QuestionTag> ParseTags(string tags)
    {
        var tagList = tags.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries).ToList();
        var questionTags = new List<QuestionTag>();
        var anyNewTags = false; //to see if we have to SaveChanges()
        foreach(var tag in tagList)
        {
            //You should do the check and add your tags here
            var objectExists = _context.Tag.Find(a => a.Name == tag);
            if (objectExists == null)
            {
               //tag doesn't exist
               //create a new tag, add it to db
               //also add it to the tag list
               var newTag = new QuestionTag() { Tag = new Tag() { Name = tag } };
               _context.QuestionTag.Add(newTag);
               questionTags.Add(newTag);
               //there is a new tag, we have to call SaveChanges()
               anyNewTags = true;
            }
            else
            {
               //tag exists, just grab it, no need to add anything.
               questionTags.Add(objectExists);
            }
        }
        //do we have new tags, do we need to call SaveChanges()?
        if (anyNewTags) _context.SaveChanges();
        return questionTags;
    }
