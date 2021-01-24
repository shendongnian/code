      output.Items.Add("Begin...");
      for (int i = 0; i < 100000; i++)
      {
        output.Items.Add("Data " + i);
        // Give the UI a chance to catch up
        await Task.Delay(1);
      }
      output.Items.Add("...End");
    }
