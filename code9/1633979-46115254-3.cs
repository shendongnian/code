    public IQueryable<DeviceDataItem> MeterWorkflowFilter(IQueryable<DeviceDataItem> query)
    {
    	Type context = typeof(Meter);
    
    	var deviceState = (from objectState in UnitOfWork.ObjectState
    					   join workflow in UnitOfWork.Workflow on objectState.WorkflowId equals workflow.Id
    					   where
    							objectState.ContextFullName == context.FullName
    					   group objectState by objectState.ContextId into grp
    					   select grp.OrderByDescending(desc => desc.CreateDate).FirstOrDefault());
    
    	// NOTE: Not all Devices will immediately have a Meter
    	var filteredQuery = (from dataitems in query //<-- QUERY
    						 join statefulDevice in deviceState on dataitems.MeterId equals statefulDevice.ContextId into statefulDeviceLEFTJOIN
    						 from statefulDevice in statefulDeviceLEFTJOIN.DefaultIfEmpty()
    						 select new DeviceDataItem()
    						 {
    							 DeviceId = dataitems.DeviceId,
    							 DeviceName = dataitems.DeviceName,
    							 MeterPositionId = dataitems.MeterPositionId,
    							 MeterPositionCategory = dataitems.MeterPositionCategory,
    							 MeterId = dataitems.MeterId,
    							 MeterName = dataitems.MeterName,
    							 MeterNumber = dataitems.MeterNumber,
    							 MeterTypeId = dataitems.MeterTypeId,
    							 MeterTypeName = dataitems.MeterTypeName,
    							 CompanyId = dataitems.CompanyId,
    							 CompanyName = dataitems.CompanyName,
    							 PipelineId = dataitems.PipelineId,
    							 PipelineName = dataitems.PipelineName,
    							 CommunicationTechnicianId = dataitems.CommunicationTechnicianId,
    							 CommunicationTechnicianFirstName = dataitems.CommunicationTechnicianFirstName,
    							 CommunicationTechnicianLastName = dataitems.CommunicationTechnicianLastName,
    							 MeasurementTechnicianId = dataitems.MeasurementTechnicianId,
    							 MeasurementTechnicianFirstName = dataitems.MeasurementTechnicianFirstName,
    							 MeasurementTechnicianLastName = dataitems.MeasurementTechnicianLastName,
    							 RunStatusId = dataitems.RunStatusId,
    							 RunStatusCategory = dataitems.RunStatusCategory,
    							 MeterObjectState = statefulDevice.Workflow
    						 });
    
    	return filteredQuery;
    }
