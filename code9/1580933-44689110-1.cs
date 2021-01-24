       public class MyEntityAppService: IMyEntityAppService {
        private readonly IRepository < MyEntity, string > _myEntityRepository;
    
        public AccountAppService(IRepository < MyEntity, string > myEntityRepository) {
         _myEntityRepository = myEntityRepository;
        }
    
        public void Test() {
         _myEntityRepository.Insert(new MyEntity {
                                       MyIntField = 1, 
                                       MyStringField = "test", 
                                       OtherField = "Alper Ebicoglu"
                                    });
    
         var myAllEntities = _myEntityRepository.GetAllList();
    
         var myFilteredEntity = _myEntityRepository.Single(s => s.MyIntField == 1 &&
                                                        s.MyStringField == "test");
    
        }
    
        // ...
       }
