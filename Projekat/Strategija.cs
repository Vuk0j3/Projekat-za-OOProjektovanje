using System;
using System.Collections.Generic;
using System.Text;

namespace Projekat
{
    class Strategija
    {
        //Atributi
        private String naziv;
        private double sest;
        private double sedam;
        private double osam;
        private double devet;
        private double deset;

        //Konstruktori
        public Strategija()
        {
            this.naziv = "";
            this.sest = 0;
            this.sedam = 0;
            this.osam = 0;
            this.devet = 0;
            this.deset = 0;
        }
        public Strategija(String naziv, double sest, double sedam, double osam, double devet, double deset)
        {
            this.naziv = naziv;
            this.sest = sest;
            this.sedam = sedam;
            this.osam = osam;
            this.devet = devet;
            this.deset = deset;
        }
        public Strategija(Strategija st)
        {
            this.naziv = st.Naziv;
            this.sest = st.Sest;
            this.sedam = st.Sedam;
            this.osam = st.Osam;
            this.devet = st.Devet;
            this.deset = st.Deset;
        }
        //Property
        public String Naziv { get { return this.naziv; } set { this.naziv = value; } }
        public double Sest { get { return this.sest; } set { this.sest = value; } }
        public double Sedam { get { return this.sedam; } set { this.sedam = value; } }
        public double Osam { get { return this.osam; } set { this.osam = value; } }
        public double Devet { get { return this.devet; } set { this.devet = value; } }
        public double Deset { get { return this.deset; } set { this.deset = value; } }

        //Metode
        public int IzracunajOcenu(double poeni)
        {
            if (poeni >= Deset)
                return 10;
            else if (poeni >= Devet)
                return 9;
            else if (poeni >= Osam)
                return 8;
            else if (poeni >= Sedam)
                return 7;
            else if (poeni >= Sest)
                return 6;
            else 
                return 5;
        }
    }
}
