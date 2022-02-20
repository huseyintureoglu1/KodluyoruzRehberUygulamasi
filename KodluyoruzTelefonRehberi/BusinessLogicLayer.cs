using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodluyoruzTelefonRehberi
{
   public class BusinessLogicLayer
    {
        Entities_Telephone bulunanKayit;
        DataLayer data = new DataLayer();
        public bool SayiMi(string deger)
        {
            foreach (char item in deger)
            {
                if (!Char.IsNumber(item)){
                    return false;
                } 
            }
            return true;
        }
        public int RehberKayitBulTelefon(string _telefon)
        {
            int sonuc = 0;
            try
            {
             sonuc=data.RehberKayitTelefonAra(_telefon);
            
            }
            catch (Exception)
            {


            }
            return sonuc;
        }
        public int RehberKayitBul(string isimSoyisim)
        {
            int sonuc = 0;
            try
            {
              sonuc= data.RehberKayitAra(isimSoyisim, isimSoyisim);
              
            }
            catch (Exception)
            {

             
            }
            return sonuc;
        }
        public int GuncellenecekKayitBul(string _isim, string _soyisim)
        {
            int sonuc = 0;
            try
            {
             bulunanKayit=DataLayer.rehber.Find(i => i.Isim == _isim && i.Soyisim == _soyisim);
                if (bulunanKayit!=null)
                {
                    sonuc = 1;
                }
                
            }
            catch (Exception)
            {

                throw;
            }
            return sonuc;
        }
        public int GuncelKisiBilgileri(string _isim,string _soyisim,string _telefonNo)
        {
            int sonuc = 1;
            bulunanKayit.Isim = _isim;
            bulunanKayit.Soyisim = _soyisim;
            bulunanKayit.TelefonNumarasi = _telefonNo;
            return sonuc;
        }
        public int YeniNumaraKaydet(int _id, string _isim, string _soyisim, string _telefonNo)
        {
            int sonuc = 0;
            try
            {
                Entities_Telephone kisi = new Entities_Telephone();
                kisi.ID = _id;
                kisi.Isim = _isim;
                kisi.Soyisim = _soyisim;
                kisi.TelefonNumarasi = _telefonNo;
                data.YeniKayitEkle(kisi);
                sonuc = 1;

            }
            catch (Exception)
            {

                Console.WriteLine("Hatalı işlem yaptınız");
            }
            return sonuc;
        }
        public int RehberKayitNumaraSil(string _isim, string _soyisim)
        {
            int sonuc = 0;
            try
            {

                Entities_Telephone bulunanKayit=DataLayer.rehber.Find(i => i.Isim == _isim||i.Soyisim==_soyisim);
                if (bulunanKayit!=null)
                {
                    data.RehberKayitSil(bulunanKayit);// önemli
                    sonuc = 1;
                }
                else
                {
                   
                }

            }
            catch (Exception)
            {

            }
            return sonuc;
        }
       
    }
}
