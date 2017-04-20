using BastardFat.PersonalInfo.DatabaseInteraction.Context;
using BastardFat.PersonalInfo.DatabaseInteraction.Models.Entity;
using BastardFat.PersonalInfo.DatabaseInteraction.Repository.Base;
using BastardFat.PersonalInfo.DatabaseInteraction.Repository.Interfaces;
using BastardFat.PersonalInfo.DatabaseInteraction.ContextFactory.Interfaces;

namespace BastardFat.PersonalInfo.DatabaseInteraction.Repository.Implementation
{
    public class PersonRepositoryImpl : BaseRepository<Person, MainDbContext>, IPersonRepository
    {
        public PersonRepositoryImpl(IDbContextFactory<MainDbContext> dbContextFactory) : base(dbContextFactory)
        {
        }
    }
}
