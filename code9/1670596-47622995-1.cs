    public class AddDogVM
    {
        public async Task<ActionResult> Add(Dog dog, string type)
        {
            var d = new Dog();
            d.Name = dog.Name;
            d.NumOfLegs = dog.NumOfLegs;
            d.BirthdayDate = dog.BirthdayDate;
            if (type == "mom") {
                InitChildrenOfMomDog(dog);
            }
            dogService.Insert(dog);
        }
    }
