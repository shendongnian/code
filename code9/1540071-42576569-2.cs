    class MyClass<T> {
        protected DbContext MyDBContext 
        {
           get 
           { 
              return Activator.CreateInstance<T>();
           }
        }
        public void MethodOne() {
            // Having automatically a new instance of DbContext
        }
    
        public void MethodTwo() {
            // Also having automatically a new instance of DbContext
        }
    }
