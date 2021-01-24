        [TestMethod]
        public async Task TestMethod1()
        {
            // Arrange
            var dbWriteService = MockRepository.GenerateMock<IDbWriteService>();
            dbWriteService.Expect(service => service.UpdateAsync(null)).Return(Task.FromResult(0));
            var subject = new Class1(dbWriteService);
            // Act
            var result = await subject.SaveDataAsync(null);
            // Assert
            Assert.IsTrue(result);
            dbWriteService.AssertWasCalled(service => service.UpdateAsync(null));
        }
