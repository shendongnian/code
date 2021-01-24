    public class ProfilePictures
    {
        public int ProfilePicturePK {get;set;}
        public byte[] PictureData {get;set;}
    }
    
    ... all the other entity setup
    
    public byte[] GetPictureData(int id)
    {
        return GetPictureDataAsync(id).Wait();
    }
    //If you want to make things a little more UI and thread friendly
    public async Task<byte[]> GetPictureDataAsync(int id)
    {
         await Task.Factory.StartNew(()=>{
            using(var db = Context)
            {
                return (from pictures in db.ProfilePictures where pictures.ProfilePicturePK == id select pictures).SingleOrDefault();
            }
         });
    }
