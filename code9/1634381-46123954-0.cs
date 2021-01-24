    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }
        public enum PasswordScore
        {
            Blank = 0,
            VeryWeak = 1,
            Weak = 2,
            Medium = 3,
            Strong = 4,
            VeryStrong = 5
        }
        public static PasswordScore CheckStrength(string password)
        {
            int score = 0;
            if (password.Length == 0)
                return PasswordScore.Blank;
            if (password.Length < 4)
                return PasswordScore.VeryWeak;
            if (password.Length >= 8)
                score++;
            if (password.Length >= 12)
                score++;
            if (Regex.Match(password, @"\d", RegexOptions.ECMAScript).Success)
                score++;
            if (Regex.Match(password, @"[a-z]", RegexOptions.ECMAScript).Success &&
              Regex.Match(password, @"/[A-Z]/", RegexOptions.ECMAScript).Success)
                score++;
            if (Regex.Match(password, @"/.[!,@,#,$,%,^,&,*,?,_,~,-,£,(,)]/", RegexOptions.ECMAScript).Success)
                score++;
            return (PasswordScore)score;
        }
        public void button1_Click(object sender, EventArgs e)
        {
            
            String password = textBox1.Text; // Substitute with the user input string
            PasswordScore passwordStrengthScore = Form7.CheckStrength(password);
            switch (passwordStrengthScore)
            {
                case PasswordScore.Blank:
                case PasswordScore.VeryWeak:
                case PasswordScore.Weak:
                    // Show an error message to the user
                    break;
                case PasswordScore.Medium:
                case PasswordScore.Strong:
                case PasswordScore.VeryStrong:
                    // Password deemed strong enough, allow user to be added to database etc
                    break;
            }
            if (passwordStrengthScore == PasswordScore.Blank) { Result.Text = "Blank"; }
            if (passwordStrengthScore == PasswordScore.VeryWeak) { Result.Text = "Very Weak - FAIL"; }
            if (passwordStrengthScore == PasswordScore.Weak) { Result.Text = "Weak - FAIL"; }
            if (passwordStrengthScore == PasswordScore.Medium) { Result.Text = "Medium - Compliant"; }
            if (passwordStrengthScore == PasswordScore.Strong) { Result.Text = "Strong - Compliant"; }
            if (passwordStrengthScore == PasswordScore.VeryStrong) { Result.Text = "Very Strong - Compliant"; }
            
        }
