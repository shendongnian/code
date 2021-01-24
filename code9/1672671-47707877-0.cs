    using System;
    using System.Drawing;
    using System.Windows.Forms;
    
    namespace Alphabets
    {
        public partial class Form1 : Form
        {
            private Button[] _letters;
    
            public Form1()
            {
                InitializeComponent();
                AddButtonsToForm();
            }
    
            private void AddButtonsToForm()
            {
                _letters = new Button[26];
                for (int i = 0; i < 26; i++)
                {
                    Button currentNewButton = new Button
                    {
                        Name = "BtnLetter"+ ((char)(65 + i)),
                        Size = new Size(20, 30),
                        Location = new Point(20 + 25 * i, 420),
                        Text = ((char) (65 + i)).ToString()
                    };
                    currentNewButton.Click += LetterClicked;
                    _letters[i] = currentNewButton;
                    this.Controls.Add(_letters[i]);
                }
            }
    
            private void LetterClicked(object sender, EventArgs e)
            {
                var selectedLetter = (Button) sender;
                //hide all other buttons
                foreach (var letter in _letters)
                {
                    if (letter.Text != selectedLetter.Text)
                    {
                        var buttons = this.Controls.Find("BtnLetter" + letter.Text, true);
                        buttons[0].Enabled = false;
                    }
                }
            }
        }
    }
