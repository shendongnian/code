    public Byte[] GetImageBytes(string image_name)
    {
      	Byte[] bytes = null;
       	if (!string.IsNullOrEmpty(image_name))
       	{
       		string app_path = ((System.Web.HttpRequestWrapper)this.Request)
                                    .PhysicalApplicationPath;
       		app_path += "Content\\images\\";
       		string full_path = app_path + image_name;
       		//
       		if (System.IO.File.Exists(full_path))
       		{
       			FileStream fs = new FileStream(full_path, FileMode.Open, FileAccess.Read);
       			BinaryReader br = new BinaryReader(fs);
       			bytes = br.ReadBytes(Convert.ToInt32(br.BaseStream.Length));
       		}
       	}
       	return bytes;
    }
