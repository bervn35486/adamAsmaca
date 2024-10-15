using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Oyun için kullanılacak kelimeler
        string[] kelimeler = { "programlama", "geliştirme", "csharp", "oyun", "yazılım" };
        Random rastgele = new Random();

        // Rastgele bir kelime seç
        string kelime = kelimeler[rastgele.Next(kelimeler.Length)];

        // Tahmin edilen harfler için bir dizi oluştur
        char[] tahminEdilenHarfler = new char[kelime.Length];
        for (int i = 0; i < kelime.Length; i++)
        {
            tahminEdilenHarfler[i] = '_'; // Başlangıçta harfler gizli
        }

        int can = 7; // Başlangıç can sayısını 7 yap
        HashSet<char> yanlisTahminler = new HashSet<char>(); // Yanlış tahminleri saklamak için

        // Oyun döngüsü
        while (can > 0 && new string(tahminEdilenHarfler) != kelime)
        {
            // Mevcut durumu göster
            Console.WriteLine("Kelime: " + new string(tahminEdilenHarfler));
            Console.WriteLine("Kalan can: " + can);
            Console.WriteLine("Yanlış tahminler: " + string.Join(", ", yanlisTahminler));
            Console.Write("Bir harf tahmin edin: ");
            char tahmin = Console.ReadLine()[0]; // Kullanıcıdan harf al

            // Tahmin edilen harf kelimede var mı kontrol et
            if (kelime.Contains(tahmin))
            {
                // Doğru tahmin
                for (int i = 0; i < kelime.Length; i++)
                {
                    if (kelime[i] == tahmin)
                    {
                        tahminEdilenHarfler[i] = tahmin; // Harfi açığa çıkar
                    }
                }
            }
            else
            {
                // Yanlış tahmin
                if (!yanlisTahminler.Contains(tahmin))
                {
                    yanlisTahminler.Add(tahmin); // Yanlış tahminleri ekle
                    can--; // Canı azalt
                }
                else
                {
                    Console.WriteLine("Bu harfi zaten tahmin ettiniz."); // Aynı harfi tekrar tahmin etmemesi için
                }
            }

            Console.Clear(); // Ekranı temizle
        }

        // Oyun bitiş durumu
        if (new string(tahminEdilenHarfler) == kelime)
        {
            Console.WriteLine("Tebrikler! Kelimeyi doğru tahmin ettiniz: " + kelime);
        }
        else
        {
            Console.WriteLine("Kaybettiniz! Doğru kelime: " + kelime);
        }
    }
}
