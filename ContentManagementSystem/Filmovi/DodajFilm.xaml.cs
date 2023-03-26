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

        string slika = "";
        public DodajFilm()
        {
            InitializeComponent();

            tbIme.Text = "Unesite ime filma!";
            tbIme.Foreground = Brushes.LightBlue;
            tbTrajanje.Text = "Unesite duzinu filma u minutama!";
            tbTrajanje.Foreground = Brushes.LightBlue;


            cmbFont.ItemsSource = Fonts.SystemFontFamilies.OrderBy(f => f.Source);
            cmbFontSize.ItemsSource = new List<double> { 10, 12, 14, 16, 18, 29, 22, 24, 26, 28, 30, 32, 34 };
            cmbFontColor.ItemsSource = new List<string> { "Black", "Blue", "Red" };

            cmbFontColor.SelectedIndex = 0;
            cmbFont.SelectedIndex = 2;
            cmbFontSize.SelectedIndex = 16;
            
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void btnIzlaz_Click(object sender, RoutedEventArgs e)
        {
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
                rtbOpis.Selection.ApplyPropertyValue(Inline.FontSizeProperty, cmbFontSize.SelectedValue);
        }

        private void cmbFontColor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbFontColor.SelectedItem != null && !rtbOpis.Selection.IsEmpty)
                rtbOpis.Selection.ApplyPropertyValue(Inline.ForegroundProperty, cmbFontColor.SelectedValue);
        }

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
            cmbFontSize.Text = temp.ToString();

            temp = rtbOpis.Selection.GetPropertyValue(Inline.ForegroundProperty);
            cmbFontColor.Text = temp.ToString();

        }

        private void rtbOpis_TextChanged(object sender, TextChangedEventArgs e)
        {
            string text = new TextRange(rtbOpis.Document.ContentStart, rtbOpis.Document.ContentEnd).Text;
            tbBrojac.Text = text.Split(' ').Count().ToString();
               
        }

        private void btnUmetni_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                slika = openFileDialog.FileName;
                Uri uri = new Uri(slika);
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
                string opisRtf = tbIme.Text + ".rtf";

                TextRange tr = new TextRange(rtbOpis.Document.ContentStart, rtbOpis.Document.ContentEnd);
                FileStream fs = new FileStream(opisRtf, FileMode.Create);
                tr.Save(fs, DataFormats.Rtf);
                fs.Close();

                TabPrikaz.Komedije.Add(new Common.Komedija(tbIme.Text, Int32.Parse(tbTrajanje.Text), tr.ToString(), slika, opisRtf, DateTime.Now));
                this.Close();
            }
            else
            {
                MessageBox.Show("Dodavanje ne uspesno. Morate popuniti sve informacije o filmu!", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
