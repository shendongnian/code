    /// <summary>
    /// Throws a 404 Not found exception
    /// </summary>
    /// <param name="model">The model to check</param>
    /// <param name="name">The name to display in the message</param>
    /// <returns></returns>
    public static T ThrowIfNotFound<T>(this T model, string name)
    {
        // If we have nothing, throw an error
        if (model == null)
            throw new HttpException(404, string.Format(Resources.GenericNotFound, name));
        // Return our model
        return model;
    }
