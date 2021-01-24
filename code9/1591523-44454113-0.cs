    public static Monnaie MonnaieOptimale(long s)
            {
                if (s<10)
                {
                    if (s%2 =0) {Monnaie.billet10 = 0 ; Monnaie.billet5 = 0 ; Monnaie.piece2 = s/2 }
                    else if (s == 5)  {Monnaie.billet10 = 0 ; Monnaie.billet5 = 1 ; Monnaie.piece2=0 }
                    else if (s == 7)  {Monnaie.billet10 = 0 ; Monnaie.billet5 = 1 ; Monnaie.piece2=1  }
                    else Monnaie.billet10 = 0 ; Monnaie.billet5 = 1 ; Monnaie.piece2= 2
                }
                
                else
                {
                    if (s%2 =0) 
                    {
                        Monnaie.billet10 = Math.Floor(s/10);
                        if ((Monnaie.billet10 * 10) != s) {Monnaie.billet5 = 0 ; Monnaie.piece2= (s%10)/2 }
                    }
                    else
                    {
                        private lastDigit = s%10;
                        if (lastDigit ==1){Monnaie.billet10 = ((s/10)-1) ; Monnaie.billet5 = 0 ; Monnaie.piece2=3 }
                        else if (lastDigit ==3){Monnaie.billet10 = ((s/10)-1) ; Monnaie.billet5 = 0 ; Monnaie.piece2=4 }
                        else if (lastDigit ==5){Monnaie.billet10 = (s/10) ; Monnaie.billet5 = 1 ; Monnaie.piece2=0 }
                        else if (lastDigit ==7){Monnaie.billet10 = (s/10) ; Monnaie.billet5 = 1 ; Monnaie.piece2=1}
                        else {Monnaie.billet10 = (s/10) ; Monnaie.billet5 = 1 ; Monnaie.piece2=2}
                    }
                
                }
            
            }
