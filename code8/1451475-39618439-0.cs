      String Position = "l=50; r=190; t=-430; b=-480";
      public void modifyPosition(int l, int r, int t, int b)
      {
         string[] parts = Position.Split(';');
         int oldL = int.Parse(parts[0].Replace("l=","").Trim());
         int oldR = int.Parse(parts[1].Replace("r=","").Trim());
         int oldT = int.Parse(parts[2].Replace("t=","").Trim());
         int oldB = int.Parse(parts[3].Replace("b=","").Trim());
         Position = "l="+(oldL+l).ToString()+"; r="+(oldR+r).ToString()+
         "; t="+(oldT+t).ToString()+"; b="+(oldB+b).ToString()+";";
      }
