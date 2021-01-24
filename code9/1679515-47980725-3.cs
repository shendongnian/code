    public class SourceContext : ContextBase, IDisposable
	{
		public SMBASchedulerEntities _sourceEntities;
		public SystemDa _systemDB = new SystemDa();
		
		public SourceContext(string connectionString)
		{
			_sourceEntities = new SMBASchedulerEntities(connectionString);
		}
		public void AddToPatient(Patient newPatient)
		{
			_sourceEntities.Patients.Add(newPatient);
			SaveChanges();
		}
		
		public void ChangeDatabaseTo(string connectionString)
		{
			if (_sourceEntities != null)
				_sourceEntities.Dispose();
			_sourceEntities = new SMBASchedulerEntities(connectionString);
		}
		
		public void AddToAppointmentTypes(AppointmentType AppointmentTypes)
		{
			_sourceEntities.AppointmentTypes.Add(AppointmentTypes);
			SaveChanges();
		}
		
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
		
		protected virtual void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (_sourceEntities != null)
				{
					_sourceEntities.Dispose();
				}
			}
		}
		
	}
