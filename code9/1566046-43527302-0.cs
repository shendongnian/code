    ListPicture pic = Pictures.FirstOrDefault(x => x.pId == Id);
    if (pic != null)
    {
        Pictures.Remove(pic);
    }
    SaveChanges();
