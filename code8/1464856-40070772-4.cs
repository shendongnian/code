    //in Form.Designer.cs
    public partial class Form1 {
      private InitializeComponent() {
        //Code of the Designer
        this.button1.Text = "My Fancy Button";
        this.button1.Click += this.button_click;
        //Code of the Designer
        this.button2.Text = "My Other Fancy Button";
        this.button2.Click += this.button_click;
        //Code of the Designer
      }
    }
    //in Form.cs
    public class Form1 : Form {
      //Constructor
      public Form1 () {
        InitializeComponent();
        this.SetupSpeechTexts();
      }
      private Dictonary<Control, string> speechTextDict = new Dictonary<Control, string>();
    
      private void SetupSpeechTexts() {
        this.speechTextDict.Add(this.button1, "First Text");
        this.speechTextDict.Add(this.button2, "Second Text");
        ...
      }
    
      private void button_click(object sender, EventArgs e) {
        Control senderControl = (Control)sender;
        if(this.speechTextDict.ContainsKey(senderControl)) {
          speaker.Speak(this.speechTextDict[senderControl]);
          speaker.Rate = -2;
          speaker.SelectVoiceByHints(VoiceGender.Female);
        }
      }
    }
   
