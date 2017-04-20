using BastardFat.PersonalInfo.DatabaseInteraction.Tools;
using System.Data.Entity;

namespace BastardFat.PersonalInfo.DatabaseInteraction.Context
{
    internal class DbInitializer : DropCreateDatabaseIfModelChanges<MainDbContext>
    {
        protected override void Seed(MainDbContext context)
        {
            context.Users.Add(new Models.Entity.AppUser
            {
                Name = "admin",
                PasswordHash = CryptHelper.SHA1("admin")
            });
            base.Seed(context);
        }
    }
}