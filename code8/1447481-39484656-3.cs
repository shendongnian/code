    public class Program
    {
        static public void Main()
        {
            string json = "{ \"result\":{ \"count\":\"3\" }, \"content_1\":{ \"message_id\":\"23\", \"originator\":\"09973206870\", \"message\":\"Hello\", \"timestamp\":\"2016-09-14 13:59:47\" }, \"content_2\":{ \"message_id\":\"24\", \"originator\":\"09973206870\", \"message\":\"Test again.\", \"timestamp\":\"2016-09-14 14:49:14\" }, \"content_3\":{ \"message_id\":\"25\", \"originator\":\"09973206870\", \"message\":\"Another message\", \"timestamp\":\"2016-09-14 14:49:20\" } }";
    			    
    		RootObject ro = JsonConvert.DeserializeObject<RootObject>(json);
    		
    		Console.WriteLine(ro.content_1.message_id);
    		Console.WriteLine(ro.content_2.message_id);    				
        }
    }
