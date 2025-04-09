using DiscordBot;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddSingleton(new DatabaseContext("Data Source=/app/Data/discordbot.db"));
builder.Services.AddSingleton<CommandsModule>();
builder.Services.AddHostedService<Worker>();

var host = builder.Build();

host.Run();
