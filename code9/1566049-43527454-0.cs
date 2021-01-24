	public void DeletePicture(string Id)
	{
	  ListPicture pic = GetPicture(Id);
	  if( pic != null)
	  {
		  // add check if instance is attached
		  if(contextInstance.Entry(pic).State == System.Data.Entity.EntityState.Detached)
			Pictures.Attach(pic);
		  Pictures.Remove(pic);
	   }
	   SaveChanges(); // this could be moved to inside the if block
	}
