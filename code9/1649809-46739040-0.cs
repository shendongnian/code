    Paragraph flavorText = new Paragraph();
    Paragraph effectText = new Paragraph();
    private void FlavorInput_TextChanged(object sender, TextChangedEventArgs e){
       flavorText.Inlines.Clear();
       flavorText.Inlines.Add(FlavorInput.Text);
       updateBlocks();
    }
    private void EffectInput_TextChanged(object sender, TextChangedEventArgs e)
    {
       effectText.Inlines.Clear();
       effectText.Inlines.Add(EffectInput.Text);
       updateBlocks();
    }
    private void updateBlocks(){
       Description.Document.Blocks.Clear();
       Description.Document.Blocks.Add(effectText);           
       Description.Document.Blocks.Add(flavorText);     
    }
