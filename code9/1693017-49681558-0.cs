    public class attachment : ApiController
    {
        [System.Web.Http.HttpPost]
        public JsonResult saveattachment(SaveAttachmentRequest sar, AttachmentLookupInformation ali)
        {          
            //string bits = "000011110000001000";
            string bits = sar.strAttachment;
            int numOfBytes = (int)Math.Ceiling(bits.Length / 8m);
            byte[] bytes = new byte[numOfBytes];
            int chunkSize = 8;
            for (int i = 1; i <= numOfBytes; i++)
            {
                int startIndex = bits.Length - 8 * i;
                if (startIndex < 0)
                {
                    chunkSize = 8 + startIndex;
                    startIndex = 0;
                }
                bytes[numOfBytes - i] = Convert.ToByte(bits.Substring(startIndex, chunkSize), 2);
            }
            
            sar.attachment = bytes;
        }
    }
