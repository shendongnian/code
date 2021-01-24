     public partial class Window2 {
    
        public Window2() {
          InitializeComponent();
    
          for (int i = 0; i < 10; i++) {
            var s = new Scene() { Name = "Scene " + i };
            for (int j = 0; j < 2; j++) {
              var c = new Character() { Name = "Character " + j };
              s.Characters.Add(c);
            }
            this.Scenes.Add(s);
          }
    
          this.DataContext = this;
        }
    
        void AddSelectedCharacterExecute(object param) {
          MessageBox.Show("Adding character");
          return;
        }
    
        public ICommand AddSelectedCharacter {
          get {
            return new RelayCommand(AddSelectedCharacterExecute, o => true);
          }
        }
    
        private List<Scene> _scenes = new List<Scene>();
        public List<Scene> Scenes => this._scenes;
    
      }
    
      public class Scene {
        public Scene() {
          this.Characters = new List<Character>();
        }
    
        public string Name {
          get; set;
        }
    
        public List<Character> Characters {
          get;
        }
    
      }
    
      public class Character {
    
        public string Name {
          get; set;
        }
    
      }
