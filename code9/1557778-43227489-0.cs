    namespace Foo.Services.Core.Models
    {
        public class Foo
        {
           ...
        }
    }
    
    namespace Foo.Services.Core.DataServices
    {
        public interface IFooService
        {
            Task<Foo> GetByIdAsync( int id );
        } 
    }
