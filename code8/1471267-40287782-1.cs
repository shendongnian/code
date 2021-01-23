        [Test]
        public void should_return_same_view_when_model_is_invalid_on_post_for_create()
        {
            //Arrrange
            _sut.ModelState.AddModelError(String.Empty, String.Empty);
            //Act
            var result = (ViewResult) _sut.Create(new RegisterViewModel());
            //Assert
            Assert.That(result.ViewName, Is.EqualTo(String.Empty));
            Assert.That(result.Model.GetType(), Is.EqualTo(typeof (RegisterViewModel)));
        }
