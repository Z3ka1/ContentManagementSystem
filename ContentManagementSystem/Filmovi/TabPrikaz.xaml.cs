using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Shapes;

namespace Filmovi
{
    /// <summary>
    /// Interaction logic for TabPrikaz.xaml
    /// </summary>
    public partial class TabPrikaz : Window
    {

        public static BindingList<Komedija> Komedije { get; set; }
        public TabPrikaz()
        {
            Komedije = new BindingList<Komedija>();
            InitializeComponent();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void btnIzlaz_Click(object sender, RoutedEventArgs e)
        {
            MainWindow logovanje = new MainWindow();
            this.Close();
            logovanje.Show();
        }
        private void btnDodajFilm_Click(object sender, RoutedEventArgs e)
        {
            DodajFilm df = new DodajFilm();
            this.Hide();
            df.ShowDialog();
            this.Show();
        }
    }
}
