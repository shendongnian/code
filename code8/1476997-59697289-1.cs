        type TestAsyncEnumerator<'T> (inner : IEnumerator<'T> ) =     
            
            let inner : IEnumerator<'T> = inner
            
            interface IAsyncEnumerator<'T> with
                member this.Current with get() = inner.Current
                member this.MoveNextAsync () = ValueTask<bool>(Task.FromResult(inner.MoveNext()))
                member this.DisposeAsync () = ValueTask(Task.FromResult(inner.Dispose))
    
        type TestAsyncEnumerable<'T> =       
            inherit EnumerableQuery<'T>
    
            new (enumerable : IEnumerable<'T>) = 
                { inherit EnumerableQuery<'T> (enumerable) }
            new (expression : Expression) = 
                { inherit EnumerableQuery<'T> (expression) }
            
            interface IAsyncEnumerable<'T> with
                member this.GetAsyncEnumerator cancellationToken : IAsyncEnumerator<'T> =
                     new TestAsyncEnumerator<'T>(this.AsEnumerable().GetEnumerator())
                     :> IAsyncEnumerator<'T>
    
            interface IQueryable<'T> with
                member this.Provider with get() = new TestAsyncQueryProvider<'T>(this) :> IQueryProvider
    
        and 
            TestAsyncQueryProvider<'TEntity> 
            (inner : IQueryProvider) =       
            
            let inner : IQueryProvider = inner
    
            interface IAsyncQueryProvider with
                    
                member this.Execute (expression : Expression) =
                    inner.Execute expression
    
                member this.Execute<'TResult> (expression : Expression) =
                    inner.Execute<'TResult> expression
    
                member this.ExecuteAsync<'TResult> ((expression : Expression), cancellationToken) =
                    inner.Execute<'TResult> expression
    
                member this.CreateQuery (expression : Expression) =
                    new TestAsyncEnumerable<'TEntity>(expression) :> IQueryable
    
                member this.CreateQuery<'TElement> (expression : Expression) =
                    new TestAsyncEnumerable<'TElement>(expression) :> IQueryable<'TElement>
    
    
        let getQueryableMockDbSet<'T when 'T : not struct>
            (sourceList : 'T seq) : Mock<DbSet<'T>> =
    
            let queryable = sourceList.AsQueryable();
    
            let dbSet = new Mock<DbSet<'T>>()
    
            dbSet.As<IAsyncEnumerable<'T>>()
                .Setup(fun m -> m.GetAsyncEnumerator())
                .Returns(TestAsyncEnumerator<'T>(queryable.GetEnumerator())) |> ignore
    
            dbSet.As<IQueryable<'T>>()
                .SetupGet(fun m -> m.Provider)
                .Returns(TestAsyncQueryProvider<'T>(queryable.Provider)) |> ignore
    
            dbSet.As<IQueryable<'T>>().Setup(fun m -> m.Expression).Returns(queryable.Expression) |> ignore
            dbSet.As<IQueryable<'T>>().Setup(fun m -> m.ElementType).Returns(queryable.ElementType) |> ignore
            dbSet.As<IQueryable<'T>>().Setup(fun m -> m.GetEnumerator ()).Returns(queryable.GetEnumerator ()) |> ignore
            dbSet
