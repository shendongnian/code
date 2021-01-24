    public class Dog
    {
        public int Id;
        public string Name;
        public int BreedId;
        [Display(Name = "Breed Name")]  //Optional scaffolding attributes
        public string BreedName
        {
            get 
            {
                return ViewBag.Breeds[BreedId].Name;
            }
        }
    }
