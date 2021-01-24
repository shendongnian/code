    public interface IAudioPlayerService {
         bool PlayAudio(string file);
         bool PauseAudio();
         bool StopAudio();
    }
    [assembly: Xamarin.Forms.Dependency (typeof (IAudioPlayerService))]
    public class AudioPlayerService : IAudioPlayerService {
          //implement your methods
    }
