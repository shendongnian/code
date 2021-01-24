    namespace MusicService {
        public interface IService {
            //propably a List<IAlbum> and List<IA> somewhere in here
            void Sync();
        }
    
        public class SyncService {
            internal List<IService> _services;
        
            public void AddService(IService musicService) {
                if(_services==null){_services=new List<IService>();}
                _services.Add(musicService);
            }
            
            public void Sync() {
                foreach(IService ms in _services) {
                    ms.Sync();
                }
            }
        }
    }
    namespace MusicService.AppleMusic {
        internal AppleSyncService:IService {
            public AppleSyncService() {
                //Do your apple-specific initializations here
            }
            public void Sync() {
                //apple-sync
            }
        }
        
        internal class ExtendService(){
            public static void AddAppleMusic(this SyncService syncAgent) {
               syncAgent.AddService(new AppleSyncService());
            }            
        }
    }
