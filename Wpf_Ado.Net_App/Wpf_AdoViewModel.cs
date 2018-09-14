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
            page = "Page1.xaml";
        }

        public string Page
        {
            get { return page; }
            set
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
                    Page = "Page1.xaml";
                    break;
                case "viewStatistics":
                    Page = "Page2.xaml";
                    break;
                default:
                    throw new InvalidEnumArgumentException();
                    
            }


            //switch ((EPages)param)
            //{
            //    case EPages.first:
            //        page = "Page1.xaml";
            //        break;
            //    case EPages.last:
            //        page = "Page2.xaml";
            //        break;
            //    default:
            //        page = "Page2.xaml";
            //        break;
            //}

        }


    }
}