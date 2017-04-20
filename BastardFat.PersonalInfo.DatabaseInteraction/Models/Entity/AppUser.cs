using System;

namespace BastardFat.PersonalInfo.DatabaseInteraction.Models.Entity
{
    public class AppUser : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PasswordHash { get; set; }
    }
}
