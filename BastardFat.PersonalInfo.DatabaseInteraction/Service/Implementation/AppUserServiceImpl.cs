using System.Data.Entity;
using System.Threading.Tasks;
using BastardFat.PersonalInfo.DatabaseInteraction.Models.Entity;
using BastardFat.PersonalInfo.DatabaseInteraction.Repository.Interfaces;
using BastardFat.PersonalInfo.DatabaseInteraction.Service.Interfaces;
using BastardFat.PersonalInfo.DatabaseInteraction.Tools;
using BastardFat.PersonalInfo.DatabaseInteraction.UnitOfWork.Interfaces;

namespace BastardFat.PersonalInfo.DatabaseInteraction.Service.Implementation
{
    public class AppUserServiceImpl : IAppUserService
    {
        private readonly IAppUserRepository _appUserRepository;
        private readonly IMainUnitOfWork _unitOfWork;
        

        public AppUserServiceImpl(IAppUserRepository appUserRepository, IMainUnitOfWork unitOfWork)
        {
            _appUserRepository = appUserRepository;
            _unitOfWork = unitOfWork;
        }


        public async Task<bool> CanLogin(string username, string password)
        {
            return await _appUserRepository
                .Query()
                .AnyAsync(u => u.Name == username && u.PasswordHash == CryptHelper.SHA1(password));
        }

        public async Task<int> Register(string username, string password)
        {
            var result =
                _appUserRepository.Add(new AppUser
                {
                    PasswordHash = CryptHelper.SHA1(password),
                    Name = username
                });
            await _unitOfWork.CommitAsync();
            return result.Id;
        }

        public async Task<bool> Delete(int id)
        {
            var res = await _appUserRepository.DeleteAsync(id);
            await _unitOfWork.CommitAsync();
            return res?.Id == id;
        }
    }
}