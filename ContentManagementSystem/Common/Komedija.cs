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
        private DateTime datumDodavanja;

        public string Ime { get => ime; set => ime = value; }
        public int Trajanje { get => trajanje; set => trajanje = value; }
        public string Slika { get => slika; set => slika = value; }
        public string Opis { get => opis; set => opis = value; }
        public DateTime DatumDodavanja { get => datumDodavanja; set => datumDodavanja = value; }

        public Komedija()
        {

        }

        public Komedija(string ime, int trajanje, string opis, string slika, string rtfRef, DateTime datumDodavanja)
        {
            this.ime = ime;
            this.trajanje = trajanje;
            this.opis = opis;
            this.slika = slika;
            this.rtfRef = rtfRef;
            this.datumDodavanja = datumDodavanja;
        }

        public Komedija(Komedija komedija)
        {
            this.ime = komedija.ime;
            this.trajanje = komedija.trajanje;
            this.opis = komedija.opis;
            this.slika = komedija.slika;
            this.rtfRef = komedija.rtfRef;
            this.datumDodavanja = komedija.datumDodavanja;
        }
    }
}
