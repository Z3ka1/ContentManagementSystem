using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
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
    /// Interaction logic for DodajFilm.xaml
    /// </summary>
    public partial class DodajFilm : Window
    {
        int izmena; //-1 kada dodajem novi film, >-1 kada menjam postojeci
        string slika = "";
        Common.Komedija kopija;
        public DodajFilm()
        {
            izmena = -1;

            InitializeComponent();

            tbIme.Text = "Unesite ime filma!";
            tbIme.Foreground = Brushes.LightBlue;
            tbTrajanje.Text = "Unesite duzinu filma u minutama!";
            tbTrajanje.Foreground = Brushes.LightBlue;


            cmbFont.ItemsSource = Fonts.SystemFontFamilies.OrderBy(f => f.Source);
            cmbFontSize.ItemsSource = new List<double> { 10, 12, 14, 16, 18, 29, 22, 24, 26, 28, 30, 32, 34 };
            
            for (int i = 0; i < (typeof(Colors).GetProperties().Count()); i++)
            {
                cmbFontColor.Items.Add(typeof(Colors).GetProperties()[i].ToString().Split(' ')[1]);
            }

            cmbFontColor.SelectedItem = "Black";

        }

        public DodajFilm(int idx)
        {
            izmena = idx;
            InitializeComponent();
            btnDodaj.Content = "Izmeni";
            lblDodavanjeFilma.Content = "Izmena filma";

            kopija = new Common.Komedija(TabPrikaz.Komedije[idx]);
            TabPrikaz.Komedije.RemoveAt(idx);

            tbIme.Text = kopija.Ime;
            tbTrajanje.Text = kopija.Trajanje.ToString();
            LoadOpis();
            slika = kopija.Slika;
            Uri uri = new Uri(slika, UriKind.Relative);
            imgSlika.Source = new BitmapImage(uri);

            cmbFont.ItemsSource = Fonts.SystemFontFamilies.OrderBy(f => f.Source);
            cmbFontSize.ItemsSource = new List<double> { 10, 12, 14, 16, 18, 29, 22, 24, 26, 28, 30, 32, 34 };

            for (int i = 0; i < (typeof(Colors).GetProperties().Count()); i++)
            {
                cmbFontColor.Items.Add(typeof(Colors).GetProperties()[i].ToString().Split(' ')[1]);
            }
            cmbFontColor.SelectedItem = "Black";

        }

        private void LoadOpis()
        {
            string fileName = "..\\..\\RTF\\" + kopija.Ime + ".rtf";
            TextRange range;
            FileStream fStream;
            if(File.Exists(fileName))
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
            if (izmena != -1)
            {
                TabPrikaz.Komedije.Insert(izmena,kopija);
                this.Close();
                return;
            }
            this.Close();
        }


        private void cmbFont_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbFont.SelectedItem != null && !rtbOpis.Selection.IsEmpty)
                rtbOpis.Selection.ApplyPropertyValue(Inline.FontFamilyProperty, cmbFont.SelectedItem);
        }

        private void cmbFontSize_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbFontSize.SelectedItem != null && !rtbOpis.Selection.IsEmpty)
                rtbOpis.Selection.ApplyPropertyValue(Inline.FontSizeProperty, cmbFontSize.SelectedValue); ;
        }

        private void cmbFontColor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbFontColor.SelectedItem != null)
            {
                rtbOpis.Selection.ApplyPropertyValue(Inline.ForegroundProperty, (SolidColorBrush)(new BrushConverter().ConvertFrom(cmbFontColor.SelectedValue.ToString())));
                //if (!ChosenColors.Contains(cmbFontColor.SelectedValue.ToString()))
                //{
                //    ChosenColors.Add(cmbFontColor.SelectedValue.ToString());
                //}
            }
        }

        //private string GetColor(SolidColorBrush brush)
        //{
        //    string result = string.Empty;

        //    SolidColorBrush stringBrush = null;

        //    foreach (string s in ChosenColors)
        //    {
        //        stringBrush = ((SolidColorBrush)(new BrushConverter().ConvertFrom(s)));

        //        if ((stringBrush.Color.A == brush.Color.A) && (stringBrush.Color.R == brush.Color.R) && (stringBrush.Color.G == brush.Color.G) && (stringBrush.Color.B == brush.Color.B))
        //        {
        //            result = s;
        //        }
        //    }

        //    return result;
        //}

        private void rtbOpis_SelectionChanged(object sender, RoutedEventArgs e)
        {
            object temp = rtbOpis.Selection.GetPropertyValue(Inline.FontWeightProperty);
            btnBold.IsChecked = (temp != DependencyProperty.UnsetValue) && (temp.Equals(FontWeights.Bold));

            temp = rtbOpis.Selection.GetPropertyValue(Inline.FontStyleProperty);
            btnItalic.IsChecked = (temp != DependencyProperty.UnsetValue) && (temp.Equals(FontStyles.Italic));

            temp = rtbOpis.Selection.GetPropertyValue(Inline.TextDecorationsProperty);
            btnUnderline.IsChecked = (temp != DependencyProperty.UnsetValue) && (temp.Equals(TextDecorations.Underline));

            temp = rtbOpis.Selection.GetPropertyValue(Inline.FontFamilyProperty);
            cmbFont.SelectedItem = temp;

            temp = rtbOpis.Selection.GetPropertyValue(Inline.FontSizeProperty);
            cmbFontSize.SelectedItem = temp.ToString();

            temp = rtbOpis.Selection.GetPropertyValue(Inline.ForegroundProperty);
            //cmbFontColor.SelectedItem = GetColor((SolidColorBrush)(new BrushConverter().ConvertFrom(temp.ToString())));


        }

        private void rtbOpis_TextChanged(object sender, TextChangedEventArgs e)
        {
            tbBrojac.Text = brojReci2().ToString();
        }

        private int brojReci1()
        {
            string text = new TextRange(rtbOpis.Document.ContentStart, rtbOpis.Document.ContentEnd).Text;
            //tbBrojac.Text = text.Split(' ').Count().ToString();

            char[] splitWordsBy = { '?', '!', '.', '\n', ' ', ':', ';' };
            int wordCount = text.Split(splitWordsBy, StringSplitOptions.RemoveEmptyEntries).Length;
            return wordCount;
        }

        private int brojReci2()
        {
            int count = 0;
            int idx = 0;
            string text = new TextRange(rtbOpis.Document.ContentStart, rtbOpis.Document.ContentEnd).Text;

            while (idx < text.Length && char.IsWhiteSpace(text[idx]))
                idx++;

            while(idx < text.Length)
            {
                while (idx < text.Length && !char.IsWhiteSpace(text[idx]))
                    idx++;

                count++;

                while (idx < text.Length && char.IsWhiteSpace(text[idx]))
                    idx++;
            }
            return count;
        }

        private void btnUmetni_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                //slika = openFileDialog.FileName;
                //Uri uri = new Uri(slika);
                //imgSlika.Source = new BitmapImage(uri);
                
                string absolute = openFileDialog.FileName;
                int relativePathStartIndex = absolute.IndexOf("Slike");
                slika = "..\\..\\" + absolute.Substring(relativePathStartIndex);

                Uri uri = new Uri(slika , UriKind.Relative);
                imgSlika.Source = new BitmapImage(uri);


            }
        }

        private bool validate()
        {
            bool isValid = true;
            
            if(tbIme.Text.Trim().Equals(string.Empty) || tbIme.Text.Trim().Equals("Unesite ime filma!"))
            {
                isValid = false;
                tbIme.BorderBrush = Brushes.Red;
                tbIme.BorderThickness = new Thickness(1);
                lblImeGreska.Content = "Obavezno polje!";
            }
            else
            {
                tbIme.BorderBrush = Brushes.Green;
                tbIme.BorderThickness = new Thickness(2);
                lblImeGreska.Content = "";
            }

            if(tbTrajanje.Text.Trim().Equals(string.Empty) || tbTrajanje.Text.Trim().Equals("Unesite duzinu filma u minutama!"))
            {
                isValid = false;
                tbTrajanje.BorderBrush = Brushes.Red;
                tbTrajanje.BorderThickness = new Thickness(1);
                lblTrajanjeGreska.Content = "Obavezno polje!";
            }
            else
            {
                int br;
                bool isNum = int.TryParse(tbTrajanje.Text, out br);

                if(isNum)
                {
                    if(br <= 0)
                    {
                        isValid = false;
                        tbTrajanje.BorderBrush = Brushes.Red;
                        tbTrajanje.BorderThickness = new Thickness(1);
                        lblTrajanjeGreska.Content = "Uneti pozitivan broj!";
                    }
                    else
                    {
                        tbTrajanje.BorderBrush = Brushes.Green;
                        tbTrajanje.BorderThickness = new Thickness(2);
                        lblTrajanjeGreska.Content = "";
                    }
                }
                else
                {
                    isValid = false;
                    tbTrajanje.BorderBrush = Brushes.Red;
                    tbTrajanje.BorderThickness = new Thickness(1);
                    lblTrajanjeGreska.Content = "Prihvataju se samo cifre!";
                }

            }

            if(imgSlika.Source == null)
            {
                isValid = false;
            }


            return isValid;
        }

        private void tbIme_LostFocus(object sender, RoutedEventArgs e)
        {
            if(tbIme.Text.Trim().Equals(string.Empty))
            {
                tbIme.Text = "Unesite ime filma!";
                tbIme.Foreground = Brushes.LightBlue;
            }
        }

        private void tbTrajanje_LostFocus(object sender, RoutedEventArgs e)
        {
            if(tbTrajanje.Text.Trim().Equals(string.Empty))
            {
                tbTrajanje.Text = "Unesite duzinu filma u minutama!";
                tbTrajanje.Foreground = Brushes.LightBlue;
            }
        }

        private void tbTrajanje_GotFocus(object sender, RoutedEventArgs e)
        {
            if(tbTrajanje.Text.Trim().Equals("Unesite duzinu filma u minutama!"))
            {
                tbTrajanje.Text = "";
                tbTrajanje.Foreground = Brushes.Black;
            }
        }

        private void tbIme_GotFocus(object sender, RoutedEventArgs e)
        {
            if(tbIme.Text.Trim().Equals("Unesite ime filma!"))
            {
                tbIme.Text = "";
                tbIme.Foreground = Brushes.Black;
            }
        }

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            if(validate())
            {
                string opisRtf = "..\\..\\RTF\\" + tbIme.Text + ".rtf";

                TextRange tr = new TextRange(rtbOpis.Document.ContentStart, rtbOpis.Document.ContentEnd);
                FileStream fs = new FileStream(opisRtf, FileMode.Create);
                tr.Save(fs, DataFormats.Rtf);
                fs.Close();

                if(izmena == -1)
                    TabPrikaz.Komedije.Add(new Common.Komedija(tbIme.Text, Int32.Parse(tbTrajanje.Text),  slika, opisRtf, DateTime.Now));
                else
                    TabPrikaz.Komedije.Insert(izmena,new Common.Komedija(tbIme.Text, Int32.Parse(tbTrajanje.Text),  slika, opisRtf, kopija.DatumDodavanja));


                this.Close();
            }
            else
            {
                MessageBox.Show("Dodavanje ne uspesno. Morate odabrati sliku i popuniti sve informacije o filmu!", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
