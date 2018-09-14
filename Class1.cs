using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApplication1.Modules
{
    public class Class1 : ModuleBase<SocketCommandContext>
    {

        [Command("hi")]
        public async Task Hi()
        {
            if (Context.User.Id == 470809493169635328)
            {
                await Context.Channel.SendMessageAsync("Chào papa!");
            }
            else
            {
                await Context.Channel.SendMessageAsync("Chào " + Context.Message.Author.Mention + "!");
            }
    
        }
        [Command("say")]
        public async Task Say([Remainder]string message)
        {
            await Context.Channel.SendMessageAsync(message);
        }
          [Command("ơi")]
         public async Task Ơi()
        {
            if (Context.User.Id == 488008168832761862)
            {
                await Context.Channel.SendMessageAsync("Dạ?");
            }
            else
            {
                await Context.Channel.SendMessageAsync("Sao vậy" + Context.Message.Author.Mention + "?");
            }
        }

          [Command("clean")]
          public async Task Clean(int n)
        {
            var messages = await Context.Channel.GetMessagesAsync(n).Flatten();
            if (n > 100)
            {
                await Context.Channel.SendMessageAsync("Chỉ được phép xóa tối đa 100 tin nhắn!");
            }
            else
            {
                await Context.Channel.DeleteMessagesAsync(messages);
                await Context.Channel.SendMessageAsync("Đã xóa " + n + " tin nhắn!");
            }
        }
    }
}
