using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Wpf_Ado.Net_App
{
    internal class Wpf_AdoViewModel:ViewModels.VeiwModelBase
    {
        private Command command;
        private string page;

        public Wpf_AdoViewModel()
        {
            command = new Command(ChangePage);
            page = "ViewingEvents.xaml";
        }

        public string Page
        {
            get { return page; }
            private set
            {
                page = value;
                OnPropertyChanged();
            }
        }

        public ICommand GetCommand { get => command; }

        public void ChangePage(object param)
        {
            switch (param.ToString())
            {
                case "viewingEvents":
                    Page = "ViewingEvents.xaml";
                    break;
                case "viewStatistics":
                    Page = "ViewStatistics.xaml";
                    break;
                default:
                    throw new InvalidEnumArgumentException();
                    
            }
        }
    }
}