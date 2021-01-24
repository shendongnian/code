    public class MainDatabase
    {
        // Constructor
        public MainDatabase()
        {
            //if (!System.IO.File.Exists(folder))
            //{
                var db = new SQLiteConnection(folder);
                db.CreateTable<Image>();
            //}
        }
        // Create database
        string folder = System.IO.Path.Combine
                (System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal),
                "imagesDatabase.db");
        // Create Table
        [Table("Image")]
        public class Image
        {
            [Column("_id"), PrimaryKey, AutoIncrement]
            public int _id { set; get; }
            [Column("_image")]
            public byte[] _image { set; get; }// store the image with byte[]
        }
        public byte[] GetBitmapAsByteArray(Bitmap image)
        {
            MemoryStream stream = new MemoryStream();
            image.Compress(Bitmap.CompressFormat.Png, 0, stream);
            return stream.ToArray();
        }
        //Insert data
        public int Insert(Bitmap image)
        {
            var db = new SQLiteConnection(folder);
            var imageColumn = new Image();
            imageColumn._image = GetBitmapAsByteArray(image);
            return db.Insert(imageColumn);
        }
        //Retrieving data
        public Bitmap GetImageById(int id)
        {
            var db = new SQLiteConnection(folder);
            Image image=db.Find<Image>(id);
            // return the decoded Bitmap
            return BitmapFactory.DecodeByteArray(image._image, 0, image._image.Length);
        }
    }
 
