using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BastardFat.PersonalInfo.DatabaseInteraction.Models.Entity
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public uint Age { get; set; }
        public string Description { get; set; }
        public string TagsJsonCollection { get; set; }
    }
}
