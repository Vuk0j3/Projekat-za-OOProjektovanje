using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

namespace Projekat
{
    class Kolekcija
    {
        //Atributi
        private List<Ispit> ispiti;
        private List<Strategija> strategije;
        //Konstruktor
        public Kolekcija()
        {
            ispiti = new List<Ispit>();
            strategije = new List<Strategija>();

            /*Dugacak kod dole, inicijalizacija tabele date u zadatku, 
            da uvek postoje predmeti iz tabele, kad god se kreira nova kolekcija
            takodje da bi postojale i osnovne strategije A i B
            */
            Strategija A = new Strategija("A", 55, 65, 75, 85, 95);
            Strategija B = new Strategija("B", 50, 65, 80, 90, 98);
            strategije.Add(A);
            strategije.Add(B);

            Ispit OOP = new Ispit("OO Projektovanje", "A", 50, 48);
            OstaliElementi PismeniOOP = new OstaliElementi("Pismeni", 50, 32);
            OstaliElementi LabOOp = new OstaliElementi("Lab", 20);
            OOP.DodajElement(PismeniOOP);
            OOP.DodajElement(LabOOp);
            ispiti.Add(OOP);

            Ispit Geodezija = new Ispit("Geodezija", "A", 50, 40);
            OstaliElementi Projekat_a = new OstaliElementi("Projekat a", 60, 10);
            OstaliElementi Projekat_b = new OstaliElementi("Projekat b", 80, 10);
            OstaliElementi LabGeodezija = new OstaliElementi("Lab", 40, 20);
            OstaliElementi TerenskiZadatak = new OstaliElementi("Terenski Zadatak", 40, 20);
            Geodezija.DodajElement(Projekat_a);
            Geodezija.DodajElement(Projekat_b);
            Geodezija.DodajElement(LabGeodezija);
            Geodezija.DodajElement(TerenskiZadatak);
            ispiti.Add(Geodezija);

            Ispit IstorijaStarogVeka = new Ispit("Istorija starog veka", "A", 60, 80);
            OstaliElementi Istrazivanje = new OstaliElementi("Istrazivanje", 35, 20);
            IstorijaStarogVeka.DodajElement(Istrazivanje);
            ispiti.Add(IstorijaStarogVeka);

            Ispit Farmakologija = new Ispit("Farmakologija", "B", 80, 20);
            OstaliElementi Test_A = new OstaliElementi("Test A", 60, 25);
            OstaliElementi Test_B = new OstaliElementi("Test B", 60, 25);
            OstaliElementi Lab1 = new OstaliElementi("Lab 1", 10);
            OstaliElementi Lab2 = new OstaliElementi("Lab 2", 20, 10);
            OstaliElementi Lab3 = new OstaliElementi("Lab 3", 50, 10);
            Farmakologija.DodajElement(Test_A);
            Farmakologija.DodajElement(Test_B);
            Farmakologija.DodajElement(Lab1);
            Farmakologija.DodajElement(Lab2);
            Farmakologija.DodajElement(Lab3);
            ispiti.Add(Farmakologija);

            Ispit MMS = new Ispit("MMS", "B", 50, 40);
            OstaliElementi SW_Projekat = new OstaliElementi("SW Projekat", 30);
            OstaliElementi MM_Projekat = new OstaliElementi("MM Projekat", 50, 30);
            MMS.DodajElement(SW_Projekat);
            MMS.DodajElement(MM_Projekat);
            ispiti.Add(MMS);

            Ispit RimskoPravo = new Ispit("Rimsko pravo", "B", 55, 100);
            ispiti.Add(RimskoPravo);
        }

        //Property
        public List<Ispit> Ispiti { get { return this.ispiti; } set { this.ispiti = value; } }
        public List<Strategija> Strategije { get { return this.strategije; } set { this.strategije = value; } }

        //Metode
        public void DodajStrategiju(Strategija st)//Funkcija za dodavanje strategije u listu strategija kolekcije
        {
            strategije.Add(st);
        }
        public void DodajIspit(Ispit isp)//Funkcija za dodavanje ispita u listu ispita kolekcije
        {
            ispiti.Add(isp);
        }

