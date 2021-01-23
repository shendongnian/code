    public void FeedDog(Dog dog){
    
    try
    {
        Console.WriteLine("Feeding "+dog.Name); 
    }
    
    catch(NullReferenceException e)
    {
    throw new DogDoesnotExistException();
    }
}
