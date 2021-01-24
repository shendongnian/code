	using System;
	using System.IO;
	using System.Windows;
	using Microsoft.Win32;
	namespace WpfTutorialSamples.Dialogs
	{
			public partial class OpenFileDialogSample : Window
			{
					public OpenFileDialogSample()
					{
							InitializeComponent();
					}
					private void btnOpenFile_Click(object sender, RoutedEventArgs e)
					{
							OpenFileDialog openFileDialog = new OpenFileDialog();
							if(openFileDialog.ShowDialog() == true)
									txtEditor.Text = File.ReadAllText(openFileDialog.FileName);
					}
			}
	}
