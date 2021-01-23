     //upload image
                if (image!= null && image.ContentLength > 0)
                {
                    try
                    {
    //Here, I create a custom name for uploaded image
                        string file_name = your_model.Name + Path.GetExtension(image.FileName);
                        string path = Path.Combine(Server.MapPath("~/Content/images"), file_name);
                        image.SaveAs(path);
                        your_model.image_path= file_name;
                    }
                    catch (Exception ex)
                    {
      ...
                    }
                }
