using Discord.WebSocket;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Discord;
using System.Timers;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args) => new Program().RunBotAsync().GetAwaiter().GetResult();

        private DiscordSocketClient _client;
        private CommandService _commands;
        private IServiceProvider _services;

        public async Task RunBotAsync()
        {
            _client = new DiscordSocketClient();
            _commands = new CommandService();
            _services = new ServiceCollection()
            .AddSingleton(_client)
            .AddSingleton(_commands)
            .BuildServiceProvider();
            string botToken = "NDg4NDk2MDU2MzU5NzE0ODE5.Dni06A.QY__BYmy7b4tZkKev1nQ07B-nZQ";
            _client.Log += Log;
            _client.Ready += Modules.Class2.StartTimer;
            await RegistersCommandsAsync();
            await MainAsync();
            await _client.LoginAsync(TokenType.Bot, botToken);
            await _client.StartAsync();
            await Task.Delay(-1);
        }
        private Task Log(LogMessage arg)
        {
            Console.WriteLine(arg);
            return Task.Run(() =>
            {
                // i'm just here to simulate hard work
            });
        }

        public async Task RegistersCommandsAsync()
        {
            _client.MessageReceived += HandlerCommandAsync;
            await _commands.AddModulesAsync(Assembly.GetEntryAssembly());
        }

        private async Task HandlerCommandAsync(SocketMessage arg)
        {
            var message = arg as SocketUserMessage;
            if (message == null || message.Author.IsBot) return;
            int argPos = 0;
            if (message.HasMentionPrefix(_client.CurrentUser, ref argPos) || message.HasCharPrefix('!', ref argPos))
            {
                var context = new SocketCommandContext(_client, message);
                var result = await _commands.ExecuteAsync(context, argPos, _services);
                if (!result.IsSuccess)
                    Console.WriteLine(result.ErrorReason);
            }

        }
        public async Task MainAsync()
        {
            // client.Log ...
            _client.MessageReceived += MessageReceived;
            // ...
        }
        Boolean check = false;
        private async Task MessageReceived(SocketMessage message)
        {

            //     if (message.Content.Contains("vl") || message.Content.Contains("vc") || message.Content.Contains("cmm") || message.Content.Contains("dm") || message.Content.Contains("cc"))
            //   {
            //     await message.Channel.SendMessageAsync("Cấm chửi bậy!");
            //   await message.Channel.SendMessageAsync("https://cdn.discordapp.com/emojis/488175699455246366.png?v=1");
            //}

            // if (message.Content.Contains("có") && !check)
            // {
            //      await message.Channel.SendMessageAsync("https://cdn.discordapp.com/emojis/488165121261305869.png?v=1");
            //      check = true;
            //  }
            //    if (message.Content.Contains("giờ") && !check)
            //     {

            //        await message.Channel.SendMessageAsync(DateTime.Now.ToString("HH:mm tt"));
            //        check = true;
            //      }
            //   if ((DateTime.Now.ToString("tt") == "AM" && message.Content.Contains("Hi") || DateTime.Now.ToString("tt") == "AM" && message.Content.Contains("hi") || DateTime.Now.ToString("tt") == "AM" && message.Content.Contains("chào") || DateTime.Now.ToString("tt") == "AM" && message.Content.Contains("Chào")) && !check)
            //     {
            //      await message.Channel.SendMessageAsync("Chào buổi sáng!");
            //        await message.Channel.SendMessageAsync("https://cdn.discordapp.com/emojis/488177620157071371.png?v=1");
            //     check = true;
            //      }
            //   if ((DateTime.Now.ToString("tt") == "PM" && message.Content.Contains("Hi") || DateTime.Now.ToString("tt") == "PM" && message.Content.Contains("hi") || DateTime.Now.ToString("tt") == "PM" && message.Content.Contains("chào") || DateTime.Now.ToString("tt") == "PM" && message.Content.Contains("Chào")) && !check)
            //      {
            //        await message.Channel.SendMessageAsync("Chào buổi chiều!");
            //      await message.Channel.SendMessageAsync("https://cdn.discordapp.com/emojis/488177620157071371.png?v=1");
            //    return;
            //     }
            //      if (message.Content.Equals("buồn"))
            //       {

            //          await message.Channel.SendMessageAsync("Đừng buồn nữa mà!");

            //       }
            //       check = false;

            if (message.Content == "chouchin")
            {

                await message.Channel.SendMessageAsync("Truy tìm Chouchin Obake hay Chouchin Kozou?");
            }

            if (message.Content.Contains("chouchin obake"))
            {
                await message.Channel.SendMessageAsync("Truy tìm Chouchin Obake." + "\nBản đồ #9  (5)" + "\nBản đồ #6 Khiêu chiến  (14)" + "\nPBBM Hải Phường Chủ - Umibozu #1  (3)");
            }

            if (message.Content.Contains("chouchin kozou"))
            {
                await message.Channel.SendMessageAsync("Truy tìm Chouchin Kozou." + "\nBản đồ #1  (4)" + "\nBản đồ #2 Khiêu chiến  (14)" + "\nPBBM Hà Đồng - Kappa #1  (3)");
            }

            if (message.Content.Contains("cái đuôi") || message.Content.Contains("koi"))
            {
                await message.Channel.SendMessageAsync("Truy tìm Koi." + "\nBản đồ #7 (7)" + "\nBản đồ #7 Khiêu chiến  (14)" + "\nPBBM Hải Phường Chủ - Umibouzu #4  (4)");
            }

            if (message.Content.Contains("hakaarashi"))
            {
                await message.Channel.SendMessageAsync("Truy tìm Hakaarashi no Rei." + "\nBản đồ #2  (5)" + "\nBản đồ #14 Khiêu chiến  (14)" + "\nPBBM Yêu Đao Cơ - Youtouhime #1  (3)");
            }

            if (message.Content.Contains("nurikabe") || message.Content.Contains("tường đá"))
            {
                await message.Channel.SendMessageAsync("Truy tìm Nurikabe." + "\nBản đồ #14  (18)" + "\nBản đồ #13 Khiêu chiến  (14)" + "\nPBBM Thanh Hành Đăng - Aoandon #1  (3)");
            }

            if (message.Content.Contains("karakasa"))
            {
                await message.Channel.SendMessageAsync("Truy tìm Karakasa Kozou." + "\nBản đồ #4  (7)" + "\nBản đồ #8 Khiêu chiến  (14)" + "\nPBBM Cô Hoạch Điểu - Ubume #2  (3)");
            }

            if (message.Content.Contains("hắc báo"))
            {
                await message.Channel.SendMessageAsync("Truy tìm Hắc Báo." + "\nBản đồ #5  (1)" + "\nPBBM Hà Đồng - Kappa #4  (3)");
            }

            if (message.Content.Contains("ma chó"))
            {
                await message.Channel.SendMessageAsync("Truy tìm Ma Chó." + "\nBản đồ #7  (9)" + "\nPBBM Thanh Hành Đăng - Aoandon #1  (3)");
            }

            if (message.Content.Contains("kiseirei"))
            {
                await message.Channel.SendMessageAsync("Truy tìm Kiseirei." + "\nBản đồ #16  (9)" + "\nBản đồ #11 Khiêu chiến  (14)" + "\nPBBM Hải Phường Chủ - Umibouzu #2  (3)");
            }

            if (message.Content == "amanojaku" || message.Content == "amano")
            {

                await message.Channel.SendMessageAsync("Truy tìm Amanojaku Ki, Amanojaku Midori, Amanojaku Ao hay Amanojaku Aka?");
            }

            if (message.Content.Contains("trống") || message.Content.Contains("amanojaku ki"))
            {
                await message.Channel.SendMessageAsync("Truy tìm Amanojaku Ki." + "\nBản đồ #5  (4)" + "\n Bản đồ #8  (4)" + "\nPBBM Thanh Hành Đăng - Aoandon #4  (3)");
            }

            if (message.Content.Contains("amanojaku midori"))
            {
                await message.Channel.SendMessageAsync("Truy tìm Amanojaku Midori." + "\n Bản đồ #6  (9)" + "\nBản đồ #1 Khiêu chiến  (14)" + "\nPBBM Thanh Hành Đăng - Aoandon#5  (2)");
            }

            if (message.Content.Contains("amanojaku ao") || message.Content.Contains("con diều"))
            {
                await message.Channel.SendMessageAsync("Truy tìm Amanojaku Ao." + "\nBản đồ #10  (4)" + "\nBản đồ #8  (3)" + "\nPBBM Yêu Đao Cơ - Youtouhime #1,2,3  (4)");
            }

            if (message.Content.Contains("amanojaku aka") || message.Content.Contains("quỷ đỏ"))
            {
                await message.Channel.SendMessageAsync("Truy tìm Amanojaku Aka." + "\nBản đồ #13  (12)" + "\nBản đồ #14  (12)" + "\nPBBM Liêm Dứu - Kamaitachi #2  (3)");
            }

            if (message.Content.Contains("hokigami"))
            {
                await message.Channel.SendMessageAsync("Truy tìm Hokigami." + "\nBản đồ #8  (7)" + "\nBản đồ #5 Khiêu chiến  (14)" + "\nPBBM Đại Thiên Cẩu - Ootengu #1  (4)");
            }

            if (message.Content.Contains("akajita"))
            {
                await message.Channel.SendMessageAsync("Truy tìm Akajita." + "\nBản đồ #15  (6)" + "\nBản đồ #16 Khiêu chiến  (14)" + "\nPBBM Liêm Dứu - Kamaitachi #1  (3)");
            }

            if (message.Content.Contains("khiêu muội") || message.Content.Contains("kyonshi imoto"))
            {
                await message.Channel.SendMessageAsync("Truy tìm Kyonshi Imoto." + "\nBản đồ #12  (1)" + "\nBản đồ #15 Khiêu chiến  (14)" + "\nPBBM Hồng Diệp Quỷ Nữ - Momiji #2  (1)");
            }

            if (message.Content.Contains("ly miêu") || message.Content.Contains("bakedanuki"))
            {
                await message.Channel.SendMessageAsync("Truy tìm Bakedanuki." + "\nBản đồ #10  (5)" + "\nBản đồ #14 Khiêu chiến  (14)" + "\nPBBM Yêu Đao Cơ - Youtouchi #1,2,3  (4)");
            }

            if (message.Content.Contains("gaki"))
            {
                await message.Channel.SendMessageAsync("Truy tìm Gaki." + "\nBản đồ #11  (4)" + "\nBản đồ #11 Khiêu chiến  (14)" + "\nPBBM Hồng Diệp Quỷ Nữ - Momiji #1  (4)");
            }

            if (message.Content.Contains("karasu") || message.Content.Contains("nha thiên cẩu"))
            {
                await message.Channel.SendMessageAsync("Truy tìm Karasu Tengu." + "\nBản đồ #12  (6)" + "\nBản đồ #17 Khiêu chiến  (14)" + "\nPBBM Hồng Diệp Quỷ Nữ - Momiji #4  (2)" + "\nPBBM Đại Thiên Cẩu - Ootengu #5  (4)");
            }

            if (message.Content.Contains("kanko"))
            {
                await message.Channel.SendMessageAsync("Truy tìm Kanko." + "\nBản đồ #11  (4)" + "\n" + "\nBản đồ #4 Khiêu chiến  (14)" + "\nPBBM Hồng Diệp Quỷ Nữ - Momiji #1  (4)");
            }

            if (message.Content.Contains("yamawaro") || message.Content.Contains("quái lực") || message.Content.Contains("thạch chùy"))
            {
                await message.Channel.SendMessageAsync("Truy tìm Yamawaro." + "\nBản đồ #16  (6)" + "\nPBBM Hà Đồng - Kappa #2  (3)");
            }

            if (message.Content.Contains("yamausagi") || message.Content.Contains("thố"))
            {
                await message.Channel.SendMessageAsync("Truy tìm Yamausagi." + "\nBản đồ #9  (7)" + "\nBản đồ #9 Khiêu chiến  (14)");
            }

            if (message.Content.Contains("sửu nữ") || message.Content.Contains("hình nhân") || (message.Content.Contains("trù ếm") || (message.Content.Contains("nguyền rủa"))))
            {
                await message.Channel.SendMessageAsync("Truy tìm Ushi no Kokumairi." + "\nBản đồ #10 Khiêu chiến  (14)" + "\nPBBM Hà Đồng - Kappa #4  (2)");
            }

            if (message.Content.Contains("sanbi") || message.Content.Contains("màu đỏ") || message.Content.Contains("cây anh đào"))
            {
                await message.Channel.SendMessageAsync("Truy tìm Sanbi no Kitsune." + "\nBản đồ #18  (6)" + "\nBản đồ #3 Khiêu chiến  (14)" + "\nPBBM Đại Thiên Cẩu - Ootengu #1 (4)");
            }

            if (message.Content.Contains("jikigaeru") || message.Content.Contains("xúc xắc") || message.Content.Contains("ếch") || message.Content.Contains("gian lận")) 
            {
                await message.Channel.SendMessageAsync("Truy tìm Jikigaeru." + "\nBản đồ #4 Khiêu chiến  (14)" + "\nPBBM Đại Thiên Cẩu - Ootengu #3  (1)" + "\nPBBM Thanh Hành Đăng - Aoandon #5  (2)");
            }

            if (message.Content.Contains("tesso") || (message.Content.Contains("tài phú") || (message.Content.Contains("may mắn"))))
            {
                await message.Channel.SendMessageAsync("Truy tìm Tesso." + "\nBản đồ #9  (6)" + "\nBản đồ #3 Khiên chiến  (14)" + "\nPBBM Vũ Nữ - Ame Onna #1  (1)" + "\nPBBM Hồng Diệp Quỷ Nữ - Momiji #5  (2)");
            }

            if (message.Content.Contains("kamigui"))
            {
                await message.Channel.SendMessageAsync("Truy tìm Kamigui." + "\nBản đồ #10  (2)" + "\nBản đồ #5 Khiêu chiến  (14)" + "\nBí văn Hà Đồng - Kappa #3  (3)");
            }

            if (message.Content.Contains("sò") || message.Content.Contains("quạt") || message.Content.Contains("shouzu"))
            {
                await message.Channel.SendMessageAsync("Truy tìm Shouzu." + "\nNgự hồn tầng 10  (1)" + "\nYêu khí Shouzu  (3)");
            }

            if (message.Content.Contains("tọa") || message.Content.Contains("zashiki") || message.Content.Contains("quỷ hỏa"))
            {
                await message.Channel.SendMessageAsync("Truy tìm Zashiki Warashi." + "\nBản đồ #10  (4)" + "\nBản đồ #2 Khiêu chiến  (14)" + "\nPBBM Vũ Nữ - Ame Onna #1  (3)" + "\nPhá kết giới cũng có nữa đấy!");
                await message.Channel.SendMessageAsync("<:teehee:488165121261305869>");
            }

            

        }
    }
}
