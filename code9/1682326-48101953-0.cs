    var exceptionType = Type.GetType(exceptionName);
    if (exceptionNode != null)
    {
        Policy.Handle<Exception>(e => exceptionType.IsAssignableFrom(e.GetType())) // etc
    }
