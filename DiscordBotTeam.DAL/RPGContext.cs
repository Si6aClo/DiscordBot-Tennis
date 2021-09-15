using DiscordBotTeam.DAL.Models.items;
using Microsoft.EntityFrameworkCore;

namespace DiscordBotTeam.DAL
{
    public class RPGContext : DbContext
    {
        public RPGContext(DbContextOptions<RPGContext> options) : base(options) { }
        public DbSet<Item> Items { get; set; }
    }
}
