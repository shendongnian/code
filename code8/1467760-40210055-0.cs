     // Set the following variables accordingly
            string workItemTypeName = "Bug";
            string teamProjectName = "My Project";
            string usernameToImpersonate = "XXX";
            string tfsTeamProjectCollectionUrl = "http://xxx:8080/tfs/defaultcollection";
        // OPTION 1: no impersonation.
        // Get an instance to TFS using the current thread's identity.
        // NOTE: The current thread's identity needs to have the "" permision or else you will receive
        //       a runtime SOAP exception: "Access Denied: [username] needs the following permission(s) to perform this action: Make requests on behalf of others"
        TfsTeamProjectCollection tfs = new TfsTeamProjectCollection( new Uri( tfsTeamProjectCollectionUrl ) );
        IIdentityManagementService identityManagementService = tfs.GetService<IIdentityManagementService>();
        // OPTION 2: impersonation.  Remove the following two lines of code if you don't need to impersonate.
        // Get an instance to TFS impersonating the specified user.
        // NOTE: This is not needed if the current thread's identity is that of the user 
        //       needed to impersonate. Simple use the ablve TfsTeamProjectCollection instance
        TeamFoundationIdentity identity = identityManagementService.ReadIdentity( IdentitySearchFactor.AccountName, usernameToImpersonate, MembershipQuery.None, ReadIdentityOptions.None );
        tfs = new TfsTeamProjectCollection( tfs.Uri, identity.Descriptor );
        WorkItem workItem = null;
        WorkItemStore store = tfs.GetService<WorkItemStore>();
        // Determine if we are creating a new WorkItem or loading an existing WorkItem.
        if( workItemId.HasValue ) {
           workItem = store.GetWorkItem( workItemId.Value );
        }
        else {
           Project project = store.Projects[ teamProjectName ];
           WorkItemType workItemType = project.WorkItemTypes[ workItemTypeName ];
           workItem = new WorkItem( workItemType );
        }
        if( workItem != null ) {
           foreach( Field field in workItem.Fields ) {
              if( field.IsRequired ) {
                 // TODO
              }
           }
        }
