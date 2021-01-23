    using System.Linq;
    using System.Web.Http;
    using System.Web.Http.OData.Query;
    using IndireKat.Data.Contracts;
    using IndireKat.Data.Contracts.Entities;
    using IndireKat.Shared.Framework.Security;
    namespace Presentation.Host.Controllers
    {
        public class KatastralgemeindenController : BaseODataController
        {
            private readonly IIdentityStorage identityStorage;
    
            public KatastralgemeindenController(IUnitOfWork unitOfWork, IIdentityStorage identityStorage)
            {
                UnitOfWork = unitOfWork;
                this.identityStorage = identityStorage;
            }
    
            [Queryable(AllowedQueryOptions = AllowedQueryOptions.All)]
            public IQueryable<Katastralgemeinden> Get()
            {
                IIndireKatPrincipal indireKatPrincipal = identityStorage.GetPrincipal();
    
                var comunityIds = UnitOfWork.GetAll<UserGroup>()
                    .Where(group => group.Id == indireKatPrincipal.GroupId)
                    .SelectMany(group => group.Tbl_Group_Communities).Select(comunity => comunity.GKZ).ToList();
    
                IQueryable<Katastralgemeinden> result = null;
    
                if (comunityIds.Any())
                {
                    result = UnitOfWork.GetAll<Katastralgemeinden>().Where(company => comunityIds.Contains(company.GKZ));
                }
    
                return result;
            }
        }
    }
