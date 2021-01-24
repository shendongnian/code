    ListPicture pic = Pictures.Find(Id);
    if (pic != null)
    {
        Pictures.Remove(pic);
    }
    SaveChanges();
