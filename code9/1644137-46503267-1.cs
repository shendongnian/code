    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    public static List<TDestination> MapList<TSource, TDestination>(
        this IMapper<TSource, TDestination> translator,
        List<TSource> source)
        where TDestination : new()
    {
        var destinationCollection = new List<TDestination>(source.Count);
        foreach (var sourceItem in source)
        {
            TDestination dest = Factory<TDestination>.Instance();
            translator.Map(sourceItem, dest);
            destinationCollection.Add(dest);
        }
        return destinationCollection;
    }
    static class Factory<T>
    {
        // Cached "return new T()" delegate.
        internal static readonly Func<T> Instance = CreateFactory();
        private static Func<T> CreateFactory()
        {
            NewExpression newExpr = Expression.New(typeof(T));
            return Expression
                .Lambda<Func<T>>(newExpr)
                .Compile();
        }
    }
