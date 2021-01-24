    public static T Next<T>(T currentElement) where T : class, IModel, IId
    {
        T data;
        if (currentElement.Id >= GetLastId<T>())
            return currentElement;
        using (DatabaseEntities context = new DatabaseEntities())
        {
            return context.Set<T>().Next(currentElement);
        }
     }
 