        public void ProcitajStudente(String Data)
        {
            int brojka = 0;
            int brojac = 1;
            using (StreamReader sr = new StreamReader(new FileStream(Data, FileMode.Open)))
            {
                string sx = "nesto";
                while (sx!=null)
                {
                    brojka++;
                    sx = sr.ReadLine();
                } 
            }
            int brInd;
            int i = 0; //Brojac koji broji elemente liste ispiti
            int str = 0;//Brojac koji broji elemente liste strategije
            bool Polozio = true; // Za ispitivanje da li je student polozio ispit
            double uk = 0;
            using (StreamReader sr = new StreamReader(new FileStream(Data, FileMode.Open)))
            {
                if (!File.Exists("Rezultati.txt"))
                    File.Create("Rezultati.txt");
                while (brojac < brojka)
                {
                    brInd = Convert.ToInt32(sr.ReadLine());
                    brojac++;
                    string imePredmeta = sr.ReadLine(); //Ucitavanje imena predmeta iz fajla
                    brojac++;
                    for (int l = 0; l < ispiti.Count; l++)
                    {
                        if (ispiti[l].Naziv == imePredmeta) // Ako je ucitano ime predmeta == sa imenom nekog predmeta iz liste ispiti, vraca se njegov indeks i
                            i = l;
                    }
                    double poeni = Convert.ToDouble(sr.ReadLine());
                    brojac++;
                    uk = poeni;
                    for (int l = 0; l < strategije.Count; l++)
                    {
                        if (ispiti[i].Strategija == strategije[l].Naziv) // Isto kao za imePredmeta, samo za strategiju
                            str = l;
                    }
                    if (ispiti[i].Ostali.Count > 0)
                    {
                        foreach (OstaliElementi el in ispiti[i].Ostali) //za onoliko elemenata u nizu Ostalih Elemenata iz Klase Ispiti, ucitavamo Naziv i bodove
                        {
                            string imeElementa = sr.ReadLine();
                            brojac++;
                            double elBodovi = Convert.ToDouble(sr.ReadLine());
                            brojac++;
                            uk += elBodovi; //Racunanje koliko student ima ukupno bodova;
                            if (elBodovi < el.ProlazniPoeni()) //Ako student u tom delu ostalih elemenata ima manje od prolaznih poena, on pada >.<
                                Polozio = false;
                        }
                    }
                    if (poeni < ispiti[i].UsmeniMinPoena()) //Ako student ima manje od potrebnih poena na usmenom za prolaz, isto pada :(
                        Polozio = false;
                    if (Polozio)
                    {
                        //Printovanje resenja u konzolu
                        Console.WriteLine("Student: " + brInd + " je polozio "+ispiti[i].Naziv+ " i ima " + uk + " poena. Ocena: " + strategije[str].IzracunajOcenu(uk));
                        //Printovanje resenja u fajl
                        using (StreamWriter sw=new StreamWriter(new FileStream("Rezultati.txt", FileMode.Append)))
                        {
                            sw.WriteLine("Student: " + brInd + " je polozio " + ispiti[i].Naziv + " i ima " + uk + " poena. Ocena: " + strategije[str].IzracunajOcenu(uk));
                        }
                    }
                    else
                    {
                        Console.WriteLine("Student: " + brInd + " je pao "+ ispiti[i].Naziv + " i ima " + uk + " poena.");//Printovanje resenja u konzolu
                        using (StreamWriter sw = new StreamWriter(new FileStream("Rezultati.txt", FileMode.Append)))
                        {
                            sw.WriteLine("Student: " + brInd + " je pao " + ispiti[i].Naziv + " i ima " + uk + " poena.");//Printovanje resenja u fajl
                        }
                    }
                    Polozio = true;
                }
                using (StreamWriter sw = new StreamWriter(new FileStream("Rezultati.txt", FileMode.Append)))
                {
                    sw.WriteLine();
                }
            }
        }

