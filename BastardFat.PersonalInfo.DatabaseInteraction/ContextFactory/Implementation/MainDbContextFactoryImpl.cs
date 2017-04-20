using BastardFat.PersonalInfo.DatabaseInteraction.Context;
using BastardFat.PersonalInfo.DatabaseInteraction.ContextFactory.Base;
using BastardFat.PersonalInfo.DatabaseInteraction.ContextFactory.Interfaces;

namespace BastardFat.PersonalInfo.DatabaseInteraction.ContextFactory.Implementation
{
    public class MainDbContextFactoryImpl :
        DbContextFactoryBase<MainDbContext>, IMainDbContextFactory
    {
        
    }
}