using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodluyoruzTelefonRehberi
{
   public class Presentation_Layer
    {
        public static int sayac=2;
        DataLayer data = new DataLayer();
        BusinessLogicLayer isKatmani = new BusinessLogicLayer();
        public static int secim;
        public void RehberFonksiyonlariniGoruntule()
        {
            while (true)
            {

                try
                {
                    RehberListesiGetir();
                    secim = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception)
                {

                    Console.WriteLine("Lütfen sayısal uyugun  bir değer giriniz");
                    RehberFonksiyonlariniGoruntule();
                  
                }
                 
                if (secim == 1)
                {
                    Console.WriteLine("Rehber Kayıt Ekleme ");
                    Console.WriteLine("*********************");
                    YeniKayitEkle();
                  
                }
                else if (secim == 2)
                {

                    Console.WriteLine("Rehber Kayıt Silme");
                    RehberKayitSil();
                    

                }
                else if (secim == 3)
                {
                    Console.WriteLine("Rehber Kayıt Güncelleme");
                    RehberKayitGuncelle();
                }
                else if (secim == 4)
                {
                    Console.WriteLine("Rehber Listesi");
                    Console.WriteLine("**************");
                    RehberListesi();
                }
                else if (secim == 5)
                {
                    Console.WriteLine("Rehberde Kişi Arama");
                    RehberKayitArama();
                }
                else
                {
                    Console.WriteLine("Lütfen uygun aralıkta bir seçim yapınız");
                }
                Console.WriteLine("-------------------------------------");
                Console.WriteLine("Yeni işlem yapmak için (ENTER)'a basınız ");
                Console.ReadLine();

            }
          
        }
        public void RehberKayitArama()
        {
            Console.WriteLine("Lütfen arama yapmak istediğiniz tipi giriniz");
            Console.WriteLine("********************************************");
            Console.WriteLine("İsim ya da soyisime göre arama yapmak için (1)");
            Console.WriteLine("Telefon numarasına göre arama yapmak için (2) seçiniz!!!");
            int secim=Convert.ToInt32( Console.ReadLine());
            if (secim==1)
            {
                İsimSoyisimAra();
            }
            else if (secim==2)
            {
                TelefonNumarasiIleAra();
            }
        }
        public void İsimSoyisimAra()
        {
            Console.WriteLine("Lütfen görüntülemek istediğiniz isim ya da soyismi giriniz");
            string IsimSoyisim = Console.ReadLine();
            isKatmani.RehberKayitBul(IsimSoyisim);
        }
        public void TelefonNumarasiIleAra()
        {
            Console.WriteLine("Lütfen görüntülemek istediğiniz telefon numarasını giriniz.");
            string telefon = Console.ReadLine();
            isKatmani.RehberKayitBulTelefon(telefon);
        }
        public void RehberKayitGuncelle()
        {
            Console.Write("Lütfen güncellemek istediğiniz kaydın adını giriniz: ");
            string adi = Console.ReadLine();
            Console.Write("Lütfen güncellemek istediğiniz kaydın soyadını giriniz: ");
            string soyadi = Console.ReadLine();
            int sonuc=  isKatmani.GuncellenecekKayitBul(adi, soyadi);
            if (sonuc==1)
            {
                Console.WriteLine("Lütfen güncel ismi giriniz: ");
                string isim= Console.ReadLine();
                Console.WriteLine("Lütfen güncel soyismi giriniz: ");
                string soyisim = Console.ReadLine();
                Console.WriteLine("Lütfen güncel telefon numarasını giriniz: ");
                string telefonNo = Console.ReadLine();
                int sonuc2 = isKatmani.GuncelKisiBilgileri(isim, soyisim, telefonNo);
                if (sonuc2==1)
                {
                    Console.WriteLine("Kayıt güncelleme başarılı");
                }
                else
                {
                    Console.WriteLine("Kayıt güncelleme başarısız!!!");
                }
            }
            else
            {
                Console.WriteLine("Aradığınız kriterlere uygun veri rehberde bulunamadı. Lütfen seçim yapınız. ");
                git:
                Console.WriteLine("* Güncellemeyi sonlandırmak için: (1)");
                Console.WriteLine("* Yenieden denemek için         : (2)");
                string secim = Console.ReadLine();
                bool kontrol= isKatmani.SayiMi(secim);
                if (kontrol)
                {
                    if (Convert.ToInt32(secim)==1)
                    {

                    }
                    else if(Convert.ToInt32(secim) == 2)
                    {
                        Console.WriteLine("Yeniden deneyiniz: ");
                        goto git;
                    }
                }
                else
                {
                    Console.WriteLine("Lütfen doğru sayıyı giriniz...");
                }

            }
        }
        public void RehberListesiGetir()
        {
            Console.WriteLine("Lütfen yapmak istediniz işlemi şeçiniz:)");
            Console.WriteLine("***************************************");
            Console.WriteLine("(1) Yeni numara kaydetmek ");
            Console.WriteLine("(2) Varolan numarayı silmek");
            Console.WriteLine("(3) Varolan numarayı güncelle ");
            Console.WriteLine("(4) Rehberi listelemek");
            Console.WriteLine("(5) Rehberde arama yapmak");
        }
        public void Secim(int _secim)
        {
           
        }
        public void RehberListesi()
        {
            data.RehberListesiGetir();
        }
        public void RehberKayitSil()
        {
            Console.WriteLine("Lütfen numarasını silmek istediğiniz kişinin adını yada soyadını giriniz");
            string input = Console.ReadLine();
            int sonuc= isKatmani.RehberKayitNumaraSil(input, input);
            if (sonuc==1)
            {
                Console.WriteLine(input + " isimli kişi rehberden silinmek üzere, onaylıyor musunuz?(Y/N)");
                string secim=Console.ReadLine();
                if (secim=="y")
                {
                    Console.WriteLine("Silme işlemi başarılı");
                }
                else
                {
                    Console.WriteLine("Silme işlemi başarısız...");
                }
            }
            else
            {
                Console.WriteLine("Aradığınız kritere uygun rehberde kayıt bulunamadı. Devam etmek için lütfen seçim yapınız. ");
                Console.WriteLine("* Silmeyi sonlandırmak için: (1)");
                Console.WriteLine("* Yeniden denemek için     : (2)");
                git:

                string secim = Console.ReadLine();
                bool kontrol=  isKatmani.SayiMi(secim);
                if (kontrol)
                {
                    if (Convert.ToInt32(secim) == 1)
                    {

                    }
                    else if (Convert.ToInt32(secim) == 2)
                    {
                        RehberKayitSil();
                    }
                    else
                    {
                        Console.WriteLine("Lütfen uygun bir değer giriniz");
                        goto git;
                    }
                }
                else
                {
                    Console.WriteLine("Lütfen sayısal ve doğru değer giriniz..");
                    goto git;
                }
            }
        }
      
        public void YeniKayitEkle()
        {
        
            Console.Write("Lütfen isim giriniz: ");
            string isim = Console.ReadLine();
            Console.Write("Lütfen soyisim giriniz: ");
            string soyisim=Console.ReadLine();
            Console.Write("Lütfen telefon numaranızı giriniz: ");
            string telefonNo = Console.ReadLine();

            
                int sonuc= isKatmani.YeniNumaraKaydet(sayac, isim, soyisim, telefonNo);
                if (sonuc==1 )
                {
                    Console.WriteLine("Rehbere yeni kayıt ekleme başarılı");
                sayac++;
                }
                else
                {
                    Console.WriteLine("Yeni kayıt ekleme işlemi başarısız");
                }        
        }
    }
}
