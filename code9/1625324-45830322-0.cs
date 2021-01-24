    ICronTrigger trigger = (ICronTrigger)TriggerBuilder.Create()
                                                                .WithIdentity(schedulerConfigurationEntity.TriggerName, schedulerConfigurationEntity.TriggerGroup)
                                                                .WithCronSchedule(schedulerConfigurationEntity.Schedule, x => x.WithMisfireHandlingInstructionFireAndProceed())
                                                                .ForJob(schedulerConfigurationEntity.JobName, schedulerConfigurationEntity.JobGroup)
                                                                .WithPriority(schedulerConfigurationEntity.Priority)
                                                                .UsingJobData("TriggerGroup", schedulerConfigurationEntity.TriggerGroup)
                                                                .Build();
