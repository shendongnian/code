	//When AlbumView .BaseType was able to return x.Models.Music.Album
	string strNamespace = entry.Entity.GetType().BaseType.ToString(); 
	
	//Needed this if I was updating just an Object (ie: Album),
	//would be nice to make something more concret
	if (strNamespace == "x.Models.Core.BaseObject")
		strNamespace = entry.Entity.ToString();
	//Continuing code
	var query = this.Set(strNamespace).AsNoTracking().Where("Oid == @0", oid);
	
