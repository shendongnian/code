        // signature: void MyFunc()
        void DelayedCall(Action sdf, float delayInSecs)
        {
        }
        // signature: SomeClass MyFunc()
        void DelayedCall<T>(Func<T> sdf, float delayInSecs)
        {
        }
        // signature: void MyFunc(SomeClass param1)
        void DelayedCall<T>(Action<T> sdf, float delayInSecs, T values)
        {
        }
        // signature: SomeClass MyFunc(SomeClass param1)
        void DelayedCall<T, K>(Func<T, K> sdf, float delayInSecs, T values)
        {
        }
        
        // signature: void MyFunc(SomeClass param1, SomeClass2 param2)
        void DelayedCall<T, K>(Action<T, K> sdf, float delayInSecs, T values, K values2)
        {
        }
        // signature: SomeClass MyFunc(SomeClass param1, SomeClass2 param2)
        void DelayedCall<T, K, L>(Func<T, K, L> sdf, float delayInSecs, T values, K values2)
        {
        }
