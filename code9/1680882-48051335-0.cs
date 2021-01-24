    var tempdetails = _myRepository.SearchFor(condifiotn);
    
    if(tempdetails != null)
    {
        foreach (var detail in tempdetails)
        {            
           //Do Some Modification
           detail.Name = "Test";
    
         _myRepository.Update(detail);
        }
    
        //Save Changes
         _unitOfWork.Commit();
    }
