using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IO;
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

namespace Filmovi
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void btnIzlaz_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnPrijava_Click(object sender, RoutedEventArgs e)
        {
            //TODO Validacija prijave
            bool admin = false;
            bool isUserFound = false;
            
            using(StreamReader file = new StreamReader("korisnici.txt"))
            {
                string line;
                while((line = file.ReadLine())!=null)
                {
                    string[] parts = line.Split('|');
                    if (parts[0] == tbKorisnickoIme.Text && parts[1] == pwbLozinka.Password)
                    {
                        isUserFound = true;
                        if (parts[2] == "admin")
                            admin = true;
                        file.Close();
                        break;
                    }
                }

                if (isUserFound)
                {
                    TabPrikaz prikaz = new TabPrikaz(admin);
                    this.Close();
                    prikaz.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Pogresno korisnicko ime ili lozinka!","Greska",MessageBoxButton.OK,MessageBoxImage.Stop);
                }

            }
        }

    }
}
