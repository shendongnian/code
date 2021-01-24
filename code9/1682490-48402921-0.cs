    Public Sub AddUserToRoleOnFolder(userName As string, role As String, reportFolderName As String) 
       
        dim allPoliciesInReportFolder =  ReportingService.GetPolicies("/" & reportFolderName,False).ToList()
        dim policiesForCurrentUser  = allPoliciesInReportFolder.FirstOrDefault(Function (f) f.GroupUserName =userName)
        dim policyExists = policiesForCurrentUser IsNot Nothing
        try
            If  policyExists then
                AddNewRoleToPolicy( policiesForCurrentUser, role)
            else
                AddNewPolicy(userName, role, allPoliciesInReportFolder)
            End If
            ReportingService.SetPolicies("/" & reportFolderName,allPoliciesInReportFolder.ToArray())
        Catch ex As SoapException
            Throw New AuthenticationException($"Insufficient permissions for to assign roles in RS for {Configuration.Domain}\{Configuration.Username}. User must be a member of the Local Administrator Group on the RS server.", ex)
        End Try
        
    End Sub
    Private Sub AddNewPolicy(userName As String, role As String, ByRef  allPoliciesInReportFolder As List( of Policy)  )
        Dim policy As New Policy()
        policy.GroupUserName = userName
        policy.Roles = ReportingService.ListRoles(SecurityScopeEnum.All).Where(Function(r) r.Name = role).ToArray()
        allPoliciesInReportFolder.Add(policy)
    End Sub
    Private Sub AddNewRoleToPolicy(byref policiesForCurrentUser As Policy, roleName As String)
        if  Not policiesForCurrentUser.Roles.Where(function(r) r.Name=roleName).Any() Then
            dim role as Role=ReportingService.ListRoles(SecurityScopeEnum.All).Where(Function(r) r.Name = roleName).FirstOrDefault()
            dim roles = policiesForCurrentUser.Roles.ToList()
            roles.Add(role)
            policiesForCurrentUser.Roles= roles.ToArray()
        End If
    End Sub
