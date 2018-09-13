using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
namespace Wpf_Ado.Net_App
{
    internal class Wpf_AdoViewModel:INotifyPropertyChanged
    {
        public Wpf_AdoViewModel()
        {
            page = "Page2.xaml";
        }

        private string page;
        public string Page
        {
            get { return page; }
            set
            {
                page = value;
                OnPropertyChanged("Page");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}