using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WpfMVVM.Models;
using WpfMVVM.ViewModels;
using WpfMVVM.Views;

namespace WpfMVVM
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            List<HumanModel> models = new List<HumanModel>
            {
                new HumanModel{FirstName="Homer", LastName="Simpson", BirthDate=new DateTime(1997,7, 12)},
                new HumanModel{FirstName="Lisa", LastName="Simpson", BirthDate=new DateTime(2016,3, 25)},
                new HumanModel{FirstName="Bart", LastName="Simpson", BirthDate=new DateTime(2018,11, 8)}
            };

            MainView mainView = new MainView
            {
                DataContext = new MainViewModel(models)
            };
            mainView.Show();
        }
    }
}
