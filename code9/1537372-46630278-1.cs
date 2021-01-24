    namespace AudioGraphAPI_read_samples_from_file
    {
        // App opens a file using FileOpenPicker and reads samples into array of 
        // floats using AudioGragh API
    // Declare COM interface to access AudioBuffer
    [ComImport]
    [Guid("5B0D3235-4DBA-4D44-865E-8F1D0E4FD04D")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    unsafe interface IMemoryBufferByteAccess
    {
        void GetBuffer(out byte* buffer, out uint capacity);
    }
    public sealed partial class MainPage : Page
    {
        StorageFile mediaFile;
        AudioGraph audioGraph;
        AudioFileInputNode fileInputNode;
        AudioFrameOutputNode frameOutputNode;
        /// <summary>
        /// We are going to fill this array with audio samples
        /// This app loads only one channel 
        /// </summary>
        float[] audioData;
        /// <summary>
        /// Current position in audioData array for loading audio samples 
        /// </summary>
        int audioDataCurrentPosition = 0;
        
        public MainPage()
        {
            this.InitializeComponent();            
        }
        
        private async void Open_Button_Click(object sender, RoutedEventArgs e)
        {
            // We ask user to pick an audio file
            FileOpenPicker filePicker = new FileOpenPicker();
            filePicker.SuggestedStartLocation = PickerLocationId.MusicLibrary;
            filePicker.FileTypeFilter.Add(".mp3");
            filePicker.FileTypeFilter.Add(".wav");
            filePicker.FileTypeFilter.Add(".wma");
            filePicker.FileTypeFilter.Add(".m4a");
            filePicker.ViewMode = PickerViewMode.Thumbnail;
            mediaFile = await filePicker.PickSingleFileAsync();
            if (mediaFile == null)
            {
                return;
            }
            // We load samples from file
            await LoadAudioFromFile(mediaFile);
            // We wait 5 sec
            await Task.Delay(5000);
            
            if (audioData == null)
            {
                ShowMessage("Error loading samples");
                return;
            }
            // After LoadAudioFromFile method finished we can use audioData
            // For example we can find max amplitude
            float max = audioData[0];
            for (int i = 1; i < audioData.Length; i++)
                if (Math.Abs(audioData[i]) > Math.Abs(max))
                    max = audioData[i];
            ShowMessage("Maximum is " + max.ToString());
        }
        private async void ShowMessage(string Message)
        {
            var dialog = new MessageDialog(Message);
            await dialog.ShowAsync();
        }
        private async Task LoadAudioFromFile(StorageFile file)
        {
            // We initialize an instance of AudioGraph
            AudioGraphSettings settings = 
                new AudioGraphSettings(
                    Windows.Media.Render.AudioRenderCategory.Media
                    );
            CreateAudioGraphResult result1 = await AudioGraph.CreateAsync(settings);
            if (result1.Status != AudioGraphCreationStatus.Success)
            {
                ShowMessage("AudioGraph creation error: " + result1.Status.ToString());
            }
            audioGraph = result1.Graph;
            
            if (audioGraph == null)
                return;
            // We initialize FileInputNode
            CreateAudioFileInputNodeResult result2 = 
                await audioGraph.CreateFileInputNodeAsync(file);
            if (result2.Status != AudioFileNodeCreationStatus.Success)
            {
                ShowMessage("FileInputNode creation error: " + result2.Status.ToString());
            }
            fileInputNode = result2.FileInputNode;
            if (fileInputNode == null)
                return;
            // We read audio file encoding properties to pass them to FrameOutputNode creator
            AudioEncodingProperties audioEncodingProperties = fileInputNode.EncodingProperties;
            // We initialize FrameOutputNode and connect it to fileInputNode
            frameOutputNode = audioGraph.CreateFrameOutputNode(audioEncodingProperties);
            fileInputNode.AddOutgoingConnection(frameOutputNode);
            // We add a handler achiving the end of a file
            fileInputNode.FileCompleted += FileInput_FileCompleted;
            // We add a handler which will transfer every audio frame into audioData 
            audioGraph.QuantumStarted += AudioGraph_QuantumStarted;
            // We initialize audioData
            int numOfSamples = (int)Math.Ceiling(
                (decimal)0.0000001
                * fileInputNode.Duration.Ticks
                * fileInputNode.EncodingProperties.SampleRate
                );
            audioData = new float[numOfSamples];
            
            audioDataCurrentPosition = 0;
            // We start process which will read audio file frame by frame
            // and will generated events QuantumStarted when a frame is in memory
            audioGraph.Start();
        }
        private void FileInput_FileCompleted(AudioFileInputNode sender, object args)
        {
            audioGraph.Stop();
        }
        private void AudioGraph_QuantumStarted(AudioGraph sender, object args)
        {
            AudioFrame frame = frameOutputNode.GetFrame();
            ProcessInputFrame(frame);
        }
        unsafe private void ProcessInputFrame(AudioFrame frame)
        {
            using (AudioBuffer buffer = frame.LockBuffer(AudioBufferAccessMode.Read))
            using (IMemoryBufferReference reference = buffer.CreateReference())
            {
                // We get data from current buffer
                ((IMemoryBufferByteAccess)reference).GetBuffer(
                    out byte* dataInBytes,
                    out uint capacityInBytes
                    );
                // We discard first frame; it's full of zeros because of latency
                if (audioGraph.CompletedQuantumCount == 1) return;
                float* dataInFloat = (float*)dataInBytes;
                uint capacityInFloat = capacityInBytes / sizeof(float);
                // Number of channels defines step between samples in buffer
                uint step = fileInputNode.EncodingProperties.ChannelCount;
                // We transfer audio samples from buffer into audioData
                for (uint i = 0; i < capacityInFloat; i += step)
                {
                    if (audioDataCurrentPosition < audioData.Length)
                    {
                        audioData[audioDataCurrentPosition] = dataInFloat[i];
                        audioDataCurrentPosition++;
                    }
                }
            }
        }
    }
