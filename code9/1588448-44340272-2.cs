    public static async Task<bool> PushData(string projectId)
    {
        var linkCompletion = new DataflowLinkOptions
        {
            PropagateCompletion = true
        };
        var projectItems = new TransformBlock<ProjectDTO, ProjectDTO>(
            dto => dto.GetItemData(dto), new ExecutionDataflowBlockOptions { MaxDegreeOfParallelism = 5 });
        var broadcast = new BroadcastBlock<ProjectDTO>();
        projectItems.LinkTo(broadcast, linkCompletion);
        var pR = serverList.Select(
                i => new { Id = i, Action = new ActionBlock<MemcachedDTO>(dto => PostEachServerAsync(dto, i, "set"), new ExecutionDataflowBlockOptions { MaxDegreeOfParallelism = 3 }) });
        foreach (var action in pR)
        {
            broadcast.LinkTo(action.Action, linkCompletion);
        }
        var dtoList = MemcachedDTO.GetDataByProject(projectId);
        foreach (var d in dtoList)
        {
            projectItems.Post(d);
        }
        projectItems.Complete();
        // wait all the action blocks to finish
        await Task.WhenAll(projectRules1.Completion, projectRules2.Completion, projectRules3.Completion, projectRules4.Completion, projectRules5.Completion);
        return false;
    }
