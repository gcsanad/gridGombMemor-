using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace gombGrid
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int lenyomas = 0;
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnGeneral_Click(object sender, RoutedEventArgs e)
        {
            Random rnd = new Random();
            ugGombok.Rows = ((int)sliSor.Value);
            ugGombok.Columns = ((int)sliOszlop.Value);
            ugGombok.Children.Clear();
            List<int> lista = new List<int>();    
            for (int i = 0; i < (ugGombok.Rows*ugGombok.Columns)/2; i++)
            {
                lista.Add(i);
                lista.Add(i);
            }
            for (int index = 0; index < ugGombok.Rows * ugGombok.Columns; index++)
            {
                Button gomb = new Button();
                gomb.Background = Brushes.ForestGreen;
                int randomSzam = rnd.Next(lista.Count);
                gomb.Content =lista[randomSzam];
                lista.Remove(Convert.ToInt32(gomb.Content));
                gomb.Name = $"Gomb{index}";
                gomb.AddHandler(ButtonBase.ClickEvent, new RoutedEventHandler(Button_Click));
                ugGombok.Children.Add(gomb);

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (lenyomas == 2)
            {
            foreach (var btn in ugGombok.Children.OfType<Button>().Where(x => x.Name.StartsWith("Gomb")))
                btn.Background = Brushes.ForestGreen;
                lenyomas = 0;
                Button gomb = sender as Button;
                gomb.Background = Brushes.DodgerBlue;
                lenyomas++;

            }

            else
            {
            Button gomb = sender as Button;
            gomb.Background = Brushes.DodgerBlue;
                lenyomas++;
            }
        }
    }
}
