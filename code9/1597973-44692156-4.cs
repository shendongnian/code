      var filesList = Directory
        .EnumerateFiles(Path.Combine(Directory.GetCurrentDirectory(), "images"))
        .Select(file => {
           string extension = Path.GetExtension(file);      
           int extIndex;
           bool wanted = supportedExtensions.TryGetValue(extension, out extIndex);       
           
           return new {
             name = file,
             title = Path.GetFileNameWithoutExtension(file),
             extension = extension,
             extIndex = wanted ? extIndex : -1,
             wanted = wanted, }; })
        .Where(item => item.wanted) // you may want to comment out this condition
        .GroupBy(item => item.title)  
        .Select(group => group
           .OrderBy(item => item.extIndex)
           .First()
           .name);
