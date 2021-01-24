            using System;
            using System.IO;
            using System.Windows;
            namespace Stackoverflow_question
            {
                public partial class MainWindow : Window
                {
                    public MainWindow()
                    {
                        InitializeComponent();
                        string curDir = Directory.GetCurrentDirectory();
                        webbrowser1.Navigate(new Uri(String.Format("file:///{0}/test.html", curDir))) ;
                    }
                }
            }
