    public class StreamingController : ApiController
    {
        // GET: api/Streaming/5
        public HttpResponseMessage Get(long RecordCount)
        {
            var response = Request.CreateResponse();
            response.Content=new PushStreamContent((stream, http, transport) =>
            {
                RecordsGenerator Generator = new RecordsGenerator();
                long i;
                using(var writer = new System.IO.StreamWriter(stream, System.Text.Encoding.UTF8))
                {
                    for(i=0; i<RecordCount; i++)
                    {
                        writer.Write(Generator.GetRecordString(i));
                        if(0==(i&0xFFFFF))
                            System.Diagnostics.Debug.WriteLine($"Record no: {i:N0}");
                        }
                    }
                });
                return response;
            }
            class RecordsGenerator
            {
                const string abc = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                char[] Chars = new char[14];//Ceiling(log26(2^63))
                public string GetRecordString(long Record)
                {
                    int iLength = 0;
                    long Div = Record, Mod;
                    do
                    {
                        iLength++;
                        Div=Math.DivRem(Div, abc.Length, out Mod);
                        //Save from backwards
                        Chars[Chars.Length-iLength]=abc[(int)Mod];
                    }
                    while(Div!=0);
                    return $"{Record} {new string(Chars, Chars.Length-iLength, iLength)}\r\n";
                }
            }
        }
    }
