    public static Dictionary<FoodTypes, List<Animal>> GetAnimalListBasedOnFoodType(List<Animal> animals)
    {
        return animals
            .GroupBy(animal => animal.Food)
            .ToDictionary(
                group => group.Key,
                group => group.ToList());
    }
