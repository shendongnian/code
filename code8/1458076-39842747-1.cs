    public void InputCorrectId()
        {
            _userValidation.ValidateEnetryRequest().Returns(true);
            if(_doorControlState == DoorControlState.DoorClosed){
                _uut.RequestEntryId();  // Make it public
            }
            _door.Received().Open();
    
        }
