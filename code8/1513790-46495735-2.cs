    using System;
    using System.Collections.Generic;
    using System.Text;
    using Discord;
    using Discord.Commands;
    using Discord.WebSocket;
    using Discord.Net;
    using System.Linq;
    using System.Threading.Tasks;
    namespace ConsoleApp1.commands
    {
    public class jail : ModuleBase<SocketCommandContext>
    {
    [Command("jail")]
    public async Task jail2 (IGuildUser user)
    {
    var role = Context.Guild.Roles.FirstOrDefault(x => x.Name.ToString() == "ROLE_NAME");     
            
    await (user as IGuildUser).AddRoleAsync(role);
    }
    }
    }
