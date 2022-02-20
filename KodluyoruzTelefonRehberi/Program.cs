using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodluyoruzTelefonRehberi
{
    class Program
    {
        static void Main(string[] args)
        {
            Presentation_Layer presentation = new Presentation_Layer();
            presentation.RehberFonksiyonlariniGoruntule();
            presentation.Secim(Presentation_Layer.secim);
            presentation.RehberKayitGuncelle();
            presentation.RehberKayitArama();
            Console.ReadLine();
        }
    }
}
