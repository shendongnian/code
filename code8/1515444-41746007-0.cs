    namespace MasterPage
    {
      void Unlock()
      {
        btnLock.Visible = true;
        btnUnlock.Visible = false;
      }
    }
    
    namespace ChildPage
    {
      void Unlock()
      {
        (this.Master as MasterPage).Unlock();
      }
    }
