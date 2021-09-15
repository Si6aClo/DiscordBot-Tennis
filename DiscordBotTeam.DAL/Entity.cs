using System.ComponentModel.DataAnnotations;

namespace DiscordBotTeam.DAL
{
    public abstract class Entity
    {
        [Key]
        public int ID { get; set; }
    }
}
