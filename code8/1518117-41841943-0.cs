    class Program
        {
            static void Main(string[] args)
            {
                List<SANFabric> Fabrics = new List<SANFabric>() ;
                Dictionary<string,SANSwitch> _swDict=new Dictionary<string,SANSwitch>();
                _swDict.Add("A", new SANSwitch() { SwitchWWPN = new List<string>() { "CDEFGHIJKLMNOPQRSTUVWXYZ", "CDEFGHIJKLMNOPQRSTUVWXYZ12333" }, 
                                                    VirtualWWNList = new Dictionary<string, string>() { 
                                                                                                        {"ABC","55555555"},
                                                                                                        {"DEF","993383838"}
                                                                                                      } 
                                                 }
                                                 );
    
                _swDict.Add("B", new SANSwitch()
                                                {
                                                    SwitchWWPN = new List<string>() { "KGBIFBGKLMPQUERREE", "CDEFGHIKGBIFBGKLMPQUERREEXYZ12333" },
                                                    VirtualWWNList = new Dictionary<string, string>() { 
                                                                                                                                        {"GHI","8888383"},
                                                                                                                                        {"JKL","00933939"}
                                                                                                                                      }
                                                });
    
                Fabrics.Add(new SANFabric()
                {
                    MemberSwitches = _swDict
                });
    
                var f1 = Fabrics.Where(t => t.IsFabricMember("55555555")).ToList();
                var f2 = Fabrics.Where(t => t.IsFabricMember("CDEFGHIJKLMNOPQRSTUV")).ToList();
                Console.WriteLine("# of items to be member: {0},{1}",f1.Count,f2.Count);
                Console.ReadKey();
            }
        }
        public class SANSwitch
        {        
            public Dictionary<string,string> VirtualWWNList {get;set;}
            
            public List<string> SwitchWWPN {get;set;}
    
            public bool HasWWN(string wwn)
            {
                bool test = false;
                if (wwn.StartsWith("55")) { test = VirtualWWNList.Values.Contains(wwn); }
                else { test = SwitchWWPN.Contains(wwn.Substring(0, 20)); }
    
                return test;
            }
        }
    
        public class SANFabric
        {
            // dictionary of switch WWPNs and SANSwitch objects
            public Dictionary<string, SANSwitch> MemberSwitches { get; set; }
    
            public bool IsFabricMember(string wwn)
            {
                var found = MemberSwitches.Values.Where(t => t.HasWWN(wwn)).ToList();
                if (found.Count() > 0) { return true; }
                else { return false; }
            }
        }
