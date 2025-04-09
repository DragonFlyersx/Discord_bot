using SQLitePCL;

namespace DiscordBot;

using Microsoft.Data.Sqlite;
using System.Threading.Tasks;
using System.Collections.Generic;

public class DatabaseContext
{
    private readonly string connectionString;

    public DatabaseContext(string connectionString)
    {
        this.connectionString = connectionString;
        Console.WriteLine("DatabaseContext initialized with connection string: " + connectionString);
        
        Console.WriteLine("Debug: DatabaseContext constructor called");
    }

    public async Task InitializeDatabaseAsync()
    {
        using var connection = new SqliteConnection(connectionString);
        await connection.OpenAsync();

        var command = connection.CreateCommand();
        command.CommandText = @"
            CREATE TABLE IF NOT EXISTS Tasks (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                UserId TEXT NOT NULL,
                TaskDescription TEXT NOT NULL
            );
        ";
        await command.ExecuteNonQueryAsync();
    }

    public async Task AddTaskAsync(string userId, string taskDescription)
    {
        using var connection = new SqliteConnection(connectionString);
        await connection.OpenAsync();

        var command = connection.CreateCommand();
        command.CommandText = @"
            INSERT INTO Tasks (UserId, TaskDescription)
            VALUES ($userId, $taskDescription);
        ";
        command.Parameters.AddWithValue("$userId", userId);
        command.Parameters.AddWithValue("$taskDescription", taskDescription);

        await command.ExecuteNonQueryAsync();
    }
    
    public async Task<string[]> GetTasksAsync(string userId)
    {
        using var connection = new SqliteConnection(connectionString);
        await connection.OpenAsync();

        var command = connection.CreateCommand();
        command.CommandText = @"
            SELECT TaskDescription
            FROM Tasks
            WHERE UserId = $userId;
        ";
        command.Parameters.AddWithValue("$userId", userId);

        var tasks = new List<string>();
        using var reader = await command.ExecuteReaderAsync();
        while (await reader.ReadAsync())
        {
            tasks.Add(reader.GetString(0));
        }

        return tasks.ToArray();
    }
    
    public async Task CompleteTaskAsync(string userId, string taskDescription)
    {
        using var connection = new SqliteConnection(connectionString);
        await connection.OpenAsync();

        var command = connection.CreateCommand();
        command.CommandText = @"
            DELETE FROM Tasks
            WHERE UserId = $userId AND TaskDescription = $taskDescription;
        ";
        command.Parameters.AddWithValue("$userId", userId);
        command.Parameters.AddWithValue("$taskDescription", taskDescription);

        await command.ExecuteNonQueryAsync();
    }
    
    public async Task<string[]> GetAllTasksAsync()
    {
        using var connection = new SqliteConnection(connectionString);
        await connection.OpenAsync();

        var command = connection.CreateCommand();
        command.CommandText = @"
            SELECT TaskDescription
            FROM Tasks;
        ";

        var tasks = new List<string>();
        using var reader = await command.ExecuteReaderAsync();
        while (await reader.ReadAsync())
        {
            tasks.Add(reader.GetString(0));
        }

        return tasks.ToArray();
    }
}