        public void ProcitajStrategije(String Data) //Funkcija za citanje strategija iz prosledjene destinacije fajla.
            //Moguce je procitati vise strategija
        {
            string line;
            using (StreamReader sr = new StreamReader(new FileStream(Data, FileMode.Open)))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    string[] words = line.Split(',');
                    DodajStrategiju(new Strategija(words[0].Trim(), Convert.ToDouble(words[1]), Convert.ToDouble(words[2]), Convert.ToDouble(words[3]), Convert.ToDouble(words[4]), Convert.ToDouble(words[5])));
                    Console.WriteLine("Upisana je nova strategija: "+strategije[Strategije.Count-1].Naziv+" Sest: "+ strategije[Strategije.Count-1].Sest +
                        "% Sedam: " + strategije[Strategije.Count-1].Sedam + "% Osam: " + strategije[Strategije.Count-1].Osam + "% Devet: " + strategije[Strategije.Count-1].Devet + "% Deset: " + strategije[Strategije.Count-1].Deset+"%. ");
                }
            }
        }
        public void ProcitajPredmete(String Data)   //Funkcija za citanje predmeta iz proslednjene destinacije fajla.
        {
            string line;
            int j = 0;
            using (StreamReader sr = new StreamReader(new FileStream(Data, FileMode.Open))) //Za citanje iz fajla koristio sam StreamReader
            {
                String Y = "";//Y odredjuje da li postoje i minimalni poeni za polaganje dodatnog dela ispita
                String X = "";//X odredjuje da li postoji samo maksimalni broj poena, bez uzlova za polaganje
                //X i Y su potrebni jer klasa OstaliElementi ima 2 Konstruktora. Jedan sa poenima potrebnim za prolaz a drugi bez.
                int parametri = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] words = line.Split(',');
                    DodajIspit(new Ispit(words[0].Trim(), words[1].Trim(), Convert.ToDouble(words[2]), Convert.ToDouble(words[3])));
                    Console.WriteLine("Upisan je novi Predmet: " + ispiti[ispiti.Count - 1].Naziv + " Strategija: " +
                        ispiti[ispiti.Count - 1].Strategija + " Minimalni procenat za polaganje usmenog: " + ispiti[ispiti.Count - 1].ProcProlaz + "% od ukupno: " + ispiti[ispiti.Count - 1].MaxPoena);
                    int i = 4;
                    while (i<words.Length)
                    {
                        if (words[i] != null)
                        {
                            if (i + 2 < words.Length)
                                Y = words[i + 2].Trim().Substring(0, 1);
                             if (i + 1 < words.Length)
                                X = words[i + 1].Trim().Substring(0, 1);
                            if (Y == "0" || Y == "1" || Y == "2" || Y == "3" || Y == "4" || Y == "5" || Y == "6" || Y == "7" || Y == "8" || Y == "9")
                                parametri = 2;
                            else if (X == "0" || X == "1" || X == "2" || X == "3" || X == "4" || X == "5" || X == "6" || X == "7" || X == "8" || X == "9")
                                parametri = 1;
                        }
                        if (parametri == 2)
                        {
                            Console.WriteLine("Dodat je nov element " + words[i] + " " + words[i + 1] +" "+ words[i+2]);
                            ispiti[ispiti.Count - 1].DodajElement(new OstaliElementi(words[i], Convert.ToDouble(words[i + 1]), Convert.ToDouble(words[i + 2])));
                            i += 3; //Prelazak na sledeci dodatni element ispita.
                        }
                        else if (parametri == 1)
                        {
                            ispiti[ispiti.Count - 1].DodajElement(new OstaliElementi(words[i], Convert.ToDouble(words[i + 1])));
                            Console.WriteLine("Dodat je nov element "+words[i]+" "+words[i+1]);
                            i += 2; //Prelazak na sledeci dodatni element ispita.
                        }
                        else
                            Console.WriteLine("Nije moguce dodavanje ovog elementa" + words[5]); 
                        //Ukoliko je u fajlu nepravilno definisan npr broj poena za prolaz, ova linija koda ne prekida kod, vec samo to ispisuje u konzoli.
                        //(Uslov u zadatku da se kod ne prekida).
                        parametri = 0;
                        X = "";
                        Y = "";
                    }
                }
            }
        }
        public void IzmeniStrategijuSvima(string s)
        {
            bool flag = false;
            foreach (Strategija strategija in strategije)
            {
                if (strategija.Naziv == s)//Ukoliko postoji strategija sa ovim imenom, podesava flag na true
                    flag = true;
            }
            if (flag)//Ako je flag true, izmenice strategije svih predmeta
                foreach (Ispit ispit in ispiti)
                {
                    ispit.Strategija = s;
                    Console.WriteLine("Predmetu: " + ispit.Naziv + " je izmenjena strategija u " + s);
                }
            else
                Console.WriteLine("Ne postoji strategija " + s);//Ukoliko prosledjeno ime strategije ne postoji u listi strategija, ispisace to na ekranu
        }
        public void OcistiFajl(string Data)
        {
            File.WriteAllText(Data, "");
        }
    }
}