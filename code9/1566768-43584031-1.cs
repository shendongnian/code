      var swipe = new SwipeGestureReconginzer();
      swipe.Swiped += Tee_Swiped;
      TestLabel.GestureRecognizers.Add(swipe);
    
      private void Tee_Swiped(object sender, SwipeDerrictionEventArgs e)
      {
          switch (e.Deriction)
          {
              case SwipeDeriction.Above:
                  {
                  }
                  break;
    
              case SwipeDeriction.Left:
                  {
                  }
                  break;
    
              case SwipeDeriction.Rigth:
                  {
                  }
                  break;
    
              case SwipeDeriction.Bottom:
                  {
                  }
                  break;
    
              default:
                  break;
          }
      }
