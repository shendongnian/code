           var accessPolicy = new AccessPolicyEntry
        {
            ApplicationId = app, // Delete this line
            ObjectId = Obid,
            PermissionsRawJsonString = "{ \"keys\": [ \"all\" ], \"secrets\": [ \"all\"  ], \"certificates\": [ \"all\" ] }",
            TenantId = ten,
        };
        return accessPolicy;
