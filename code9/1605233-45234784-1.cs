    	public class DefaultTemplateManager : IDefaultTemplateManager {
    
    		protected IRepository<MyEntity1> MyEntityRepo1 { get; set; }
    		protected IRepository<MyEntity2> MyEntityRepo2 { get; set; }
    		protected IRepository<MyEntity3> MyEntityRepo3 { get; set; }
    		protected IRepository<MyEntity4> MyEntityRepo4 { get; set; }
    		protected IRepository<MyEntity5> MyEntityRepo5 { get; set; }
    		protected IRepository<MyEntity6> MyEntityRepo6 { get; set; }
    
    		public DefaultTemplateManager(IRepository<MyEntity1> MyEntityRepository1, IRepository<MyEntity2> MyEntityRepository2, IRepository<MyEntity3> MyEntityRepository3, IRepository<MyEntity4> MyEntityRepository4, IRepository<MyEntity5> MyEntityRepository5, IRepository<MyEntity6> MyEntityRepository6, ) {
    			this.MyEntityRepo1 = MyEntityRepository1;
    			this.MyEntityRepo2 = MyEntityRepository2;
    			this.MyEntityRepo3 = MyEntityRepository3;
    			this.MyEntityRepo4 = MyEntityRepository4;
    			this.MyEntityRepo5 = MyEntityRepository5;
    			this.MyEntityRepo6 = MyEntityRepository6;
    		}
    
    		public ProcessResponse Process(string UniqueKey) {
    		    /* Do Work */
    		}
