using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

namespace BastardFat.PersonalInfo.UI.ViewModels
{
    internal class TestWindowViewModel : ViewModelBase
    {
        public TestWindowViewModel()
        {
            Collection = new ObservableCollection<ClassWithString>();
            foreach (var s in new[] {"Item 1", "Item 2", "Fuck"})
                Collection.Add(new ClassWithString {Data = s});
            SelectedItem = Collection[0];


            AddCommand = new RelayCommand(AddMethod);
            DeleteCommand = new RelayCommand(DeleteMethod);
        }


        private ObservableCollection<ClassWithString> _collection;

        public ObservableCollection<ClassWithString> Collection
        {
            get { return _collection; }
            set { Set(ref _collection, value, nameof(Collection)); }
        }


        private ClassWithString _selectedItem;

        public ClassWithString SelectedItem
        {
            get { return _selectedItem; }
            set { Set(ref _selectedItem, value, nameof(SelectedItem)); }
        }

        private string _newItem;

        public string NewItem
        {
            get { return _newItem; }
            set { Set(ref _newItem, value, nameof(NewItem)); }
        }


        public ICommand AddCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        private void AddMethod()
        {
            Collection.Add(new ClassWithString {Data = NewItem});
        }

        private void DeleteMethod()
        {
            Collection.Remove(SelectedItem);
        }
    }

    internal class ClassWithString
    {
        public string Data { get; set; }
    }
}
