using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BotPrototypeEmptyMVC.Models
{
    public class BotPrototypeEmptyMVCContext : DbContext
    {
        public BotPrototypeEmptyMVCContext() : base("name=BotPrototypeEmptyMVCContext")
        {
        }

        public System.Data.Entity.DbSet<BotPrototypeEmptyMVC.Models.TelegramResponse> Responses { get; set; }
        public System.Data.Entity.DbSet<BotPrototypeEmptyMVC.Models.TelegramAwaitable> Awaitable { get; set; }
    }
}
