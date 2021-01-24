    public class AddDogVM
    {
        private IDogService _dogService
        public AddDogVM(IDogService dogService)
        {
            _dogService = dogService;
        }
        public async Task<ActionResult> Add(Dog dog, string type)
        {
            var d = new Dog();
            d.Name = dog.Name;
            d.NumOfLegs = dog.NumOfLegs;
            d.BirthdayDate = dog.BirthdayDate;
            if (type == "mom") {
                InitChildrenOfMomDog(dog);
            }
            _dogService.Insert(dog);
        }
    }
