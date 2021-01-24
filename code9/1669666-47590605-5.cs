    class MyDTO
    {
        public int type{get;set;}
        public string body {get;set;}
        public int time {get;set;}
        public string[][] ip{get;set;}
        public string hash {get;set;}
        public string exclude {get;set;}
    }
    
    void Main()
    {
        var myDto=new MyDTO{
            type=2,
            body="Hello",
            time=120000,
            ip=new []{
                new []{
                    "192.168.10.1-192.168.10.254",
                    "192.168.11.1-192.168.11.254",
                    "192.168.12.1-192.168.11.20",
                    "192.168.1.5-192.168.1.50"
                }
            },
            hash="6e42b725e351576d123ba7d4fc1b48863e4485821e0edb73abb8801a09a99bc7",
            exclude = "127.0.0.1"
        };
        
        var json=JsonConvert.SerializeObject(myDto,Newtonsoft.Json.Formatting.Indented);
        Console.WriteLine(json);
    }
