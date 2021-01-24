        public void ValidateAllFieldsAreInitOnly(Type sut)
        {
            foreach(var field in sut.GetFields(BindingFlags.NonPublic |
                                         BindingFlags.Instance |
                                         BindingFlags.Static |
                                         BindingFlags.Public))
            {
                Assert.IsTrue(field.IsInitOnly);
            }
            foreach (var property in sut.GetProperties(BindingFlags.NonPublic |
                                         BindingFlags.Instance |
                                         BindingFlags.Static |
                                         BindingFlags.Public))
            {
                // returns true if the property has a set accessor, even if the accessor is private, internal 
                Assert.IsFalse(property.CanWrite);
                // OR can use depending on requirement
                // The MethodInfo object representing the Set method for this property if the set accessor is public, or null if the set accessor is not public.
                Assert.IsNull(property.GetSetMethod());
            }
        }
