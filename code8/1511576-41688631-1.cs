      private AudioFileInputNode fileInput;
      private AudioFileOutputNode fileOutputNode;
      private AudioDeviceOutputNode deviceOutput;
      private AudioGraph graph;
      StorageFile outputfile;
      public MainPage()
      {
          this.InitializeComponent();
      }
      protected override async void OnNavigatedTo(NavigationEventArgs e)
      {
          await CreateAudioGraph();
      }
      private async Task CreateAudioGraph()
      {
          // Create an AudioGraph with default settings
          AudioGraphSettings settings = new AudioGraphSettings(AudioRenderCategory.Media);
          CreateAudioGraphResult result = await AudioGraph.CreateAsync(settings);
          if (result.Status != AudioGraphCreationStatus.Success)
          {
              // Cannot create graph
              await new MessageDialog(String.Format("AudioGraph Creation Error because {0}", result.Status.ToString())).ShowAsync();
              return;
          }
          graph = result.Graph;
          // Create a device output node
          CreateAudioDeviceOutputNodeResult deviceOutputNodeResult = await graph.CreateDeviceOutputNodeAsync();
          if (deviceOutputNodeResult.Status != AudioDeviceNodeCreationStatus.Success)
          {
              // Cannot create device output node
            txtresult.Text+="\n"+ String.Format("Device Output unavailable because {0}", deviceOutputNodeResult.Status.ToString());
              return;
          }
          deviceOutput = deviceOutputNodeResult.DeviceOutputNode;
          txtresult.Text += "\n" + "Device Output Node successfully created";
      }
      private async void File_Click(object sender, RoutedEventArgs e)
      {
          // If another file is already loaded into the FileInput node
          if (fileInput != null)
          {
              fileInput.Dispose();
          }
          FileOpenPicker filePicker = new FileOpenPicker();
          filePicker.SuggestedStartLocation = PickerLocationId.MusicLibrary;
          filePicker.FileTypeFilter.Add(".mp3");
          filePicker.FileTypeFilter.Add(".wav");
          filePicker.FileTypeFilter.Add(".wma");
          filePicker.FileTypeFilter.Add(".m4a");
          filePicker.ViewMode = PickerViewMode.Thumbnail;
          StorageFile file = await filePicker.PickSingleFileAsync();
          // File can be null if cancel is hit in the file picker
          if (file == null)
          {
              return;
          }
          CreateAudioFileInputNodeResult fileInputResult = await graph.CreateFileInputNodeAsync(file);
          if (AudioFileNodeCreationStatus.Success != fileInputResult.Status)
          {
              // Cannot read input file
              await new MessageDialog(String.Format("Cannot read input file because {0}", fileInputResult.Status.ToString())).ShowAsync();
              return;
          }
          fileInput = fileInputResult.FileInputNode;
          txtresult.Text += "\n" + "File load successfully,input nodes created";
      }
      private void Graph_Click(object sender, RoutedEventArgs e)
      {
          if (graphButton.Content.Equals("Start playing"))
          {
              fileInput.AddOutgoingConnection(deviceOutput);
              graph.Start();            
              graphButton.IsEnabled = false;
          }
      }
      private async void OutpuyfileButton_Click(object sender, RoutedEventArgs e)
      {
          FileSavePicker saveFilePicker = new FileSavePicker();
          saveFilePicker.FileTypeChoices.Add("Pulse Code Modulation", new List<string>() { ".wav" });
          saveFilePicker.FileTypeChoices.Add("Windows Media Audio", new List<string>() { ".wma" });
          saveFilePicker.FileTypeChoices.Add("MPEG Audio Layer-3", new List<string>() { ".mp3" });
          saveFilePicker.SuggestedFileName = "New Audio Track";
          outputfile = await saveFilePicker.PickSaveFileAsync();
          // File can be null if cancel is hit in the file picker
          if (outputfile == null)
          {
              return;
          }
          txtresult.Text +="\n"+ String.Format("Recording to {0}", outputfile.Name.ToString());
      }
      private MediaEncodingProfile CreateMediaEncodingProfile(StorageFile file)
      {
          switch (file.FileType.ToString().ToLowerInvariant())
          {
              case ".wma":
                  return MediaEncodingProfile.CreateWma(AudioEncodingQuality.High);
              case ".mp3":
                  return MediaEncodingProfile.CreateMp3(AudioEncodingQuality.High);
              case ".wav":
                  return MediaEncodingProfile.CreateWav(AudioEncodingQuality.High);
              default:
                  throw new ArgumentException();
          }
      }
      private async void graphrecord_Click(object sender, RoutedEventArgs e)
      {
          if (graphrecord.Content.Equals("Begin recording"))
          {
              MediaEncodingProfile fileProfile = CreateMediaEncodingProfile(outputfile);
              CreateAudioFileOutputNodeResult fileOutputNodeResult = await graph.CreateFileOutputNodeAsync(outputfile, fileProfile);
              if (fileOutputNodeResult.Status != AudioFileNodeCreationStatus.Success)
              {
                  // FileOutputNode creation failed
                  await new MessageDialog(String.Format("Cannot create output file because {0}", fileOutputNodeResult.Status.ToString())).ShowAsync();
                  return;
              }
              fileOutputNode = fileOutputNodeResult.FileOutputNode;
              fileInput.AddOutgoingConnection(fileOutputNode);
              graphrecord.Content = "Stop recording";
          }
          else
          {
              graph.Stop();
              TranscodeFailureReason finalizeResult = await fileOutputNode.FinalizeAsync();
              if (finalizeResult != TranscodeFailureReason.None)
              {
                  // Finalization of file failed. Check result code to see why
                  await new MessageDialog(String.Format("Finalization of file failed because {0}", finalizeResult.ToString())).ShowAsync();
                  return;
              }
              txtresult.Text += "\n" + "Recording completed";
              graphrecord.IsEnabled = false;
          }
      }
 
