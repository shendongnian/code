    public IQueryable<DeviceDataItem> Query()
    {
    	var query = from device in UnitOfWork.Device
    				join rtuDevice in UnitOfWork.RTUDevice on device.Id equals rtuDevice.DeviceId into rtuDeviceLEFTJOIN
    				from rtuDevice in rtuDeviceLEFTJOIN.DefaultIfEmpty()
    				join commTech in UnitOfWork.User on rtuDevice.CommunicationTechnicianId equals commTech.Id into commTechLEFTJOIN
    				from commTech in commTechLEFTJOIN.DefaultIfEmpty()
    				join measureTech in UnitOfWork.User on rtuDevice.MeasurementTechnicianId equals measureTech.Id into measureTechLEFTJOIN
    				from measureTech in measureTechLEFTJOIN.DefaultIfEmpty()
    				join meter in UnitOfWork.Meter on device.Id equals meter.DeviceId into meterLEFTJOIN
    				from meter in meterLEFTJOIN.DefaultIfEmpty()
    				join meterType in UnitOfWork.MeterType on meter.MeterTypeId equals meterType.Id into meterTypeLEFTJOIN
    				from meterType in meterTypeLEFTJOIN.DefaultIfEmpty()
    				join company in UnitOfWork.Company on meter.CompanyId equals company.Id into companyLEFTJOIN
    				from company in companyLEFTJOIN.DefaultIfEmpty()
    				join meterPosition in UnitOfWork.EFMMeterPosition on meter.EFMMeterPositionId equals meterPosition.Id into meterPositionLEFTJOIN
    				from meterPosition in meterPositionLEFTJOIN.DefaultIfEmpty()
    				join runStatus in UnitOfWork.RunStatus on meter.RunStatusId equals runStatus.Id into runStatusLEFTJOIN
    				from runStatus in runStatusLEFTJOIN.DefaultIfEmpty()
    				join pipeline in UnitOfWork.Pipeline on meter.PipelineId equals pipeline.Id into pipelineLEFTJOIN
    				from pipeline in pipelineLEFTJOIN.DefaultIfEmpty()
    				select new DeviceDataItem()
    				{
    					DeviceId = device.Id,
    					DeviceName = device.DeviceName,
    					MeterPositionId = meterPosition.Id,
    					MeterPositionCategory = meterPosition.EFMMeterPositionCategory,
    					MeterId = meter.Id,
    					MeterName = meter.MeterName,
    					MeterNumber = meter.MeterNumber,
    					MeterTypeId = meterType.Id,
    					MeterTypeName = meterType.MeterTypeName,
    					CompanyId = company.Id,
    					CompanyName = company.CompanyName,
    					PipelineId = pipeline.Id,
    					PipelineName = pipeline.PipelineName,
    					CommunicationTechnicianId = commTech.Id,
    					CommunicationTechnicianFirstName = commTech.FirstName,
    					CommunicationTechnicianLastName = commTech.LastName,
    					MeasurementTechnicianId = measureTech.Id,
    					MeasurementTechnicianFirstName = measureTech.FirstName,
    					MeasurementTechnicianLastName = measureTech.LastName,
    					RunStatusId = runStatus.Id,
    					RunStatusCategory = runStatus.RunStatusCategory,
    					MeterObjectState = null
    				};
    
    	return query;
    }
