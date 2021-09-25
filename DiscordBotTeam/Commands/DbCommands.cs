using DiscordBotTeam.Core.Services.Items;
using DiscordBotTeam.DAL;
using DiscordBotTeam.DAL.Models.items;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DiscordBotTeam.Commands
{
    public class DbCommands : BaseCommandModule
    {
        private readonly IItemService _itemService;

        public DbCommands(IItemService itemService)
        {
            _itemService = itemService;
        }

        [Command("addplayer")]
        [RequireRoles(RoleCheckMode.Any, "Admin")]
        public async Task AddItem(CommandContext ctx, string name)
        {
            var item = new Item();
            item.Name = name;
            item.Description = "800";

            await _itemService.CreateNewItemAsync(item).ConfigureAwait(false);

            await ctx.Channel.SendMessageAsync($"Игрок {name} создан").ConfigureAwait(false);
        }

        [Command("playerinfo")]
        public async Task ItemInfo(CommandContext ctx, string name)
        {
            var item = await _itemService.GetItemByName(name);

            if(item == null)
            {
                return;
            }

            await ctx.Channel.SendMessageAsync($"Name: {item.Name}, Rating: {item.Description}");
        }

        [Command("allplayersinfo")]
        public async Task AllItemsInfo(CommandContext ctx)
        {
            var itemsList = await _itemService.GetAllItems().ConfigureAwait(false);
            string message = "";

            foreach (var item in itemsList)
            {
                message += item.Name + " - " + item.Description + "\n";
            }

            await ctx.Channel.SendMessageAsync(message);

            //await ctx.Channel.SendMessageAsync(itemsList.Name);

            //while (myBool)
            //{
            //    string addMessage = itemsList.Current.Name + " " + itemsList.Current.Description + "\n";
            //    myBool = itemsList.MoveNext();
            //    message += addMessage;
            //}
        }
    }
}
