        [HttpPost]
        public async Task<JsonResult> Slide(int nrRegistro)
        {
            var recs = (from d in db.Imagem
                                where d.IdPostagemImagem == 1 && 
                                d.EnderecoImagem.Length > 0
                                orderby d.IdImagem
                                select new
                                {
                                    d.IdImagem,
                                    d.DescricaoLegenda,
                                    d.EnderecoImagem,
                                    d.CorFundoLegenda,
                                    d.CorFundoLegendaMobile,
                                    d.Descricao,
                                    d.Largura,
                                    d.Altura,
                                    d.DescricaoAlternativa,
                                    d.PosicaoHorizontalLegenda,
                                    d.Produto.URLPagina
                                });
            if (nrRegistro > 1)
            {
                nrRegistro--;
                recs = recs.Skip(nrRegistro).Take(1);
            }
            else
                recs= recs.Take(1);
            return Json( await recs.ToListAsync());
        }
