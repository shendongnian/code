        [Test]
        public void OpenDoorDoesNotRevalidate()
        {
            _userValidation.ValidateEnetryRequest().Returns(true);
            _uut.Run();
            _userValidation.ClearReceivedCalls();
            _uut.Run();
            _userValidation.DidNotReceive().ValidateEnetryRequest();
        }
