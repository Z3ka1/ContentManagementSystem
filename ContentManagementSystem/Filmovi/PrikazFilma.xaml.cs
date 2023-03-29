using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace Filmovi
{
    /// <summary>
    /// Interaction logic for PrikazFilma.xaml
    /// </summary>
    public partial class PrikazFilma : Window
    {
        public PrikazFilma(int idx)
        {
            InitializeComponent();

            tbNaziv.Text = TabPrikaz.Komedije[idx].Ime;
            tbTrajanje.Text = TabPrikaz.Komedije[idx].Trajanje.ToString() + " minuta";
            tbDatum.Text = TabPrikaz.Komedije[idx].DatumDodavanja.ToString("dd/MM/yyyy");
            LoadOpis();
            Uri uri = new Uri(TabPrikaz.Komedije[idx].Slika);
            imgSlika.Source = new BitmapImage(uri);
        }

        private void LoadOpis()
        {
            string fileName ="..\\..\\RTF\\" + tbNaziv.Text + ".rtf";
            TextRange range;
            FileStream fStream;
            if (File.Exists(fileName))
            {
                range = new TextRange(rtbOpis.Document.ContentStart, rtbOpis.Document.ContentEnd);
                fStream = new FileStream(fileName, FileMode.OpenOrCreate);
                range.Load(fStream, DataFormats.Rtf);
                fStream.Close();
            }
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void btnIzlaz_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
