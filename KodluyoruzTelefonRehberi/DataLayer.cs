using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodluyoruzTelefonRehberi
{
    public class DataLayer
    {
        public static List<Entities_Telephone> rehber;
        List<Entities_Telephone> bulunanKisiler = new List<Entities_Telephone>();
        public DataLayer()
        {
            rehber = new List<Entities_Telephone>();
            Entities_Telephone kisi1 = new Entities_Telephone();
            kisi1.ID = 0;
            kisi1.Isim = "Hüseyin";
            kisi1.Soyisim = "Türeoğlu";
            kisi1.TelefonNumarasi = "88888";
            rehber.Add(kisi1);
            Entities_Telephone kisi2 = new Entities_Telephone();
            kisi2.ID = 1;
            kisi2.Isim = "Oguzhan";
            kisi2.Soyisim = "Koç";
            kisi2.TelefonNumarasi = "3333333";
            rehber.Add(kisi2);

        }
        public int RehberKayitTelefonAra(string _telefon)
        {
            int sonuc = 0;
            try
            {
              
                Entities_Telephone bulunanKullanici = rehber.Find(i => i.TelefonNumarasi == _telefon);
                if (bulunanKullanici!=null)
                {
                    Console.WriteLine("Bulanan Kişi: " + bulunanKullanici.Isim + " " + bulunanKullanici.Soyisim + " " + bulunanKullanici.TelefonNumarasi);
                    sonuc = 1;
                }
               

            }
            catch (Exception)
            {

               
            }
            return sonuc;
        }
        public int RehberKayitAra(string _isim,string _soyisim)
        {
            int sonuc = 0;
            try
            {
                 sonuc=  ListedeKayitBul(_isim, _soyisim);
                foreach (Entities_Telephone item in bulunanKisiler)
                {
                    Console.WriteLine("İsim: "+item.Isim.ToString());
                    Console.WriteLine("Soyisim: " + item.Soyisim.ToString());
                    Console.WriteLine("Telefon Numarası: " + item.TelefonNumarasi.ToString());
                    Console.WriteLine("-");
                }
                
                //Entities_Telephone bulunanKayit = rehber.Find(i => i.Isim == _isim || i.Soyisim == _soyisim);
                //if (bulunanKayit!=null)
                //{
                //    Console.WriteLine("Bulunan Kullanıcı: "+bulunanKayit.Isim + " " + bulunanKayit.Soyisim+" " +bulunanKayit.TelefonNumarasi);
                //    sonuc = 1;
                //}
                //else
                //{

                //}
            }
            catch (Exception)
            {

              
            }
            return sonuc;
        }
        public int  ListedeKayitBul(string isim, string soyisim)
        {
            int sonuc = 0;
            foreach (Entities_Telephone item in rehber)
            {
                if (item.Isim==isim|| item.Soyisim==soyisim)
                {
                    bulunanKisiler.Add(item);
                    sonuc = 1;
                }
                
            }
            return sonuc;
        }
        public int RehberKayitSil(Entities_Telephone kayit)
        {
            int sonuc = 0;
            try
            {
                rehber.Remove(kayit);//önemli
                sonuc = 1;
            }
            catch (Exception)
            {

            }
            return sonuc;
            

        }
        public int YeniKayitEkle(Entities_Telephone kisi)
        {
            int sonuc = 0;
            try
            {
                rehber.Add(kisi);
                sonuc = 1;
            }
            catch (Exception)
            {

                Console.WriteLine("Hatalı işelem yaptınız.");
            }
            return sonuc;
        }
        public int RehberListesiGetir()
        {
            int sonuc = 1;
            foreach (var item in rehber)
            {
                Console.WriteLine("ID:"+item.ID+" ");
                Console.WriteLine("İsim:"+item.Isim + " ");
                Console.WriteLine("Soyisim: "+item.Soyisim + " ");
                Console.WriteLine("Telefon Numarası"+item.TelefonNumarasi + " ");
                Console.WriteLine("-");
                
                
            }
            return sonuc;
        }
    }
}
