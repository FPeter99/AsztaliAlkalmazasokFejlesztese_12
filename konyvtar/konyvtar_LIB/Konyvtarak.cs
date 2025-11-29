using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace konyvtar_LIB
{
    public class Konyvtarak
    {
        List<Konyvtar> konyvtarak = new List<Konyvtar>();

        public Konyvtarak(IEnumerable<string> fajlSorok)
        {
            foreach (string fajlSor in fajlSorok.Skip(1))
            {
                string[] sor = fajlSor.Split(';');
                string cim = sor[0];
                string szerzo = sor[1];
                int kiadasEv = int.Parse(sor[2]);
                string kolcsonozheto = sor[3];

                konyvtarak.Add(new Konyvtar(cim, szerzo, kiadasEv, kolcsonozheto));
            }
        }



        public int Konyvek_szama => konyvtarak.Count();

        public int Kolcsonozheto => konyvtarak.Count(x => x.Kolcsonozheto);

        public int HarryPotter_szama => konyvtarak.Count(x => x.Cim.Contains("Harry Potter"));

        public IEnumerable<IGrouping<int, Konyvtar>> Legtobb_egy_evben => konyvtarak.GroupBy(x => x.KiadasEv).OrderByDescending(x => x.Count()).Take(1);

        public IEnumerable<IGrouping<int, Konyvtar>> Evenkenti_kiadasok => konyvtarak.GroupBy(x => x.KiadasEv);

        public IEnumerable<IGrouping<string, Konyvtar>> Szerzonkenti_kiadasok => konyvtarak.GroupBy(x => x.Szerzo).OrderBy(x => x.Key);

        public bool LetezoKonyv(string cim) => konyvtarak.Any(x => x.Cim == cim);

        public bool KolcsonozhetoKonyv(string cim) => konyvtarak.Any(x => x.Cim == cim && x.Kolcsonozheto);

        public List<string> Kolcsonozheto_konyvek => konyvtarak.Where(x => x.Kolcsonozheto).Select(x => x.Cim).Distinct().Order().ToList();
    }
}
