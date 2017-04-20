using BastardFat.PersonalInfo.DatabaseInteraction.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BastardFat.PersonalInfo.DatabaseInteraction.Service.Interfaces
{
    public interface IPersonService
    {
        Task<IEnumerable<PersonModel>> GetAll();
        Task<IEnumerable<PersonModel>> Search(string query);
        Task<PersonModel> AddPerson(PersonModel model);
        Task<PersonModel> DeletePerson(int id);
    }
}
