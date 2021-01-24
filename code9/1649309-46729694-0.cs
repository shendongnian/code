    using System;
    using Ninject;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace NinjectPlayGround
    {   
        class Program
        {
            static void Main(string[] args)
            {
                var kernel = new StandardKernel();
    
                //How to bind this?
                kernel.Bind<ICreateOrders<IOrderRequest, IOrderResponse>>().To(typeof(OrderCreator));
                kernel.Bind<ICreateOrders<IOrderRequest, IOrderResponse>>().To(typeof(HorseOrderCreator));
    
                kernel.Bind<IOrderCreatorFactory>().To<OrderCreatorFactory>();
    
                var factory = kernel.Get<IOrderCreatorFactory>();
    
                var orderCreator = factory.GetOrderCreator(new OrderRequest());
                var orderResponse = orderCreator.Create(new OrderRequest());    
                if (!(orderResponse is OrderResponse)) throw new InvalidCastException();
    
                var horseOrderCreator = factory.GetOrderCreator(new HorseOrderRequest());
                var horseResponse = horseOrderCreator.Create(new HorseOrderRequest());    
                if (!(horseResponse is HorseOrderResponse)) throw new InvalidCastException();
                Console.WriteLine("All resolutions successfull");
                Console.ReadLine();
    
            }
        }
        public class OrderRequest : IOrderRequest
        {
    
        }
        public class OrderResponse : IOrderResponse
        {
    
        }
        public class HorseOrderRequest : IOrderRequest
        {
    
        }
        public class HorseOrderResponse : IOrderResponse
        {
            public string HorseName { get; set; }
        }
    
        public abstract class BaseOrderCreator<TOrderRequest, TOrderResponse> : ICreateOrders<IOrderRequest, IOrderResponse> where TOrderRequest : IOrderRequest where TOrderResponse : IOrderResponse
        {
            public bool CanHandle(IOrderRequest request)
            {
                return request is TOrderRequest;
            }
    
            public abstract TOrderResponse SpecificCreate(TOrderRequest orderRequest);
    
            public IOrderResponse Create(IOrderRequest orderRequest)
            {
                return this.SpecificCreate((TOrderRequest)orderRequest);
            }
        }
    
        public class HorseOrderCreator : BaseOrderCreator<HorseOrderRequest, HorseOrderResponse>
        {
            public override HorseOrderResponse SpecificCreate(HorseOrderRequest orderRequest)
            {
                return new HorseOrderResponse() { HorseName = "Fred" };
            }
        }
        public class OrderCreator : BaseOrderCreator<OrderRequest, OrderResponse>
        {
            public override OrderResponse SpecificCreate(OrderRequest orderRequest)
            {
                return new OrderResponse();
            }
        }
        public class OrderCreatorFactory : IOrderCreatorFactory
        {
            private readonly IEnumerable<ICreateOrders<IOrderRequest, IOrderResponse>> createOrders;
            public OrderCreatorFactory(IEnumerable<ICreateOrders<IOrderRequest, IOrderResponse>> createOrders)
            {
                this.createOrders = createOrders;
            }
    
            public ICreateOrders<IOrderRequest, IOrderResponse> GetOrderCreator(IOrderRequest orderRequest)
            {
                return createOrders.FirstOrDefault(co => co.CanHandle(orderRequest));
            }
        }
        public interface ICreateOrders<in TOrderRequest, out TOrderResponse> where TOrderRequest : IOrderRequest where TOrderResponse : IOrderResponse
        {
            bool CanHandle(IOrderRequest request);
    
            TOrderResponse Create(TOrderRequest orderRequest);
        }
        public interface IOrderCreatorFactory
        {
            ICreateOrders<IOrderRequest, IOrderResponse> GetOrderCreator(IOrderRequest orderRequest);
        }
        public interface IOrderRequest
        {
    
        }
        public interface IOrderResponse
        {
    
        }
    }
