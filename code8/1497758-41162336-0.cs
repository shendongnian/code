    
    public class AudioManager : MonoBehaviour
    {
      private AudioSource source;
      
      // Called regardless of whether the object is enabled or not.
      // Should not be called in a new scene.
      private void Awake()
      {
        // Protect this object from being destroyed so its volume
        // is maintained between scenes.
        DontDestroyOnLoad(this.gameObject);
        source = GetComponent<AudioSource>();
      }    
      public void DestroyPossibleDuplicates()
      {
        AudioManager[] managers = FindObjectsOfType(typeof(AudioManager)) as AudioManager[];
        foreach (AudioManager manager in managers)
        {
          // Use something to determine whether a manager is a duplicate.
          // It must not be this, but have something in common; a name perhaps?
          if ((manager != this) && (manager.gameObject.name == this.gameObject.name))
          {
            // Destroy the duplicates so their sound won't interfere.
            Destroy(manager.gameObject);
          }
        }
      }
      private void BindToInterface()
      {
        Slider[] sliders = FindObjectsOfType(typeof(Slider)) as Slider[];
        foreach (Slider slider in sliders)
        {
          // Determine whether the specified slider should have effect on this object.
          // If the slider's name contains this object's name assume it should.
          if (slider.gameObject.name.indexOf(this.gameObject.name)!=-1)
          {
            slider.onValueChanged.addListener((float value)=>
            {
              // In this case a slider is used for more control over the volume.
              // Different elements require other logic to function.
              source.volume = value;
            });
          }
        }
      }
      
      // If my memory serves correct this method is only called on objects 
      // that were in the scene before it started loading.
      // Just to be safe, don't have it do anything depending on this difference.
      private void OnLevelWasLoaded()
      {
        DestroyPossibleDuplicates();
        BindToInterface();
      }     
    }
