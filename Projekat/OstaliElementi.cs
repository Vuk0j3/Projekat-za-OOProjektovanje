using System;
using System.Collections.Generic;
using System.Text;

namespace Projekat
{
    class OstaliElementi
    {
        //Atributi
        private String naziv;
        private double uslov; //Uslov za polaganje ovog dela ispita u procentima
        private double maxPoena;

        //Konstruktori
        public OstaliElementi()
        {
            naziv = "";
            uslov = 0;
            maxPoena = 0;
        }
        public OstaliElementi(String naziv, double uslov, double maxPoena)
        {
            if (uslov <= 100 && uslov >= 0)
            {
                this.naziv = naziv;
                this.uslov = uslov;
                this.maxPoena = maxPoena;
            }
            else Console.WriteLine("Uslov mora biti u opsegu od 0 do 100! ");
        }
        public OstaliElementi(String naziv, double maxPoena)
        {
            this.naziv = naziv;
            uslov = 0;
            this.maxPoena = maxPoena;
        }

        //Property
        public String Naziv { get { return this.naziv; } set { this.naziv = value; } }
        public double Uslov { get { return this.uslov; } set { this.uslov = value; } }
        public double MaxPoena { get { return this.maxPoena; } set{ this.maxPoena = value; } }

        //Metode
        public double ProlazniPoeni()
        {
            return maxPoena * (uslov / 100);
        }
    }
}
