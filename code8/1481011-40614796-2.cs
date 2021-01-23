        // Summary:
        //     Returns an observable sequence that is the result of invoking the selector on
        //     a connectable observable sequence that shares a single subscription to the underlying
        //     sequence. This operator is a specialization of Multicast using a regular System.Reactive.Subjects.Subject`1.
        //
        // Parameters:
        //   source:
        //     Source sequence whose elements will be multicasted through a single shared subscription.
        //
        //   selector:
        //     Selector function which can use the multicasted source sequence as many times
        //     as needed, without causing multiple subscriptions to the source sequence. Subscribers
        //     to the given source will receive all notifications of the source from the time
        //     of the subscription on.
        //
        // Type parameters:
        //   TSource:
        //     The type of the elements in the source sequence.
        //
        //   TResult:
        //     The type of the elements in the result sequence.
        //
        // Returns:
        //     An observable sequence that contains the elements of a sequence produced by multicasting
        //     the source sequence within a selector function.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     source or selector is null.
        public static IObservable<TResult> Publish<TSource, TResult>(this IObservable<TSource> source, Func<IObservable<TSource>, IObservable<TResult>> selector);
