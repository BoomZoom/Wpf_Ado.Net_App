using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Wpf_Ado.Net_App
{
    internal class Wpf_AdoViewModel: INotifyPropertyChanged
    {
      

        public Wpf_AdoViewModel()
        {
            page = "Page1.xaml";
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

        public void ChengePage()
        {
            page = "Page2.xaml";
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}