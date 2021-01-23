    // Check if a label was specified for the build; otherwise, use latest.
    if (!labelName.IsEmptyOrNull())
    {
      // Ensure the build process template is added to the specified label to prevent TF215097.
      AppendBuildProcessTemplateToLabel(tpc, buildDefinition, labelName);
      // Request the build of a specific label.
      buildRequest.GetOption = GetOption.Custom;
      buildRequest.CustomGetVersion = "L" + labelName;
    }
    I created the following method to append the build process template to the label prior to queueing a build.
    
    /// <summary>
    /// Appends the build process template to the given label.
    /// </summary>
    /// <param name="teamProjectCollection">The team project collection.</param>
    /// <param name="buildDefinition">The build definition.</param>
    /// <param name="labelName">Name of the label.</param>
    private static void AppendBuildProcessTemplateToLabel(TfsConnection teamProjectCollection, IBuildDefinition buildDefinition, string labelName)
    {
      // Get access to the version control server service.
      var versionControlServer = teamProjectCollection.GetService<VersionControlServer>();
      if (versionControlServer != null)
      {
        // Extract the label instance matching the given label name.
        var labels = versionControlServer.QueryLabels(labelName, null, null, true);
        if (labels != null && labels.Length > 0)
        {
          // There should only be one match and it should be the first one.
          var label = labels[0];
          if (label != null)
          {
            // Create an item spec element for the build process template.
            var itemSpec = new ItemSpec(buildDefinition.Process.ServerPath, RecursionType.None);
            // Create the corresponding labe item spec element that we want to append to the existing label.
            var labelItemSpec = new LabelItemSpec(itemSpec, VersionSpec.Latest, false);
            // Create the label indicating to replace the item spec contents. This logic will append
            // to the existing label if it exists.
            versionControlServer.CreateLabel(label, new[] {labelItemSpec}, LabelChildOption.Replace);
          }
        }
      }
    }
