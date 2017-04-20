using BastardFat.PersonalInfo.DatabaseInteraction.Context;
using BastardFat.PersonalInfo.DatabaseInteraction.ContextFactory.Interfaces;
using BastardFat.PersonalInfo.DatabaseInteraction.UnitOfWork.Base;
using BastardFat.PersonalInfo.DatabaseInteraction.UnitOfWork.Interfaces;

namespace BastardFat.PersonalInfo.DatabaseInteraction.UnitOfWork.Implementation
{
    public class MainUnitOfWorkImpl : UnitOfWorkBase<MainDbContext, IMainDbContextFactory>, IMainUnitOfWork
    {
        public MainUnitOfWorkImpl(IMainDbContextFactory dbContextFactory) : base(dbContextFactory)
        {
        }
    }
}