    private void GenerateCodeRegionDirective(CodeRegionDirective regionDirective)
    {
      if (regionDirective.RegionMode == CodeRegionMode.Start)
      {
        this.Output.Write("#region ");
        this.Output.WriteLine(regionDirective.RegionText);
      }
      else
      {
        if (regionDirective.RegionMode != CodeRegionMode.End)
          return;
        this.Output.WriteLine("#endregion");
      }
    }
