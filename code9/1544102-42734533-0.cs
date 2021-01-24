    /// <summary>
      /// Insert a new permission.
      /// </summary>
      /// <param name="service">Drive API service instance.</param>
      /// <param name="fileId">ID of the file to insert permission for.</param>
      /// <param name="who">
      /// User or group e-mail address, domain name or null for "default" type.
      /// </param>
      /// <param name="type">The value "user", "group", "domain" or "default".</param>
      /// <param name="role">The value "owner", "writer" or "reader".</param>
      /// <returns>The inserted permission, null is returned if an API error occurred</returns>
      public static Permission InsertPermission(DriveService service, String fileId, String who,String type, String role) {
        Permission newPermission = new Permission();
        newPermission.Value = value;
        newPermission.Type = type;
        newPermission.Role = role;
        try {
          return service.Permissions.Insert(newPermission, fileId).Execute();
        } catch (Exception e) {
          Console.WriteLine("An error occurred: " + e.Message);
        }
        return null;
      }
