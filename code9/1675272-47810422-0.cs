    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using System.IO;
    
    namespace frmSplashScreen
    {
        public partial class frmLevel3 : Form
        {
            public frmLevel3()
            {
                InitializeComponent();
            }
          
            int questionsshown = 0; //to go up to 4
            int questionno = 0;
            string currentq = null;
            string currenta = null;
            
    
            public void randomq() //new question function... generating number, using it as index, putting it on lblQ
            {
                Random ran = new Random();
                questionno = ran.Next(20);
                currentq = gameClass.questions[questionno];
                currenta = gameClass.answers[questionno];
                lblQ.Text = currentq;
                
                gameClass.questions.RemoveAt(questionno);
                gameClass.answers.RemoveAt(questionno);
            }
    
            private void frmLevel3_Load(object sender, EventArgs e) // Load //
            {
                gameClass.time = 16;
                tmrCountdown.Start();
                this.BackgroundImage = gameClass.background; //settings bg
                btnNext.Hide();
                
                using (StreamReader sr = new StreamReader("l3questions.txt")) //reading all questions from text file
                {
                    string line;
                    while ((line = sr.ReadLine()) != null) 
                    {
                        gameClass.questions.Add(line);
                    }
                    
                }
                using (StreamReader sr = new StreamReader("l3answers.txt")) //reading all answers from text file
                {
                    string line;
                    while ((line = sr.ReadLine()) != null) 
                    {
                        gameClass.answers.Add(line);
                    }
                }
                
    
                if (gameClass.background != null)
                {
                    lblQ.ForeColor = Color.White;
                    lblScore.ForeColor = Color.White;
                }
    
                randomq();
    
                Console.WriteLine(currentq);
                Console.WriteLine(currenta);
                Console.WriteLine(questionno);
            }
    
            private void btnNext_Click(object sender, EventArgs e) // Next Button //
            {
                if (questionsshown >= 4) // Checking no. of questions shown 
                {
                    tmrCountdown.Stop();
                    frmMainMenu menu = new frmMainMenu(); //Go to Menu
                    this.Hide();
                    MessageBox.Show("You have completed level 3 with a score of " + gameClass.score);
                    menu.Show();
                }
                else
                {
                    questionsshown++;
                    gameClass.time = 16;
                    btnNext.Hide();
                    btnCheck.Show();
                    randomq();
                    tmrCountdown.Start();
                }
              
                txt1a.BackColor = Color.White; //Setting txts back to normal
                txt1a.Text = null;
                Console.WriteLine(currentq);
                Console.WriteLine(currenta);
                Console.WriteLine(questionno);
            }
    
            public void check()
            {
                tmrCountdown.Stop();
                gameClass.time = 16;
    
                btnCheck.Hide();
                btnNext.Show();
                if (txt1a.Text.ToLower() == currenta) //checking question
                {
                    gameClass.score++;
                    lblScore.Text = "Score: " + gameClass.score.ToString();
                    txt1a.BackColor = Color.Green;
                }
                else
                {
                    txt1a.BackColor = Color.Red;
                }
            }
            private void btnCheck_Click(object sender, EventArgs e) // Check Button //
            {
                check();
               
            }
    
            private void picHelp_Click(object sender, EventArgs e)
            {
                frmHelp help = new frmHelp();
                this.Hide();
                help.Show();
                tmrCountdown.Stop();
            }
    
            private void picHome_Click(object sender, EventArgs e)
            {
                tmrCountdown.Stop();
                frmMainMenu menu = new frmMainMenu();
                this.Hide();
                menu.Show();
                
            }
    
            private void lblQ_Click(object sender, EventArgs e)
            {
                
            }
    
            private void menuToolStripMenuItem_Click(object sender, EventArgs e)
            {
                frmMainMenu menu = new frmMainMenu();
                this.Hide();
                menu.Show();
            }
    
            private void helpToolStripMenuItem_Click(object sender, EventArgs e)
            {
                frmHelp help = new frmHelp();
                this.Hide();
                help.Show();
                tmrCountdown.Stop();
            }
    
            private void level1ToolStripMenuItem_Click(object sender, EventArgs e)
            {
                frmLevel1 l1 = new frmLevel1();
                this.Hide();
                l1.Show();
                tmrCountdown.Stop();
            }
    
            private void level2ToolStripMenuItem_Click(object sender, EventArgs e)
            {
                frmLevel2 l2 = new frmLevel2();
                this.Hide();
                l2.Show();
                tmrCountdown.Stop();
            }
    
            private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
            {
                frmLogin login = new frmLogin();
                this.Hide();
                login.Show();
                tmrCountdown.Stop();
            }
    
            private void tmrCountdown_Tick_1(object sender, EventArgs e)
            {
                
                gameClass.time--;
                lblCountdown.Text = "Time left: " + gameClass.time.ToString();
    
                if (gameClass.time == 0 && this.Name == "frmLevel3")
                {
                    tmrCountdown.Stop();
                    MessageBox.Show("You have run out of time!");
                    questionsshown++;
                    check();
                }
                label1.Text = this.Name;
                   
            }
        }
    }
