                Main Form:                
                      public partial class Main : Form
                    {
                        // Creat the recipeList here and make it public
                        public List<Recipe> recipeList = new List<Recipe>();
                    
                        public Main()
                        {
                            InitializeComponent();
                        }
                    
                        private void newRecipeButton_Click(object sender, EventArgs e)
                        {
                            // When the new recipe button is clicked, create a new AddNewRecipeForm object that passed the recipeList.
                            var newForm = new AddNewRecipeForm(recipeList);       
                            newForm.Show();
             **recipeList =newForm.ReceiptList;**
        //assign recipeList  values to list box
                        }
                    
                        private void recipeListBox_SelectedIndexChanged(object sender, EventArgs e)
                        {
                            // List the New Recipe in the listbox.           
                        }
                    }
    
    
    
    
    
    Second Form:
    
    public partial class AddNewRecipeForm : Form
    {
        // Create a private recipeList
        **private List<Recipe> recipeList = new List<Recipe>();
    public List<Recipe> RecipeList
    {
     get { return recipeList; }
     set { recipeList = value; }
    }**
    
        // Once AddNewRecipe is create, it uses the recipeList as the parameters.
        public AddNewRecipeForm(List<Recipe> recipeList)
        {
            InitializeComponent();
        }
    
        private void submitRecipeButton_Click(object sender, EventArgs e)
        {
            // Create a newRecipe object.
            Recipe newRecipe = new Recipe();
    
            // Add each entry made in the textboxes to newRecipe object.
            newRecipe.Name = nameTextBox.Text;
            newRecipe.Time = Convert.ToInt32(timeTextBox.Text);
            newRecipe.Servings = Convert.ToInt32(servingsTextBox.Text);
            newRecipe.Directions = directionsTextBox.Text;
            newRecipe.Ingredients = ingredientsTextBox.Text;
    
            // Add the newRecipe object to the recipeList.
            recipeList.Add(newRecipe);
    
            // Close the window.
            this.Close();
        }                
    }
