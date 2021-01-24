    x.CreateMap<Message, MessageDTO>()
                        .ForMember(m => m.Status, opts => opts.MapFrom(src => src.MessageStatusID))
                        .ForMember(m => m.Channel, opts => opts.MapFrom(src => src.MessageChannelID))
                        .ConstructUsing(m =>
                        {
                            if (m.MessageChannelID == (int)Data.MessageChannel.Email)
                                return new EmailMessageDTO
                                {
                                    EmailReceiverBCC = m.EmailReceiverBCC,
                                    EmailReceiverCC = m.EmailReceiverCC,
                                    EmailSenderReplyTo = m.EmailSenderReplyTo,
                                    EmailSubject = m.EmailSubject,
                                    EmailUseSSL = m.EmailUseSSL
                                };
                            else return new SMSMessageDTO
                            {
                                SMSGUID = m.SMSGUID
                            };
                        });
