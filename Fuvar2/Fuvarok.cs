using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fuvar2
{
    class Fuvarok
    {
        int azonosito;
        string indulas;
        int idotartam;
        double megtettTavolsag;
        double viteldij;
        double borravalo;
        string fizetesModja;

        public int Azonosito { get => azonosito; set => azonosito = value; }
        public string Indulas { get => indulas; set => indulas = value; }
        public int Idotartam { get => idotartam; set => idotartam = value; }
        public double MegtettTavolsag { get => megtettTavolsag; set => megtettTavolsag = value; }
        public double Viteldij { get => viteldij; set => viteldij = value; }
        public double Borravalo { get => borravalo; set => borravalo = value; }
        public string FizetesModja { get => fizetesModja; set => fizetesModja = value; }

        public Fuvarok(string sor)
        {
            string[] adatok = sor.Split(';');
            Azonosito = int.Parse(adatok[0]);
            Indulas = adatok[1];
            Idotartam = int.Parse(adatok[2]);
            MegtettTavolsag = double.Parse(adatok[3]);
            Viteldij = double.Parse(adatok[4]);
            Borravalo = double.Parse(adatok[5]);
            FizetesModja = adatok[6];
        }
    }
}
