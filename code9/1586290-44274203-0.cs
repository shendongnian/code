    [TestMethod]
    public void StoreClientDetailsInRedisAndReturnToken_SetsTwoValuesInRedis_ReturnsGuid()
    {
      var data = new List<dynamic>()
      var redis = new Mock<IRedisClient>();
      redis.Setup(x => x.Set(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<DateTime>()).Callback((string kp, string token, string data, DateTime exp) => data.Add(new {KeyPrefix = kp, Key = token, Data = data, Expiry = exp);
      var target = new MyClass(redis.Object);
      
      var result = target.StoreClientDetailsInRedisAndReturnToken("funny", "banana");
    
      new Guid(result); // do nothing, will throw if result is not parseable as Guid
    
      Assert.AreEqual(2, data.Count())
      Assert.AreEqual(KeyPrefix, data.FirstOrDefault().KeyPrefix);
      Assert.AreEqual(result, data.FirstOrDefault().Key);
      Assert.AreEqual("funny,banana", data.FirstOrDefault().Data);
      // here if you have enterprise edition of visual studio you can use microsoft fakes to actually test it, or otherwise
      Assert.IsTrue(((DateTime)data.FirstOrDefault().Expiry) > DateTime.UtcNow.AddDays(AdminSettings.Current.ExpiryDays).AddMinutes(-1));
    
      Assert.AreEqual(KeyPrefix, data.LastOrDefault().KeyPrefix);
      Assert.AreEqual("funny", data.LastOrDefault().Key);
      Assert.AreEqual(result, data.LastOrDefault().Data);
      Assert.IsTrue(((DateTime)data.LastOrDefault().Expiry) > DateTime.UtcNow.AddDays(AdminSettings.Current.ExpiryDays).AddMinutes(-1));
    }
