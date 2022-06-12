using System;

namespace Projekat
{
    class Program
    {
        static void Main(string[] args)
        {
            Kolekcija k = new Kolekcija();//Kreiranje kolekcije svih Studenata i predmeta, sve metode trazene u zadatku se mogu izvrsiti iz kolekcije.
            //Svi .txt fajlovi se nalaze u Projekat\bin\Debug\netcoreapp3.1
            
            k.ProcitajStrategije("Strategije.txt");
            k.ProcitajPredmete("Predmeti.txt");
            k.IzmeniStrategijuSvima("D"); //Strategija D je ucitana iz fajla Strategije.txt
            k.ProcitajStudente("Studenti.txt"); //Ocenjivanje studenata po strategiji
        }
    }
}
