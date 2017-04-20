using BastardFat.PersonalInfo.DatabaseInteraction.Service.Interfaces;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using BastardFat.PersonalInfo.DatabaseInteraction.Models.Entity;
using BastardFat.PersonalInfo.DatabaseInteraction.Models.EntityModels;
using BastardFat.PersonalInfo.DatabaseInteraction.Repository.Interfaces;
using BastardFat.PersonalInfo.DatabaseInteraction.UnitOfWork.Interfaces;

namespace BastardFat.PersonalInfo.DatabaseInteraction.Service.Implementation
{
    public class PersonServiceImpl : IPersonService
    {
        private readonly IPersonRepository _personRepository;
        private readonly IMainUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PersonServiceImpl(IPersonRepository personRepository, IMainUnitOfWork unitOfWork)
        {
            _personRepository = personRepository;
            _unitOfWork = unitOfWork;

            _mapper = new MapperConfiguration(x =>
            {
                x.CreateMap<Person, PersonModel>()
                    .ReverseMap();
            }).CreateMapper();

        }

        public async Task<PersonModel> AddPerson(PersonModel model)
        {
            var result = _personRepository
                .Add(_mapper.Map<Person>(model));
            await _unitOfWork.CommitAsync();
            return _mapper.Map<PersonModel>(result);
        }

        public async Task<PersonModel> DeletePerson(int id)
        {
            var result = await _personRepository.DeleteAsync(id);
            await _unitOfWork.CommitAsync();
            return _mapper.Map<PersonModel>(result);
        }

        public async Task<IEnumerable<PersonModel>> GetAll()
        {
            return await _personRepository
                .Query()
                .ProjectTo<PersonModel>(_mapper.ConfigurationProvider)
                .ToArrayAsync();
        }

        public async Task<IEnumerable<PersonModel>> Search(string query)
        {
            return await _personRepository
                .Query()
                .Where(x =>
                    x.FirstName.Contains(query) ||
                    x.LastName.Contains(query) ||
                    x.Tags.Split(' ').Any(t => t == query)
                )
                .ProjectTo<PersonModel>(_mapper.ConfigurationProvider)
                .ToArrayAsync();
        }
    }
}
