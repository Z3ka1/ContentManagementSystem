using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Komedija
    {
        private string ime;
        private int trajanje;
        private string opis;
        private string slika;
        private string rtfRef;

        public string Ime { get => ime; set => ime = value; }
        public int Trajanje { get => trajanje; set => trajanje = value; }
        public string Slika { get => slika; set => slika = value; }
        public string Opis { get => opis; set => opis = value; }

        public Komedija()
        {

        }

        public Komedija(string ime, int trajanje, string opis, string slika, string rtfRef)
        {
            this.ime = ime;
            this.trajanje = trajanje;
            this.opis = opis;
            this.slika = slika;
            this.rtfRef = rtfRef;
        }


    }
}
