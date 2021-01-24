    public partial class attendance : Form
    {
        private Capture cam1, cam2, cam3, cam4;
        private CascadeClassifier _cascadeClassifier;
        private RecognizerEngine _recognizerEngine;
        private String _trainerDataPath = "\\traineddata_v2";
        private readonly String dbpath = "Server=localhost;Database=faculty_attendance_system;Uid=root;Pwd=root;";
        MySqlConnection conn;
        public attendance()
        {
            InitializeComponent();
            conn = new MySqlConnection("Server=localhost;Database=faculty_attendance_system;Uid=root;Pwd=root;");
        }
        private void btn_home_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void attendance_Load(object sender, EventArgs e)
        {
            time_now.Start();
            lbl_date.Text = DateTime.Now.ToString("");
            _recognizerEngine = new RecognizerEngine(dbpath, _trainerDataPath);
            _cascadeClassifier = new CascadeClassifier(Application.StartupPath + "/haarcascade_frontalface_default.xml");
            cam1 = new Capture(0);
            cam2 = new Capture(1);
            cam3 = new Capture(3);
            cam4 = new Capture(4);
            Application.Idle += new EventHandler(ProcessFrame);
        }
        private void ProcessFrame(Object sender, EventArgs args)
        {
            using (Image<Bgr, byte> nextFrame_cam1 = cam1.QueryFrame().ToImage<Bgr, Byte>())
            {
                if (nextFrame_cam1 != null)
                {
                    Image<Gray, byte> grayframe = nextFrame_cam1.Convert<Gray, byte>();
                    var faces = _cascadeClassifier.DetectMultiScale(grayframe, 1.5, 10, Size.Empty, Size.Empty);
                    foreach (var face in faces)
                    {
                        nextFrame_cam1.Draw(face, new Bgr(Color.Green), 3);
                        var predictedUserId = _recognizerEngine.RecognizeUser(new Image<Gray, byte>(nextFrame_cam1.Bitmap));
                    }
                    imageBox1.Image = nextFrame_cam1;
                }
            }
            using (Image<Bgr, byte> nextFrame_cam2 = cam2.QueryFrame().ToImage<Bgr, Byte>())
            {
                if (nextFrame_cam2 != null)
                {
                    Image<Gray, byte> grayframe = nextFrame_cam2.Convert<Gray, byte>();
                    var faces = _cascadeClassifier.DetectMultiScale(grayframe, 1.5, 10, Size.Empty, Size.Empty);
                    foreach (var face in faces)
                    {
                        nextFrame_cam2.Draw(face, new Bgr(Color.Green), 3);
                        var predictedUserId = _recognizerEngine.RecognizeUser(new Image<Gray, byte>(nextFrame_cam2.Bitmap));
                    }
                    imageBox2.Image = nextFrame_cam2;
                }
            }
            using (Image<Bgr, byte> nextFrame_cam3 = cam3.QueryFrame().ToImage<Bgr, Byte>())
            {
                if (nextFrame_cam3 != null)
                {
                    Image<Gray, byte> grayframe = nextFrame_cam3.Convert<Gray, byte>();
                    var faces = _cascadeClassifier.DetectMultiScale(grayframe, 1.5, 10, Size.Empty, Size.Empty);
                    foreach (var face in faces)
                    {
                        nextFrame_cam3.Draw(face, new Bgr(Color.Green), 3);
                        var predictedUserId = _recognizerEngine.RecognizeUser(new Image<Gray, byte>(nextFrame_cam3.Bitmap));
                    }
                    imageBox3.Image = nextFrame_cam3;
                }
            }
            using (Image<Bgr, byte> nextFrame_cam4 = cam4.QueryFrame().ToImage<Bgr, Byte>())
            {
                if (nextFrame_cam4 != null)
                {
                    Image<Gray, byte> grayframe = nextFrame_cam4.Convert<Gray, byte>();
                    var faces = _cascadeClassifier.DetectMultiScale(grayframe, 1.5, 10, Size.Empty, Size.Empty);
                    foreach (var face in faces)
                    {
                        nextFrame_cam4.Draw(face, new Bgr(Color.Green), 3);
                        var predictedUserId = _recognizerEngine.RecognizeUser(new Image<Gray, byte>(nextFrame_cam4.Bitmap));
                    }
                    imageBox4.Image = nextFrame_cam4;
                }
            }
        }
    }
