        [Test]
        public void should_redirect_to_aprroval_on_post_for_create()
        {
            //Assert
            A.CallTo(() => _fakeUserRepository.Save(A<Athlete>.Ignored));
            //Act
            var result = (RedirectToRouteResult) _sut.Create(new RegisterViewModel{});
            //Assert
            Assert.That(result.RouteValues["action"], Is.EqualTo("Approval"));
        }
