    var items = await StoryTaskCount(item.ProjectId, storyList);
           //var st = items.FirstOrDefault();
            foreach (var st in items)
            {
                var story = await Factory.StoryService.StoryByIdAsync(item.ProjectId, st.Id);
                if (st.Count == 0)
                {
                    taskItem = await Factory.TaskService.QuickSave(item.ProjectId, story.StoryId, "Task for " + ConstantCompany.Prefix.StoryCode + story.StoryCode, true);
                    story.TaskId = taskItem.TaskId;
                }
                story.TaskCount = st.Count;
            }
    public async Task<List<BSTChildVM>> StoryTaskCount(decimal projectId, string ids)
        {
            var res = await (from story in Factory.StoryService.ForProject(projectId)
                             join st in Factory.BusinessHelperService.GetIds(ids) on story.StoryId equals st
                             join task in Factory.TaskService.AllTasks(projectId) on story.StoryId equals task.StoryId into ftask
                             from task in ftask.DefaultIfEmpty()
                             group task by story.StoryId into taskGroup
                             select new BSTChildVM
                             {
                                 Id = taskGroup.Key,
                                 Count = (from item in taskGroup
                                          where item.TaskId != null
                                          select item).Count()
                             }).ToListAsync();
            return res;
        }
