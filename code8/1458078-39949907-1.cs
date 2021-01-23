        [Test]
        public void ClosedDoorOpensWhenUserIsValid()
        {
            _userValidation.ValidateEnetryRequest().Returns(true);
            _uut.Run();
            _door.Received().Open();
        }
        [Test]
        public void ClosedDoorDoesNotOpenWhenUserInvalid()
        {
            _userValidation.ValidateEnetryRequest().Returns(false);
            _uut.Run();
            _door.DidNotReceive().Open();
        }
