using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BastardFat.PersonalInfo.DatabaseInteraction.Models.EntityModels
{
    public class PersonModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public uint Age { get; set; }
        public string PhotoUrl { get; set; }
        public string Description { get; set; }
        public string Tags { get; set; }
    }
}
