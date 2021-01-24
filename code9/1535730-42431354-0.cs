     //this will add new department relation
    var newDepartmentIds = editActivityViewModel.SelectedDepartmentIds.Where(sdid =>  activity.ParticipantDepartments.All(pd => pd.Id != sdid)).ToList();
    
    activity.ParticipantDepartments.Add(GetParticipantDepartments(newDepartmentIds));
    //if you also want to remove the departments those are not in editActivityViewModel.SelectedDepartmentIds
    
    activity.ParticipantDepartments.RemoveRange(activity.ParticipantDepartments.Where(apd => editActivityViewModel.SelectedDepartmentIds.All(sdid => sdid != apd.Id)))
