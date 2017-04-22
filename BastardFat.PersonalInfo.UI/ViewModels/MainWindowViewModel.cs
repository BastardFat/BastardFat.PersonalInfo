using BastardFat.PersonalInfo.DatabaseInteraction.ContextFactory.Implementation;
using BastardFat.PersonalInfo.DatabaseInteraction.Models.EntityModels;
using BastardFat.PersonalInfo.DatabaseInteraction.Repository.Implementation;
using BastardFat.PersonalInfo.DatabaseInteraction.Service.Implementation;
using BastardFat.PersonalInfo.DatabaseInteraction.Service.Interfaces;
using BastardFat.PersonalInfo.DatabaseInteraction.UnitOfWork.Implementation;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BastardFat.PersonalInfo.UI.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly IPersonService _service;


        public MainWindowViewModel()
        {
            var factory = new MainDbContextFactoryImpl();
            _service = new PersonServiceImpl(new PersonRepositoryImpl(factory), new MainUnitOfWorkImpl(factory));
            Refresh().Wait();
            RefreshCommand = new RelayCommand(() => Refresh().Wait());
        }



        private ObservableCollection<PersonModel> _personSet;

        public ObservableCollection<PersonModel> PersonSet
        {
            get { return _personSet; }
            set { Set(ref _personSet, value, nameof(PersonSet)); }
        }

        private PersonModel _selectedPerson;

        public PersonModel SelectedPerson
        {
            get { return _selectedPerson; }
            set { Set(ref _selectedPerson, value, nameof(SelectedPerson)); }
        }

        public ICommand RefreshCommand { get; set; }

        private async Task Refresh()
        {
            PersonSet = new ObservableCollection<PersonModel>(await _service.GetAll());
        }

    }
}
