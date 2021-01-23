    namespace Data
    {
        public class FakeRepo : IFakeRepo
        {
            public IThisIsAnEntity GetEntity()
            {
                return new ThisIsAnEntity();
            }
        }
        public class ThisIsAnEntity : IThisIsAnEntity
        {
            public string HiddenField { get; set; }
            public long Id { get; set; }
            public string SomeField { get; set; }
            public string AnotherField { get; set; }
        }
    }
    namespace Data.Abstractions
    {
        public interface IFakeRepo
        {
            IThisIsAnEntity GetEntity();
        }
    }
    namespace Abstractions
    {
        public interface IThisIsAnEntity : IThisIsAnSlimmedDownEntity
        {
            string SomeField { get; set; }
        }
        public interface IThisIsAnSlimmedDownEntity
        {
            long Id { get; set; }
            string AnotherField { get; set; }
        }
    }
    namespace Services.Abstractions
    {
        public interface ISomeBusinessLogic
        {
            IThisIsAnEntity GetEntity();
            IThisIsAnSlimmedDownEntity GetSlimmedDownEntity();
        }
    }
    namespace Services
    {
        public class SomeBusinessLogic : ISomeBusinessLogic
        {
            private readonly IFakeRepo _repo;
            public SomeBusinessLogic(IFakeRepo repo)
            {
                _repo = repo;
            }
            public IThisIsAnEntity GetEntity()
            {
                return _repo.GetEntity();
            }
            public IThisIsAnSlimmedDownEntity GetSlimmedDownEntity()
            {
                return _repo.GetEntity();
            }
        }
    }
    namespace UI
    {
        public class SomeUi
        {
            private readonly ISomeBusinessLogic _service;
            public SomeUi(ISomeBusinessLogic service)
            {
                _service = service;
            }
            public IThisIsAnSlimmedDownEntity GetViewModel()
            {
                return _service.GetSlimmedDownEntity();
            }
            public IComposite GetCompositeViewModel()
            {
                var dto = _service.GetSlimmedDownEntity();
                var viewModel = Mapper.Map<IThisIsAnSlimmedDownEntity, IComposite>(dto);
                viewModel.SomethingSpecial = "Something else";
                return viewModel;
            }
        }
        
        public class SomeViewModel : IComposite
        {
            public long Id { get; set; }
            public string AnotherField { get; set; }
            public string SomethingSpecial { get; set; }
        }
        
    }
    namespace UI.Abstractions
    {
        public interface IComposite : IThisIsAnSlimmedDownEntity, ISomeExtraInfo
        {
        }
        public interface ISomeExtraInfo
        {
            string SomethingSpecial { get; set; }
        }
    }
