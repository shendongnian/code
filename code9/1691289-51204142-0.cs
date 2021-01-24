    var type = project.WorkItemTypes["Code Review Response"];
    var workItem = new WorkItem(type) { Title = checkinNotification.Comment };
    workItem.Fields["System.AssignedTo"].Value = "Betty"; //todo pick someone better
    workItem.Fields["System.State"].Value = "Requested";
    workItem.Fields["System.Reason"].Value = "New";
    var result = workItem.Validate();
    foreach (Field item in result)
    {
        //insert some form of logging here
    }
    workItem.Save();
    var responseId = workItem.Id;
    type = project.WorkItemTypes["Code Review Request"];
    workItem = new WorkItem(type) { Title = checkinNotification.Comment };
    workItem.Fields["System.AssignedTo"].Value = checkinNotification.ChangesetOwner.DisplayName;
    workItem.Fields["Microsoft.VSTS.CodeReview.ContextType"].Value = "Changeset";
    workItem.Fields["Microsoft.VSTS.CodeReview.Context"].Value = checkinNotification.Changeset;
    workItem.Fields["System.AreaPath"].Value = project.Name; //todo: may want a better location from source path
    workItem.Fields["System.IterationPath"].Value = project.Name;
    workItem.Fields["System.State"].Value = "Requested";
    workItem.Fields["System.Reason"].Value = "New";
    WorkItemLinkTypeEnd linkTypeEnd = workitemStore.WorkItemLinkTypes.LinkTypeEnds["Child"];
    workItem.Links.Add(new RelatedLink(linkTypeEnd, responseId));
    workItem.Save();
                        
