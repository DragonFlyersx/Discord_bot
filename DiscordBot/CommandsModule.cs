using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;
using System.Threading.Tasks;

namespace DiscordBot
{
    public class CommandsModule : ApplicationCommandModule
    {
        [SlashCommand("ping", "Responds with pong!")]
        public async Task PingCommand(InteractionContext ctx)
        {
            Console.WriteLine("Ping command invoked");
            await ctx.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource, new DiscordInteractionResponseBuilder().WithContent("pong!"));
        }
        
        [SlashCommand("Cook", "Responds with pong!")]
        public async Task CookCommand(InteractionContext ctx)
        {
            Console.WriteLine("Cook command invoked");
            await ctx.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource, new DiscordInteractionResponseBuilder().WithContent("Alright time to cook chat!"));
        }
    }
}