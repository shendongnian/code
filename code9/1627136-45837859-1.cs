    var test = unitOfWork.ChatMensagemRepository.GetAll()
                  .Where(x => x.PessoaCodigoPessoa == codigoRemetente)
                  //this section is added
                  .Select(x => new 
                  {
                      x.ChatConversaCodigoChatConversa,
                      x.prop1,//specify only columns, which you need for below code with Take
                      x.prop2
                  }).ToList()
                  //end of section
                  .GroupBy(x => x.ChatConversaCodigoChatConversa)
                  .Select(group => new
                  {
                      codigoChat = group.Key,
                      list = group.Take(2).Select(mensagem => new
                      {
                         mensagem.prop1, 
                         mensagem.prop2
                      }).ToList()
                  }).ToList();
