    //Assign a CardView to the relationship 
                CardView cardView1 = new CardView(gridControl1);
                gridControl1.LevelTree.Nodes.Add("CategoriesProducts", cardView1);
                //Specify text to be displayed within detail tabs. 
                cardView1.ViewCaption = "Category Products";
    
                //Hide the CategoryID column for the master View 
                gridView1.Columns["CategoryID"].VisibleIndex = -1;
                
                //Present data in the Picture column as Images 
                RepositoryItemPictureEdit riPictureEdit = gridControl1.RepositoryItems.Add("PictureEdit") as RepositoryItemPictureEdit;
                gridView1.Columns["Picture"].ColumnEdit = riPictureEdit;
                //Stretch images within cells.
 
