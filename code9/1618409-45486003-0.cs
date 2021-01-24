    public class ProfilePictures
    {
        public int ProfilePicturePK {get;set;}
        public byte[] PictureData {get;set;}
    }
    
    ... all the other entity setup
    
    public byte[] GetPictureData(int id)
    {
        using(var db = Context)
        {
            return (from pictures in db.ProfilePictures where pictures.ProfilePicturePK == id select pictures).SingleOrDefault();
        }
    }
