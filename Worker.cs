// Worker.cs
using DSharpPlus;
using DSharpPlus.SlashCommands;


namespace DiscordBot
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> logger;
        private readonly IConfiguration configuration;
        private readonly IServiceProvider services;
        private DiscordClient discordClient;
        private SlashCommandsExtension slashCommands;

        public Worker(ILogger<Worker> logger, IConfiguration configuration, IServiceProvider services)
        {
            this.logger = logger;
            this.configuration = configuration;
            this.services = services;
        }

        public override async Task StartAsync(CancellationToken cancellationToken)
        {
            logger.LogInformation("Starting discord bot");

            string discordBotToken = configuration["DiscordBotToken"];
            discordClient = new DiscordClient(new DiscordConfiguration()
            {
                Token = discordBotToken,
                TokenType = TokenType.Bot,
                Intents = DiscordIntents.AllUnprivileged
            });

            var databaseContext = new DatabaseContext("Data Source=discordbot.db");
            await databaseContext.InitializeDatabaseAsync();

            slashCommands = discordClient.UseSlashCommands(new SlashCommandsConfiguration
            {
                Services = services
            });
            slashCommands.RegisterCommands<CommandsModule>();

            await discordClient.ConnectAsync();
            logger.LogInformation("Discord bot Connected");
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken) => Task.CompletedTask;

        public override async Task StopAsync(CancellationToken cancellationToken)
        {
            await discordClient.DisconnectAsync();
            logger.LogInformation("Discord bot stopped");
        }
    }
}