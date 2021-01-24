    protected void btnKnapp_Click(object sender, EventArgs e)
    {
        labRes.Text = "";
        labTestBox.Text = "";
        string losningOrd = "appelsin";
        char brukerGjett = Convert.ToChar(txtBokstavGjett.Text);
        char[] bokstaver = losningOrd.ToCharArray();
        losning = new char[bokstaver.Length];
        for (int i = 0; i <bokstaver.Length; i++)
        {
            if (brukerGjett == bokstaver[i])
            {
                losning[i] = bokstaver[i];
            }
            else if (!(brukerGjett == bokstaver[i]))
            {
            }
            forsokteBokstaver = brukerGjett.ToString();
            labRes.Text += "" + losning[i];
            labTestBox.Text += " " + losning[i];
        }
        txtBokstavGjett.Text = "";
        antallForsok++;
        labForsoktBokstav.Text += forsokteBokstaver;
        Session["antallForsok"] = antallForsok;
        Session["forsokteBokstaver"] = forsokteBokstaver;
        Session["losning"] = losning;
    }
