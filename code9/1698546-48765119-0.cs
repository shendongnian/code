    interface A<T> where T : class
    {
        B<T> SomeProperty { get;}
        void SomeMethod(B<T> param);
    }
