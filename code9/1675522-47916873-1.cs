        private void champcomplet(object sender, EventArgs e)    
        {
            ((EntryChir)sender).Unfocus();
            testeur.Text = ((EntryChir)sender).ClassId.ToString();
             //on definit l'index de l'item 
            int indexCh = 25;
             foreach (var item in Conteneur)
             {                
                 if (((EntryChir)sender).ClassId == item.Num.ToString())  // tester Entrychir partout
                 { indexCh = Conteneur.IndexOf(item); }
             }
             //-----------------------------
             // zone de saisi est vide 
             if (string.IsNullOrWhiteSpace(((EntryChir)sender).Text))
             {
                 // elle l'était déja
                 if(Conteneur[indexCh].Itemchir.Champsvide == true)
                 { } // on ne fait rien
                 // elle etait pleine
                 else
                 {
                     //on la supprime
                     Conteneur.RemoveAt(indexCh);                   
                 }
             }
             // zone de saisi est pleine
             else
             {
                 // elle l'était déja
                 if (Conteneur[indexCh].Itemchir.Champsvide == false)
                 {                    
                     // on ne fait rien sauf mettre a jour les valeurs
                     //ChirurgieList[indexCh].Chir = ((Entry)sender).Text;
                }
                 //et elle était vide
                 else
                 {
                     Conteneur[indexCh].Itemchir.Champsvide = false;
                     Conteneur[indexCh].Itemchir.Chir = ((Entry)sender).Text;
                     
                     listevisible.ItemsSource = Creaconteneur("", "");
                     //listevisible.ItemsSource = CreateItems(string.Empty, string.Empty);
                     
                 }
             }           
        }
