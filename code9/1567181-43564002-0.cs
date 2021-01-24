      double factResult = 1; // turn double into float if you want
      double item = 1;       // turn double into float if you want
      for (int i = 1; i < trialNumber; ++i)
        factResult += (item /= i);
      ...
      MessageBox.Show(factResult.ToString());
