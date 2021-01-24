    class MyClass
    {
        /// <summary>
        /// DoSomething
        /// </summary>
        /// <exception cref="InvalidOperationException">InvalidOperationException</exception>
        public void DoSomething(MyType myType)
        {
            string errorMessage;
            if (!Validate(myType, out errorMessage))
                throw new InvalidOperationException(string.Format("Argument myType is not valid: {0}", errorMessage));
            // Finish
        }
        /// <summary>
        /// IsValid
        /// </summary>
        /// <exception cref="ArgumentNullException">ArgumentNullException</exception>
        public static bool Validate(MyType myType, out string errorMessage)
        {
            errorMessage = null;
            if (myType == null)
                throw new ArgumentNullException("myType");           
            if (string.IsNullOrEmpty(myType.Property1))
                errorMessage = "Property1 is required";
            if (string.IsNullOrEmpty(myType.Property2))
                errorMessage = "Property2 is required";
            return errorMessage == null;
        }
    }
    class MyType
    {
        public string Property1 { get; set; }
        public string Property2 { get; set; }
    }
