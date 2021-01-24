    public class ObjectImage
    {
      public int ObjectId { get; set; }
      public byte[] Image { get; set; }
    }
    [HttpPost("SaveImage")]
    public void SaveImage([FromBody]object content)
    {
      var obj = JsonConvert.DeserializeObject<ObjectImage>(content.ToString());
      _db.Images.Find(obj.ObjectId).Image = obj.Image;
      _db.SaveChanges();
    }
