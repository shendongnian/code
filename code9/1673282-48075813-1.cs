    public class Functions
        {
            /// <summary>
            ///  pass the content from Queue to Blob(The content is from myfile.txt)
            /// </summary>
            /// <param name="model"></param>
            /// <param name="orderBlob"></param>
            public static void MultipleOutput(
                 [QueueTrigger("myqueue2")] AudioSampleEntityModel model,
                 [Blob("orders/myfile")] out string orderBlob) //create a container named 'orders'
            {
                orderBlob = model.SampleBlob;    //store the content from SampleBlob property to Blob
            }
    }
