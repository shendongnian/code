    List<Eatery> data = new List<Eatery>();
    foreach (var item in db.Table<Eatery>())
    {
         var place = item.Name.ToString();
         var location = item.Location.ToString();
         var rating = item.Rating;
         item.Town.ToString();
         data.Add(new Eatery() { PlaceName = place, PlaceLocation = location, PlaceRating = rating });
    }
