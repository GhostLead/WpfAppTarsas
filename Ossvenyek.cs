using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppTarsas
{
    internal class Ossvenyek
    {
        string mezok;
        public Ossvenyek(string sor)
        {
            this.mezok = sor;
        }
        public string Mezok => this.mezok;
    }
}
