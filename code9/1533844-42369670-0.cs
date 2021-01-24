    static class MyDrawer
    { 
    public static void ChecknDraw(RadioButton radioButtonActor,RadioButton  radioButtonUseCase, TextBox textBox1, PictureBox pictureBox1, EventArgs e)
    {
        if (radioButtonActor.Checked)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            Actor actor = new Actor(textBox1.Text, me.X, me.Y);
    
            actor.DrawActor(pictureBox1.CreateGraphics());
        }
        else if (radioButtonUseCase.Checked)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            UseCase usecase = new UseCase(textBox1.Text, me.X, me.Y);
    
            usecase.DrawUseCase(pictureBox1.CreateGraphics());
        }
    }
    
    }
