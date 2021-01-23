		internal static CustomerDto Map(Customer entity)
		{
			if (entity == null) throw new ArgumentNullException("entity");
			CustomerDto dto = new CustomerDto();
			try
			{
				dto.Id = entity.Id;
				dto.FirstName = entity.FirstName;
				dto.LastName = entity.LastName;
				dto.Gender = entity.Gender;
				dto.Email = entity.Email;
			}
			catch (Exception e)
			{
				string errMsg = String.Format("Map(entity). Error mapping a Customer entity to DTO. Id: {0}.", entity.Id);
				//LOG ERROR
			}
			return dto;
		}
