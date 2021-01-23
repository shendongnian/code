    private void DisplayImageFromDb(int id)
    {
        using (var context = new DataContext())
        {
            var item = context
                .tblShips
                .AsNoTracking()
                .FirstOrDefault(x => x.Id == id);
    
            if (item == null)
                throw new Exception("Image could not be found!");
    
            //Assign the property and let the binding do the work
            ImageSource = item.Picture;
        }
    }
