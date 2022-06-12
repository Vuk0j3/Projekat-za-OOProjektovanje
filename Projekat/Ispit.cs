using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Projekat
{
    class Ispit
    {
        //Atributi
        private String naziv;
        private String strategija;
        private double procProlaz;
        private double maxpoena;
        private List<OstaliElementi> ostali;
        //Konstruktori
        public Ispit()
        {
            naziv = "";
            strategija = "";
            procProlaz = 0;
            maxpoena = 0;
            ostali =new List<OstaliElementi>();
        }
        public Ispit(String naziv, String strategija, double procProlaz, double maxpoena)
        {
            if (procProlaz <= 100 && procProlaz >= 0)
            {
                this.naziv = naziv;
                this.strategija = strategija;
                this.procProlaz = procProlaz;
                this.maxpoena = maxpoena;
                ostali = new List<OstaliElementi>();
            }
            else
                Console.WriteLine("Procenat za polaganje ispita mora biti u opsegu od 0 do 100! ");
        }

        //Property
        public String Naziv { get { return this.naziv; } set { this.naziv = value; } }
        public String Strategija { get { return this.strategija; } set { this.strategija = value; } }
        public double ProcProlaz { get { return this.procProlaz; } set { this.procProlaz = value; } }
        public double MaxPoena { get { return this.maxpoena; } set { this.maxpoena = value; } }
        public List<OstaliElementi> Ostali { get { return this.ostali; } set { this.ostali = value; } }

        //Metode
        public void DodajElement(OstaliElementi el)
        {
            ostali.Add(el);
        }
         
        public double UsmeniMinPoena()
        {
            return (procProlaz / 100) * maxpoena;
        }

    }
}
