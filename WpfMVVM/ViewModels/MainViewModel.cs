using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfMVVM.Commands;
using WpfMVVM.Models;
using WpfMVVM.Views;

namespace WpfMVVM.ViewModels
{
    class MainViewModel : BaseViewModel
    {
        public ObservableCollection<HumanModel> HumansCollection { get; set; }

        public MainViewModel(List<HumanModel> people)
        {
            HumansCollection = new ObservableCollection<HumanModel>(people);
        }

        private ICommand _minimizeCommand;

        public ICommand MinimizeCommand
        {
            get
            {
                return _minimizeCommand ?? (_minimizeCommand=new BaseCommand(arg=>OnMinimizeWindow()));
            }
        }

        private void OnMinimizeWindow()
        {
            Application.Current.MainWindow.WindowState = WindowState.Minimized;
            //Application.Current.Windows[0].WindowState = WindowState.Minimized;
        }

        private ICommand _addCommand;

        public ICommand AddCommand
        {
            get
            {
                return _addCommand ?? (_addCommand = new BaseCommand(arg => OnAddHuman()));
            }
        }

        private void OnAddHuman()
        {
           // HumansCollection.Add(new HumanModel { FirstName = "John", LastName = "Doe", BirthDate = new DateTime(2002, 7, 18)});

            AddHumanView addHumanView = new AddHumanView
            {
                DataContext = new AddHumanViewModel(AddHumanInCollection)
            };
            addHumanView.ShowDialog();
        }

        private void AddHumanInCollection(HumanModel human)
        {
            HumansCollection.Add(human);
        }
    }
}
