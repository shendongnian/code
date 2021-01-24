    public ApproveResult ApproveFamily(ApproveFamilyInput input)
    {
         var family = _familyRepository.GetFamily(input.Username);
         family.Approve();
         _familyRepository.Update(family);
         bool isSaved = _familyRepository.Save();
         if(isSaved)
             _eventPublisher.Publish(family.raisedEvents);
         // return result
    }
