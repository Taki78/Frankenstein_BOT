using Discord;
using Discord.WebSocket;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
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
            //_client.MessageReceived += GetMovie;
            _client.Log += Log;

            //  You can assign your bot token to a string, and pass that in to connect.
            //  This is, however, insecure, particularly if you plan to have your code hosted in a public repository.
            var token = File.ReadAllText("token.txt");

            // Some alternative options would be to keep your token in an Environment Variable or a standalone file.
            // var token = Environment.GetEnvironmentVariable("NameOfYourEnvironmentVariable");
            // var token = File.ReadAllText("token.txt");
            // var token = JsonConvert.DeserializeObject<AConfigurationClass>(File.ReadAllText("config.json")).Token;

            await _client.LoginAsync(TokenType.Bot, token);
            await _client.StartAsync();

            // Block this task until the program is closed.
            await Task.Delay(-1);
            
        }
        

        private Task GetMovie(SocketMessage message)
        {
            if (message.Content.StartsWith("!m "))
            {

                //MoviePath
                string SearchCommand = message.Content.Replace("!m ", "").Replace(" ", "%20");

                //SearchUserMovie
                var movieUrl = $"https://imdb-api.com/en/API/SearchTitle/k_pk592956/" + SearchCommand;

                //ShowResult
                using (var client = new HttpClient())
                {
                    var result = client.GetStringAsync(movieUrl).Result;
                    var movieResults = JsonConvert.DeserializeObject<MovieDetailRoot>(result);
                    // message.Channel.SendMessageAsync($"Movie name is {movieResults.Movie}");


                    foreach (var movie in movieResults.results)
                    {
                        //GetSubtitlesPerIDLink
                        var urlGetSubtitle = "https://imdb-api.com/fa/API/Subtitles/k_pk592956/" + movie.id;

                        //GetStringSubs Json To C#
                        var subtitleResult = client.GetStringAsync(urlGetSubtitle).Result;
                        var subtitleList = JsonConvert.DeserializeObject<Subtitle_Root>(subtitleResult);


                        //Movie embed Buids
                        var builder = new EmbedBuilder()
                        {
                            Description = movie.title + " " + movie.description,
                            ImageUrl = movie.image,
                            Color = new Color(166, 160, 0),
                            Title = "Movie Name Is:",
                        };
                        var embed = builder.Build();

                        //sendEmbed
                        message.Channel.SendMessageAsync(null, false, embed);
                        System.Threading.Thread.Sleep(750);
                    }

                };
            }

            return Task.CompletedTask;
        }

        private Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }

        private Task CommandHandler(SocketMessage message)
        {
            //variables
            string command = "";
            int lengthOfCommand = -1;

            //filtering messages begin here
            //if (!message.Content.StartsWith("-")) //This is your prefix
            // return Task.CompletedTask;

            if (message.Author.IsBot) //This ignores all commands from bots
                return Task.CompletedTask;

            if (message.Content.Contains(' '))
                lengthOfCommand = message.Content.IndexOf(' ');
            else
                lengthOfCommand = message.Content.Length;

            command = message.Content.Substring(1, lengthOfCommand - 1).ToLower();

            //Commands begin here

            if (message.Content.StartsWith("-p ") || message.Content.StartsWith("!p ") || message.Content.StartsWith("!play ") || message.Content.StartsWith("-play"))
            {
                var msg = message.Content.ToString();
                var ans = message.Channel.SendMessageAsync($@"{message.Author.Mention} inja Ahang nazar joone del ");
                message.DeleteAsync();
                Thread.Sleep(5000);
                ans.Result.DeleteAsync();

            }

            if (message.Content.StartsWith("-stop"))
            {
                message.DeleteAsync();
                
            }

            if (command.StartsWith("salam") || command.StartsWith("سلام"))
            {
                message.Channel.SendMessageAsync($@"Salam joonedel");
            }

            //if (message.Content.Length > 5)
            //{
            //    message.Channel.SendMessageAsync("kam harf mizani", true);
            //}

            if (message.Content.StartsWith("salam") || message.Content.StartsWith("سلام"))
            {
                message.Channel.SendMessageAsync($@"Salam joonedel");
                
            }

            if (message.Content.StartsWith("test"))
            {
                message.Channel.SendMessageAsync("Yes!");
            }

            return Task.CompletedTask;
        }

    }
}
