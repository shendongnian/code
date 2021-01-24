        [TestMethod]
        public void PrivateListCanHaveObjectsAdded()
        {
          var target = new A();
    
          var b = typeof(A).GetNestedType("B", BindingFlags.NonPublic);
          var list = typeof(A).GetField("list", BindingFlags.Instance | BindingFlags.NonPublic);
    
          var bInstance = Activator.CreateInstance(b);
          var addMethod = typeof(List<>).MakeGenericType(b).GetMethod("Add");
          var countProperty = typeof(List<>).MakeGenericType(b).GetProperty("Count");
          addMethod.Invoke(list.GetValue(target), new object[] { bInstance });
    
          Assert.AreEqual(1, countProperty.GetValue(list.GetValue(target)));
        }
