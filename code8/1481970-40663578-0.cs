    using System;
    using System.Globalization;
    
    namespace ConsoleApplication1
    {
    	class Program
    	{
    		public enum OrderInfoStatus
    		{
    			Failure = 0,
    			Success = 1
    		}
    
    		class OrderReq
    		{
    			public string RequestedProcessDate { get; set; }
    		}
    
    		class OrderInfo
    		{
    			public OrderInfoStatus Status { get; set; }
    			public string OrderNumber { get; set; }
    			public string Notes { get; set; }
    		}
    
    		class Order
    		{
    			public DateTime ProcessDate { get; set; }
    			public DateTime ProcessReqDate { get; set; }
    			public DateTime PODate { get; set; }
    		}
    
    		void X(OrderReq orderReq, Order order, OrderInfo orderInfo, string orderNo)
    		{
    			DateTime dateField;
    			bool isValidRequestedProcessDate = DateTime.TryParseExact(orderReq.RequestedProcessDate, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateField);
    
    			bool isGoodDate = true;
    			string problemArea = string.Empty;
    
    			if (!isValidRequestedProcessDate)
    			{
    				isGoodDate = false;
    				problemArea = "Could not parse requested process date.";
    			}
    			else if (dateField < DateTime.Today)
    			{
    				isGoodDate = false;
    				problemArea = "Requested process date is before today.";
    			}
    			else if (dateField > order.PODate)
    			{
    				isGoodDate = false;
    				problemArea = "Requested process date is after PO date.";
    			}
    
    			if (isGoodDate)
    			{
    				orderInfo.Status = OrderInfoStatus.Success;
    				orderInfo.OrderNumber = orderNo;
    				order.ProcessDate = DateTime.Now;
    			}
    			else
    			{
    				orderInfo.Status = OrderInfoStatus.Failure;
    				orderInfo.OrderNumber = orderNo;
    				orderInfo.Notes = "Invalid Request Delivery Date: " +
    					orderReq.RequestedProcessDate +
    					" (yyyy-MM-dd) - " +
    					problemArea +
    					Environment.NewLine;
    				order.ProcessReqDate = DateTime.Today;
    				//orderFailed = true; /* use orderInfo.Status for this instead */
    			}
    
    		}
    
    		static void Main(string[] args)
    		{
    		}
    	}
    }
