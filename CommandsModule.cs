using System.ComponentModel.Design;
using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;
using System.Threading.Tasks;

namespace DiscordBot
{
    public class CommandsModule : ApplicationCommandModule
    {
        private readonly DatabaseContext databaseContext;
        public CommandsModule(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        } 
        
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
        
       /* [SlashCommand("AssigntaskToUser", "Creates a task and assigns it to a user")]
        
        public async Task AssignTaskCommand(InteractionContext ctx, [Option("User", "The user to assign the task to")] DiscordUser user, [Option("Task", "The task to assign")] string task)
        {
            try
            {
                await databaseContext.AddTaskAsync(user.Id.ToString(), task);
                await ctx.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource, new DiscordInteractionResponseBuilder().WithContent($"Assigned task '{task}' to user <@{user.Id}>"));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error assigning task to user: {ex}");
                await ctx.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource, new DiscordInteractionResponseBuilder().WithContent("An error occurred while assigning the task."));
            }
        }
        
        
        [SlashCommand("GetTasks", "Gets all tasks assigned to a user")]
        
        public async Task GetTasksCommand(InteractionContext ctx, [Option("User", "The user to get tasks for")] DiscordUser user)
        {
            Console.WriteLine("Get tasks command invoked");
            var tasks = await databaseContext.GetTasksAsync(user.Id.ToString());
            await ctx.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource, new DiscordInteractionResponseBuilder().WithContent($"Tasks assigned to user <@{user.Id}>: {string.Join(", ", tasks)}"));
        } 
        
        [SlashCommand("CompleteTask", "Completes a task assigned to a user")]
        
        public async Task CompleteTaskCommand(InteractionContext ctx, [Option("User", "The user to complete the task for")] DiscordUser user, [Option("Task", "The task to complete")] string task)
        {
            Console.WriteLine("Complete task command invoked");
            await databaseContext.CompleteTaskAsync(user.Id.ToString(), task);
            await ctx.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource, new DiscordInteractionResponseBuilder().WithContent($"Completed task '{task}' for user <@{user.Id}>"));
        }
        
        [SlashCommand("GetAllTasks", "Gets all tasks assigned to all with users")]
        
        public async Task GetAllTasksCommand(InteractionContext ctx)
        {
            Console.WriteLine("Get all tasks command invoked");
            var tasks = await databaseContext.GetAllTasksAsync();
            await ctx.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource, new DiscordInteractionResponseBuilder().WithContent($"All tasks: {string.Join(", ", tasks)}"));
        } */
        
        [SlashCommand("Help", "Displays the help message")]
        public async Task HelpFunCommand(InteractionContext ctx)
        {
            Console.WriteLine("Help command invoked");
            var helpMessage = "This application is still being worked on for more use /HelpCommands";
            await ctx.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource, new DiscordInteractionResponseBuilder().WithContent(helpMessage));
        }
        
        [SlashCommand("HelpCommands", "Displays the help message")]
        public async Task HelpCommand(InteractionContext ctx)
        {
            Console.WriteLine("Help command invoked");
            var helpMessage = "Available commands:\n" +
                              "/ping - Responds with pong!\n" +
                              "/Cook - Responds with 'Alright time to cook chat!'\n" +
                             /* "/AssigntaskToUser - Assigns a task to a user\n" +
                              "/GetTasks - Gets all tasks assigned to a user\n" +
                              "/CompleteTask - Completes a task assigned to a user\n" +
                              "/GetAllTasks - Gets all tasks assigned to all users\n" + */
                              "/HelpCommands - Displays this help message";
            await ctx.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource, new DiscordInteractionResponseBuilder().WithContent(helpMessage));
        }
        
        
    }
}