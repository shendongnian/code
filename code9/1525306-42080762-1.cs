    mockedNewsfeedRepository
        .Setup(x => x.GetAll(
            It.IsAny<Expression<Func<Newsfeed, bool>>>(),
            It.IsAny<Expression<Func<Newsfeed, NewsModel>>>()
        ))
        // access invocation arguments when returning a value
        .Returns((Expression<Func<Newsfeed, bool>> predicate, Expression<Func<Newsfeed, NewsModel>> projection) =>
             expectedResult.Where(predicate.Compile()).Select(projection.Compile())
        );
