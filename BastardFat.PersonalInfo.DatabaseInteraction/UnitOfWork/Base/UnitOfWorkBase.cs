using System.Data.Entity;
using System.Threading.Tasks;
using BastardFat.PersonalInfo.DatabaseInteraction.ContextFactory.Interfaces;
using BastardFat.PersonalInfo.DatabaseInteraction.UnitOfWork.Interfaces;

namespace BastardFat.PersonalInfo.DatabaseInteraction.UnitOfWork.Base
{
    public abstract class UnitOfWorkBase<TDbContext, TDbContextFactory> : IUnitOfWork<TDbContext>
        where TDbContext : DbContext
        where TDbContextFactory: IDbContextFactory<TDbContext>
    {
        protected UnitOfWorkBase(TDbContextFactory dbContextFactory)
        {
            DbContextFactory = dbContextFactory;
        }

        public virtual void Commit()
        {
            DbContext.SaveChanges();
        }

        public virtual async Task CommitAsync()
        {
            await DbContext.SaveChangesAsync();
        }

        protected TDbContext DbContext => DbContextFactory.GetDbContext();
        protected IDbContextFactory<TDbContext> DbContextFactory { get; }
    }
}