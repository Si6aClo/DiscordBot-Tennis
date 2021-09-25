using DiscordBotTeam.DAL;
using DiscordBotTeam.DAL.Models.items;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace DiscordBotTeam.Core.Services.Items
{
    public interface IItemService
    {
        Task<Item> GetItemByName(string itemName);
        Task CreateNewItemAsync(Item item);
        Task<List<Item>> GetAllItems();
    }

    public class ItemService : IItemService
    {
        private readonly RPGContext _context;

        public ItemService(RPGContext ctx)
        {
            _context = ctx;
        }

        public async Task CreateNewItemAsync(Item item)
        {
            await _context.AddAsync(item).ConfigureAwait(false);

            await _context.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task<List<Item>> GetAllItems()
        {
            await _context.Items.LoadAsync();
            
            return await _context.Items.ToListAsync();
        }

        public async Task<Item> GetItemByName(string itemName)
        {
            itemName = itemName.ToLower();
            return await _context.Items.FirstOrDefaultAsync(x => x.Name.ToLower() == itemName).ConfigureAwait(false);
        }
    }
}
