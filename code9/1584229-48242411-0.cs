            [Command("Votar")]
            [Summary("Abro uma votação, com opções de Sim e Não.")]
            [RequireBotPermission(ChannelPermission.AddReactions)]
            public async Task NovoVoto([Remainder] string secondPart)
            {
                Log.CMDLog(Context.User.Username, "Votar", Context.Guild.Name);
                
                if (secondPart.Length >= 200)
                {
                    await Context.Channel.SendMessageAsync("Perdão, porém seu voto não deve ter mais de 200 caracteres");
                    return;
                }
                var embed = new EmbedBuilder();
                embed.WithColor(new Color(126, 211, 33));
                embed.WithTitle("VOTE AQUI!");
                embed.WithDescription(secondPart);
                embed.WithFooter($"Votação criada por: {Context.User.Username}");
                RestUserMessage msg = await Context.Channel.SendMessageAsync("", embed: embed);
                await msg.AddReactionAsync(new Emoji("✅"));
                await msg.AddReactionAsync(new Emoji("❌"));
    //Delete the command message from the user
            await Context.Message.DeleteAsync();
            }
