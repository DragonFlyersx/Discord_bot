# Discord Bot (C#)

A lightweight, containerized Discord bot built with **.NET 8** and **Discord.NET**, featuring a continuous deployment pipeline via **GitHub Actions** and **Docker**.  
Every push to the `main` branch automatically builds and deploys the latest version to the server.

---

## Features

- Responds to basic commands (e.g. `!ping → Pong!`)
- Easy to extend with more commands and features
- Built with **C#** and **Discord.NET**
- Automatically published to **Docker Hub**
- Automatically deployed to a remote server via **GitHub Actions**

---

## Tech Stack

| Component | Description |
|------------|-------------|
| **Language** | C# (.NET 8) |
| **Framework** | Discord.NET |
| **Containerization** | Docker |
| **CI/CD** | GitHub Actions |
| **Hosting** | Linux server (via SSH deploy) |

---


### 1. Clone the repository
```bash
git clone https://github.com/DragonFlyersx/Discord_bot.git
cd Discord_bot
```
### 2.Set up environment variables
Create a .env file (optional for local dev):
```bash
DISCORD_TOKEN=your_discord_bot_token_here
```
### 3. Run Locally
```bash
dotnet run
```




