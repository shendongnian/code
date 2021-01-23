    List<SystemGroupWorkingClass> tempListSystemGroups = new List<SystemGroupWorkingClass>();
    //Get the SystemGroups that were selected in the View via checkbox
    foreach (var systemGroupVM in viewModel.SystemGroups)
    {
          if (systemGroupVM.Selected == true)
          {
               SystemGroupModel systemGroupModel = await db.SystemGroupModels.FindAsync(systemGroupVM.Id);
               SystemGroupWorkingClass systemGroupWorkingClass = new SystemGroupWorkingClass();
               systemGroupWorkingClass.SystemGroupModel = systemGroupModel;
               systemGroupWorkingClass.WasChecked = false;
               systemGroupWorkingClass.Selected = true;
               //Make sure tempListSystemGroups does not already have this systemGroupWorkingClass object
               var alreadyAddedCheck = tempListSystemGroups
                                .FirstOrDefault(s => s.SystemGroupModel.Id == systemGroupVM.Id);
               if (alreadyAddedCheck == null)
               {
                   tempListSystemGroups.Add(systemGroupWorkingClass);
               }
           }
    }
        for (int i = 0; i < tempListSystemGroups.Count; i++)
        {
            if (tempListSystemGroups[i].WasChecked == false)
            {
                SystemGroupModel systemGroupModel2 = await db.SystemGroupModels.FindAsync(tempListSystemGroups[i].SystemGroupModel.Id);
                
                //Get the children, if there are any, for the current parent
                var subSystemGroupModels = systemGroupModel2.SubSystemGroupModels
                        .ToList();
                //Loop through the children and add to tempListSystemGroups
                //The children are added to tempListSystemGroups as it is being iterated over
                foreach (var subSystemGroupModel in subSystemGroupModels)
                {
                    SystemGroupModel newSystemGroupModel = await db.SystemGroupModels.FindAsync(subSystemGroupModel.Id);
                    SystemGroupWorkingClass subSystemGroupWorkingClass = new SystemGroupWorkingClass();
                    subSystemGroupWorkingClass.SystemGroupModel = newSystemGroupModel;
                    subSystemGroupWorkingClass.WasChecked = false;
                    tempListSystemGroups.Add(subSystemGroupWorkingClass);
                }
            }
            //Mark the parent as having been checked for children
            tempListSystemGroups[i].WasChecked = true;
        }
