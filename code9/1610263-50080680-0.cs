    using Discord.Commands;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace AmberScript2.Modules
    {
        public class Kick : ModuleBase<SocketCommandContext>
        {
            [Command("kick"), RequireUserPermission(GuildPermission.KickMembers)]
            public async Task KickUser(SocketGuildUser userName)
            {
                 var user = Context.User as SocketGuildUser;
                 var role = (user as IGuildUser).Guild.Roles.FirstOrDefault(x => x.Name == "Role");
                 if (!userName.Roles.Contains(role))
                 {
                // Do Stuff
                if (user.GuildPermissions.KickMembers)
                {
                await userName.KickAsync();
                }
            }
        }
    }
