    await AsyncFile.ReadAllLinesAsync(
        PATH_TO_FILE,
        line => { /* do something with line*/  },
        progress =>
        {
            if (progress >= 0d)
                progressBar.Value = progress.Value * progressBar.Maximum;
            else
                progressBar.IsIndeterminate = true;
        });
