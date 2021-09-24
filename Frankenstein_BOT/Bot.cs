using Discord;
using Discord.WebSocket;
using Frankenstein_BOT.Utilities;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Frankenstein_BOT
{
    class Bot
    {

        private DiscordSocketClient _client;
        public async Task MainAsync()
        {
            _client = new DiscordSocketClient();
            _client.MessageReceived += CommandHandler;
            _client.Log += Log;

            // var token = File.ReadAllText("token.txt");
            // var token = JsonConvert.DeserializeObject<AConfigurationClass>(File.ReadAllText("config.json")).Token;
            var token = File.ReadAllText("token.txt");


            await _client.LoginAsync(TokenType.Bot, token);
            await _client.StartAsync();

            // Block this task until the program is closed.
            await Task.Delay(-1);
            
        }

        private Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }

        private Task CommandHandler(SocketMessage message)
        {

            if (message.Content.StartsWith("-p ") || message.Content.StartsWith("!p ") || message.Content.StartsWith("!play ") || message.Content.StartsWith("-play"))
            {
                var msg = message.Content.ToString();
                var ans = message.Channel.SendMessageAsync($@"{message.Author.Mention} inja Ahang nazar joone del ");
                message.DeleteAsync();
                Thread.Sleep(5000);
                ans.Result.DeleteAsync();

            }

            if (message.Content.StartsWith("-link"))
            {
                int counter = LinkGenerator.GetNumFromStr(message.Content);
                message.Channel.SendMessageAsync("Procecing...");
                var links = LinkGenerator.GenerateSingleVariableleLink("test *", counter);
                message.Channel.SendMessageAsync(links.ToString());
            }

            if (message.Content.StartsWith("-stop"))
            {
                message.DeleteAsync();
                
            }

            return Task.CompletedTask;
        }

    }
}
