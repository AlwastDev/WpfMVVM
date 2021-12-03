using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfMVVM.Commands;
using WpfMVVM.Models;

namespace WpfMVVM.ViewModels
{
    class AddHumanViewModel : BaseViewModel
    {
        private Action<HumanModel> _addHumanInCollection;

        public AddHumanViewModel(Action<HumanModel> addHumanInCollection)
        {
            _addHumanInCollection = addHumanInCollection;

            CurrentHuman = new HumanModel { BirthDate = DateTime.Today };
        }

        private HumanModel _currentHuman;

        public HumanModel CurrentHuman
        {
            get { return _currentHuman; }
            set { 
                _currentHuman = value;
                OnPropertyChanged(nameof(CurrentHuman));
            }
        }

        private ICommand _cancelCommand;

        public ICommand CancelCommand
        {
            get
            {
                return _cancelCommand ?? (_cancelCommand = new BaseCommand(arg => OnCancelCommand()));
            }
        }

        private void OnCancelCommand()
        {
            //Application.Current.Windows[1].Close();
            Window window = Application.Current.Windows.Cast<Window>().FirstOrDefault(w => w.Name == "AddView");
            if (window!=null)
            {
                window.Close();
            }
        }

        private ICommand _saveCommand;

        public ICommand SaveCommand
        {
            get
            {
                return _saveCommand ?? (_saveCommand = new BaseCommand(arg =>OnSaveHuman(), CanSaveHuman));
            }
        }

        private void OnSaveHuman()
        {
            _addHumanInCollection(CurrentHuman);

            OnCancelCommand();
        }

        private bool CanSaveHuman(object arg)
        {
            return !string.IsNullOrWhiteSpace(CurrentHuman.FirstName) && !string.IsNullOrWhiteSpace(CurrentHuman.LastName);
        }

    }
}
