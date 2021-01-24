    private void TotalMB_Click(object sender, EventArgs e)
    {
      uint num1 = (uint) (this.K10Ks.Value + this.S12Ks.Value + this.DSRKs.Value + this.PeaceKs.Value + this.M1216Ks.Value + this.SCARKs.Value + this.CQBKs.Value + this.ANKs.Value + this.R870Ks.Value + this.BallistaKs.Value + this.KSGKs.Value + this.M27Ks.Value + this.TypeKs.Value + this.MP7Ks.Value + this.PDWKs.Value + this.MTARKs.Value + this.MSMCKs.Value + this.EVOKs.Value + this.TacKs.Value + this.SMRKs.Value + this.FivesKs.Value + this.KAPKs.Value + this.B23RKs.Value + this.SWATKs.Value + this.MK48Ks.Value + this.XPRKs.Value + this.M8A1Ks.Value + this.LSATKs.Value + this.ExeKs.Value + this.HAMRKs.Value + this.FALKs.Value + this.QBBKs.Value + this.SVUKs.Value + this.BowKs.Value + this.BallKnifeKs.Value + this.SMAWKs.Value + this.RPGKs.Value + this.ShieldKs.Value + this.FHJKs.Value + this.K9Oth.Value + this.StikOth.Value + this.HtOth.Value + this.SwrOth.Value + this.LodsOth.Value + this.CPacOth.Value + this.VTOLOth.Value + this.MisOth.Value + this.SenyOth.Value + this.ChopOth.Value + this.GdiOth.Value + this.DrnOth.Value + this.WathOth.Value + this.DrgOth.Value + this.RXOth.Value + this.WarOth.Value + this.AGROth.Value + this.DetOth.Value);
      uint num2 = (uint) (this.K10Hd.Value + this.S12Hd.Value + this.DSRHd.Value + this.PeaceHd.Value + this.M1216Hd.Value + this.SCARHd.Value + this.CQBHd.Value + this.ANHd.Value + this.R870Hd.Value + this.BallistaHd.Value + this.KSGHd.Value + this.M27Hd.Value + this.TypeHd.Value + this.MP7Hd.Value + this.PDWHd.Value + this.MTARHd.Value + this.MSMCHd.Value + this.EVOHd.Value + this.TacHd.Value + this.SMRHd.Value + this.FivesHd.Value + this.KAPHd.Value + this.B23RHd.Value + this.SWATHd.Value + this.MK48Hd.Value + this.XPRHd.Value + this.M8A1Hd.Value + this.LSATHd.Value + this.ExeHd.Value + this.HAMRHd.Value + this.FALHd.Value + this.QBBHd.Value + this.SVUHd.Value + this.BallKnifeHd.Value);
      uint num3 = (uint) (this.K10De.Value + this.S12De.Value + this.DSRDe.Value + this.PeaceDe.Value + this.M1216De.Value + this.SCARDe.Value + this.CQBDe.Value + this.ANDe.Value + this.R870De.Value + this.BallistaDe.Value + this.KSGDe.Value + this.M27De.Value + this.TypeDe.Value + this.MP7De.Value + this.PDWDe.Value + this.MTARDe.Value + this.MSMCDe.Value + this.EVODe.Value + this.TacDe.Value + this.SMRDe.Value + this.FivesDe.Value + this.KAPDe.Value + this.B23RDe.Value + this.SWATDe.Value + this.MK48De.Value + this.XPRDe.Value + this.M8A1De.Value + this.LSATDe.Value + this.ExeDe.Value + this.HAMRDe.Value + this.FALDe.Value + this.QBBDe.Value + this.SVUDe.Value + this.BowDe.Value + this.BallKnifeDe.Value + this.ShieldDe.Value);
      uint num4 = (uint) (this.TDMWin.Value + this.FreeForAllWin.Value + this.SDWin.Value + this.DominationWin.Value + this.HardpointWin.Value + this.HeadquartersWin.Value + this.DemolitionWin.Value + this.CTFWin.Value + this.KillConfirmedWin.Value + this.GunGameWin.Value + this.OneintheChamberWin.Value + this.SharpshooterWin.Value + this.SticksandStonesWin.Value + this.HCTDMWin.Value + this.HCSDWin.Value + this.HCDominationWin.Value + this.HCKillConfirmedWin.Value);
      uint num5 = (uint) (this.TDMLos.Value + this.FreeForAllLos.Value + this.SDLos.Value + this.DominationLos.Value + this.HardpointLos.Value + this.HeadquartersLos.Value + this.DemolitionLos.Value + this.CTFLos.Value + this.KillConfirmedLos.Value + this.GunGameLos.Value + this.OneintheChamberLos.Value + this.SharpshooterLos.Value + this.SticksandStonesLos.Value + this.HCTDMLos.Value + this.HCSDLos.Value + this.HCDominationLos.Value + this.HCKillConfirmedLos.Value);
      string str1; 
      double num6;
      if ((int) num1 != 0 && (int) num3 != 0)
      {
        // Cast removed here
        str1 = (num1 / num3).ToString("0.00").Replace(".00", string.Empty);
      }
      else
      {
        num6 = 0.0;
        str1 = num6.ToString();
      }
      string str2;
      if ((int) num4 != 0 && (int) num5 != 0)
      {
        // Cast removed here
        str2 = (num4 / num5).ToString("0.00").Replace(".00", string.Empty);
      }
      else
      {
        num6 = 0.0;
        str2 = num6.ToString();
      }
      int num7 = (int) MessageBox.Show("Kills: " + (object) num1 + "\nDeaths: " + (object) num3 + "\nWins: " + (object) num4 + "\nLosses: " + (object) num5 + "\nHeadshots: " + (object) num2 + "\nK/D: " + str1 + "\nW/L: " + str2 + "\n\nDon't Include Medals");
    }
