    void enviar_Click(object sender, EventArgs e)
                {
                    try
                    {
                        RadioButton rdbgrupo1 = FindViewById<RadioButton>(rdgconquiste.CheckedRadioButtonId);
                        RadioButton rdbgrupo2 = FindViewById<RadioButton>(rdgcrie.CheckedRadioButtonId);
                        RadioButton rdbgrupo3 = FindViewById<RadioButton>(rdgviva.CheckedRadioButtonId);
                        RadioButton rdbgrupo4 = FindViewById<RadioButton>(rdgentregue.CheckedRadioButtonId);
                        int RadioGroupIsChecked(RadioGroup radioGroup)
                        {
                            //-1 means empty selection
                            return radioGroup.CheckedRadioButtonId;
                        }
    
                        //When user doesn't check a radio button, show a Toast
                        if (RadioGroupIsChecked(rdgconquiste) == -1 || RadioGroupIsChecked(rdgcrie) == -1 || RadioGroupIsChecked(rdgviva) == -1 || RadioGroupIsChecked(rdgentregue) == -1)
                        {
                            string excecao = "Ao menos um botão de cada campo deve ser selecionado e o comentário deve ser preenchido";
                            Toast.MakeText(this, excecao, ToastLength.Long).Show();
                        }
                        else
                        {
                            String emailescolhido = spinner.SelectedItem.ToString();
                            
                            if (emailescolhido == "Escolha um colaborador abaixo")
                            {
                                string excecao = "Por favor, escolha um colaborador";
                                Toast.MakeText(this, excecao, ToastLength.Long).Show();
    
                            }
    
                            else { 
                            String campocomentario = comentário.Text;
    
                            var email = new Intent(Android.Content.Intent.ActionSend);
                            //send to
                            email.PutExtra(Android.Content.Intent.ExtraEmail,
                            new string[] { "" + emailescolhido });
                            //cc to
                            email.PutExtra(Android.Content.Intent.ExtraCc,
                            new string[] { "" });
                            //subject
                            email.PutExtra(Android.Content.Intent.ExtraSubject, "SABIA QUE VOCÊ FOI RECONHECIDO?");
                            //content
                            email.PutExtra(Android.Content.Intent.ExtraText,
                            "Você foi reconhecido pelo(s) valor(es) de: " + rdbgrupo1.Text + " , " + rdbgrupo2.Text + " , " + rdbgrupo3.Text + " e " + rdbgrupo4.Text + "" + System.Environment.NewLine + "" + System.Environment.NewLine + campocomentario + System.Environment.NewLine);
                            email.SetType("message/rfc822");
                            StartActivity(email);
                            Android.App.AlertDialog.Builder alertdialog = new Android.App.AlertDialog.Builder(this);
                            alertdialog.SetTitle("Confirmação de envio");
                            alertdialog.SetMessage("Email enviado com sucesso");
                            alertdialog.SetNeutralButton("Ok", delegate {
                                alertdialog.Dispose();
                            });
                            alertdialog.Show();
                        }
                        }
    
    
                    }
    
    
                    catch (Java.Lang.Exception ex)
                    {
                        showbox(ex.Message);
    
                    } } }
