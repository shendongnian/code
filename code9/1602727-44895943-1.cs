      // Copy Process parameters
      newBuildDefinition.Process = buildDefinitionToCopy.Process;
      var processParams = WorkflowHelpers.DeserializeProcessParameters(buildDefinitionToCopy.ProcessParameters);
      var copyProcessParams = WorkflowHelpers.DeserializeProcessParameters(newBuildDefinition.ProcessParameters);
     foreach (KeyValuePair<string, object> entry in processParams)
      {
          copyProcessParams.Add(entry.Key.ToString(), entry.Value);
      }
     newBuildDefinition.ProcessParameters = WorkflowHelpers.SerializeProcessParameters(copyProcessParams);
