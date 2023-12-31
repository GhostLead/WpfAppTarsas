﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppTarsas
{
    public class Osveny
    {
        static int aktSorszam;
        List<char> mezok = new List<char>();
        int sorszam;

        public Osveny(String sor)
        {
            this.mezok = sor.ToCharArray().ToList();
            aktSorszam++;
            this.sorszam = aktSorszam;
        }
        public int Hossz => this.mezok.Count;
        public int Sorszama => this.sorszam;

        public List<char> Mezok { get => mezok; }

        public int GetJelekSzama(char v)
        {
            return mezok.Count(x => x == v);
        }

        public bool Tartalmaz(char v)
        {
            return mezok.Contains(v);
        }

        public List<string> GetKulonlegesek()
        {
            List<string> kulonlegesek = new List<string>();
            for (int i = 0; i < mezok.Count; i++)
            {
                if (mezok[i] == 'E' || mezok[i] == 'V')
                {
                    kulonlegesek.Add(i + 1 + "\t" + mezok[i]);
                }
            }
            return kulonlegesek;
        }

        internal Osveny Fordit()
        {
            throw new NotImplementedException();
        }
    }
}