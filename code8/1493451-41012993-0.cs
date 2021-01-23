    public List<Image> GetImageList(Hotel hotel)
        {
            List<Image> imageList = new List<Image>();
            var type = hotel.GetType();
            var propertyInfos = type.GetProperties();
            foreach (var item in propertyInfos)
            {
                if (item.Name.StartsWith("Image") && item.PropertyType==typeof(Image))
                {
                    imageList.Add((Image)item.GetValue(hotel));
                }
            }
    
            return imageList;
        }
