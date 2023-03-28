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
        private Common.DataIO serializer = new Common.DataIO();
        public static BindingList<Komedija> Komedije { get; set; }

        private bool isAdmin = false;
        public TabPrikaz(bool admin)
        {
            this.isAdmin = admin;

            Komedije = serializer.DeSerializeObject<BindingList<Common.Komedija>>("komedije.xml");
            if(Komedije == null)
            {
                Komedije = new BindingList<Komedija>();
            }
            DataContext = this;
            InitializeComponent();

            if(!isAdmin)
            {
                btnDodajFilm.Visibility = Visibility.Hidden;
                btnObrisiIzbor.Visibility = Visibility.Hidden;
                dgTabela.IsReadOnly = true;
            }
            
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

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            serializer.SerializeObject<BindingList<Komedija>>(Komedije, "komedije.xml");
        }

        public void OnHyperlinkClick(object sender, RoutedEventArgs e)
        {
            if(isAdmin)
            {
                DodajFilm df = new DodajFilm(dgTabela.SelectedIndex);
                this.Hide();
                df.ShowDialog();
                this.Show();
            }
            else
            {
                PrikazFilma pf = new PrikazFilma(dgTabela.SelectedIndex);
                this.Hide();
                pf.ShowDialog();
                this.Show();
            }
        }

        private void btnObrisiIzbor_Click(object sender, RoutedEventArgs e)
        {
            int brObrisanih = 0;
            int brFilmova = dgTabela.Items.Count;
            for(int i = 0; i < brFilmova; i++)
            {
                var item = dgTabela.Items[i - brObrisanih];
                var myCheckBox = dgTabela.Columns[0].GetCellContent(item) as CheckBox;

                if((bool)myCheckBox.IsChecked)
                {
                    Komedije.RemoveAt(i - brObrisanih);
                    brObrisanih++;
                }
            }

            if (brObrisanih == 0)
                MessageBox.Show("Da bi ste obrisali film iz liste potrebno je da " +
                    "oznacite \"check box\" filma koji brisete!","Brisanje",MessageBoxButton.OK,MessageBoxImage.Information);

        }
    }
}
