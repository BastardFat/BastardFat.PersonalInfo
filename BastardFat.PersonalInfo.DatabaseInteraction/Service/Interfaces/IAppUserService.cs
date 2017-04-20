using BastardFat.PersonalInfo.DatabaseInteraction.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BastardFat.PersonalInfo.DatabaseInteraction.Service.Interfaces
{
    public interface IAppUserService
    {
        Task<bool> CanLogin(string username, string password);
        Task<int> Register(string username, string password);
        Task<bool> Delete(int id);
    }
}
