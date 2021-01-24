    private readonly Dictionary<Project, Timer> _timers = new Dictionary<Project, Timer>();
    private void OnPlayButtonClicked(object sender, RoutedEventArgs e)
    {
        var selectedProject = ((FrameworkElement)sender).DataContext as Project;
        if (selectedProject != null)
        {
            Console.WriteLine("Selected Project has been played: " +
                selectedProject.ProjectName + " : Billed Hours - " +
                selectedProject.ActualBilledHours);
            if (ProjectDictionary.ContainsKey(selectedProject))
            {
                ProjectDictionary.Remove(selectedProject);
                var toggle = IsPlaying = !IsPlaying;
                ProjectDictionary.Add(selectedProject, toggle);
                foreach (var dict in ProjectDictionary)
                {
                    if (dict.Key == selectedProject)
                    {
                        //get the timer from the dictionary
                        Timer timer;
                        if (!_timers.TryGetValue(selectedProject, out timer))
                        {
                            timer = new Timer();
                            _timers.Add(selectedProject, timer);
                        }
                        //start or stop
                        if (toggle)
                            timer.Start();
                        else
                            timer.Stop();
                    }
                }
            }
        }
    }
