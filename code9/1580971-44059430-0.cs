	private void button3_Click(object sender, EventArgs e)
	{
		int W = Convert.ToInt32(txtW.Text);
		int H = Convert.ToInt32(txtH.Text);
		Parallel.ForEach(listaslika, slika =>
		{
			using (Bitmap bmp = new Bitmap(W, H))
			{
				using (Graphics graphic = Graphics.FromImage(bmp))
				{
					using (FileStream fs = new FileStream(tbSelect.Text + "\\" + slika, System.IO.FileMode.Open))
					{
						using (Image img = Image.FromStream(fs))
						{
							graphic.DrawImage(img, 0, 0, W, H);
						}
					}
				}
				
				string select = Path.GetFileNameWithoutExtension(slika);
				bmp.Save(tbSave.Text + "\\" + select + exten[GetSelecetedIndex()]);
			}               
		});
	}
