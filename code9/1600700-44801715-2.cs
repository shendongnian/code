    var a = Activities.ToList()
                .Select((activity) =>
                    {
                        activity.Tasks.ToList()
                            .ForEach((task) => task.Steps = task.Steps.OrderBy(s => s.DisplayOrder).ToList()
                            .Select((step) =>
                                {
                                    step.Responses = step.Responses.Where(r => r.UserId == 1).ToList();
                                    return step;
                                }).ToList());
                        return activity;
                    });
