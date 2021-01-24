    namespace MyBot.Modules.Public
    {
       **Public** class test : ModuleBase
    {
        [Command("say")]
        [Alias("echo")]
        [Summary("Echos the provided input")]
        public async Task Say([Remainder] string input)
        {
            await ReplyAsync(input);
        }
    }
  }
