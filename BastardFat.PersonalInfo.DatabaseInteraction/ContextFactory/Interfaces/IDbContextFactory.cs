using System.Data.Entity;

namespace BastardFat.PersonalInfo.DatabaseInteraction.ContextFactory.Interfaces
{
    public interface IDbContextFactory<out TDbContext> where TDbContext : DbContext
    {
        TDbContext GetDbContext();
    }
}
