    var subject = new Subject<int>();
    
    int last = 0;
    
    using (subject.Subscribe(i => last = i))
    {
    	subject.OnNext(1);
    	subject.OnNext(2);
    }
    Assert.AreEqual(2, last);
