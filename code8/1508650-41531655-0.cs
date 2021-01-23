    try
            {
                pb.Image.Save(location + time.ToString() + ".jpg");
            }
            catch (NullReferenceException ex)
            {
                ex.ToString();
            }
