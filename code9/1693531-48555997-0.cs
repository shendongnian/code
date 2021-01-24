    var project = (Document)client.CreateDocumentQuery<dynamic>(UriFactory.CreateDocumentCollectionUri(databaseName, collectionName))
                .AsEnumerable()
                .First();
    var gate = project?.GetPropertyValue<dynamic>("IdeaInitiatedGate");
    project?.SetPropertyValue("IdeaInitiatedGate", new JObject { { "VpApprovalStatus", "Approved" }});
    var document = client.ReplaceDocumentAsync(UriFactory.CreateDocumentUri(databaseName, collectionName, project?.Id), project).Result.Resource;
