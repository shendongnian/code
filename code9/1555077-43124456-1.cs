    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System;
    namespace Serialize
    {
        public class Shipping
        {
            [JsonProperty(PropertyName = "shipping_name")]
            public String Name { get; set; }
            [JsonProperty(PropertyName = "shipping_img")]
            public String Img { get; set; }
            [JsonProperty(PropertyName = "shipping_code")]
            public String Code { get; set; }
        }
        public class Order
        {
            public Shipping shipping { get; set; }
            [JsonProperty(PropertyName = "order_sn")]
            public string SerialNumber { get; set; }
            [JsonProperty(PropertyName = "order_status")]
            public string Status { get; set; }
        }
        class Program
        {
            static void Main(string[] args)
            {
                /*
                 {
                 "status":1,
                 "msg": {
                     "dynamic_name": {
                         "order_sn": "12312313123123123",
                         "order_status":"0",
                         "shipping_info": [{
                             "shipping_name":"name",
                             "shipping_no":"",
                             "shipping_img":"img",
                             "shipping_code":"code",
                             "shipping_time":"",
                             "track_goods":""
                         }]
                     }
                 },
                 "errcode":0
                 }
                 * */
                var raw = "{ \"status\":1, \"msg\":{\"dynamic_name\":{\"order_sn\":\"12312313123123123\",\"order_status\":\"0\",\"shipping_info\":[{\"shipping_name\":\"name\",\"shipping_no\":\"\",\"shipping_img\":\"img\",\"shipping_code\":\"code\",\"shipping_time\":\"\",\"track_goods\":\"\"}]}},\"errcode\":0}";
                var incomingOrder = new Order();
                // properties on dynamic objects are evaluated at runtime
                dynamic msgJson = JObject.Parse(raw);
                // you'll want exception handling around all of this
                var order = msgJson.msg.dynamic_name;
                // accessing properties is easy (if they exist, as these do)
                incomingOrder.SerialNumber = order.order_sn;
                incomingOrder.Status = order.order_status;
                // JObject cast might not be necessary. need to check for array elements, etc.
                // but it's simple to serialize into a known type
                incomingOrder.shipping = ((JObject)(order.shipping_info[0])).ToObject<Shipping>();
            }
        }
    }
