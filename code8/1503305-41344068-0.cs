    public class Repository : BaseRepository<Organization>, IOrganizationRepository
    {
       public void DoSomethingFancy(TEntity entity, string currentUserNationalCode, string currentUserIp, byte recordStatus,
        string recordStatusDescription)
      {
         base.Add(entity, currentUserNationalCode, currentUserIp, recordStatus,  recordStatusDescription);
      }
    }
