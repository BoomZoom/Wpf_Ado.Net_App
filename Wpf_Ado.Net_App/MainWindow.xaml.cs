using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace Wpf_Ado.Net_App
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /*
         Пример:

        form = form ?? new FormClass();

        Эту строку можно расписать как:

        form = form != null ? form : new FormClass();
        */

        public MainWindow()
        {
            InitializeComponent();
            DataContext = new Wpf_AdoViewModel();

            //айяяй
            // создаем привязку команды
            CommandBinding commandBinding = new CommandBinding();
            // устанавливаем команду
            commandBinding.Command = ApplicationCommands.Help;
            // устанавливаем метод, который будет выполняться при вызове команды
            commandBinding.Executed += CommandBinding_Executed;
            // добавляем привязку к коллекции привязок элемента Button
            helpButton.CommandBindings.Add(commandBinding);
            //---------------------------------------------
        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("Справка по приложению");
        }
    }
}
