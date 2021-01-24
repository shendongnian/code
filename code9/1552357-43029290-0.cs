public object ReturnMytype() => new MyType { MyProperty = "a" };
    [TestMethod]
    public void ReturnMytype_SetsMyPropertytoA(){
       Assert.AreEqual("a", (new MyClass().ReturnMytype as MyType).MyProperty);
    }
