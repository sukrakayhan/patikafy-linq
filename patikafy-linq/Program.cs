using System;
using System.Collections.Generic;
using System.Linq;

public class Sanatci
{
    public string AdSoyad { get; set; }
    public string MuzikTuru { get; set; }
    public int CikisYili { get; set; }
    public int AlbumSatislari { get; set; }
}

public class Program
{
    public static void Main()
    {
        List<Sanatci> sanatcilar = new List<Sanatci>
        {
            new Sanatci { AdSoyad = "Ajda Pekkan", MuzikTuru = "Pop", CikisYili = 1968, AlbumSatislari = 20 },
            new Sanatci { AdSoyad = "Sezen Aksu", MuzikTuru = "Türk Halk Müziği / Pop", CikisYili = 1971, AlbumSatislari = 10 },
            new Sanatci { AdSoyad = "Funda Arar", MuzikTuru = "Pop", CikisYili = 1999, AlbumSatislari = 3 },
            new Sanatci { AdSoyad = "Sertab Erener", MuzikTuru = "Pop", CikisYili = 1994, AlbumSatislari = 5 },
            new Sanatci { AdSoyad = "Sıla", MuzikTuru = "Pop", CikisYili = 2009, AlbumSatislari = 3 },
            new Sanatci { AdSoyad = "Serdar Ortaç", MuzikTuru = "Pop", CikisYili = 1994, AlbumSatislari = 10 },
            new Sanatci { AdSoyad = "Tarkan", MuzikTuru = "Pop", CikisYili = 1992, AlbumSatislari = 40 },
            new Sanatci { AdSoyad = "Hande Yener", MuzikTuru = "Pop", CikisYili = 1999, AlbumSatislari = 7 },
            new Sanatci { AdSoyad = "Hadise", MuzikTuru = "Pop", CikisYili = 2005, AlbumSatislari = 5 },
            new Sanatci { AdSoyad = "Gülben Ergen", MuzikTuru = "Pop / Türk Halk Müziği", CikisYili = 1997, AlbumSatislari = 10 },
            new Sanatci { AdSoyad = "Neşet Ertaş", MuzikTuru = "Türk Halk Müziği / Türk Sanat Müziği", CikisYili = 1960, AlbumSatislari = 2 }
        };

        var sIleBaslayanlar = sanatcilar.Where(s => s.AdSoyad.StartsWith("S"));
        var onMilyonUzeriSatanlar = sanatcilar.Where(s => s.AlbumSatislari > 10);

        // 2000 yılı öncesi çıkmış ve pop müzik yapan sanatçılar
        var ikiBinOnceCikanPopcilar = from s in sanatcilar
                                      where s.CikisYili < 2000 && s.MuzikTuru.Contains("Pop")
                                      orderby s.AdSoyad // Alfabetik sıraya göre sıralama yapılıyor
                                      select s;

        var enCokSatan = sanatcilar.OrderByDescending(s => s.AlbumSatislari).FirstOrDefault();
        var enYeniCikan = sanatcilar.OrderByDescending(s => s.CikisYili).FirstOrDefault();
        var enEskiCikan = sanatcilar.OrderBy(s => s.CikisYili).FirstOrDefault();

        Console.WriteLine("Adı S ile başlayan şarkıcılar:");
        foreach (var s in sIleBaslayanlar)
        {
            Console.WriteLine(s.AdSoyad);
        }

        Console.WriteLine("\nAlbüm satışları 10 milyonun üzerinde olan şarkıcılar:");
        foreach (var s in onMilyonUzeriSatanlar)
        {
            Console.WriteLine(s.AdSoyad);
        }

        Console.WriteLine("\n2000 yılı öncesi çıkmış ve pop müzik yapan şarkıcılar (alfabetik sırada):");
        foreach (var s in ikiBinOnceCikanPopcilar)
        {
            Console.WriteLine(s.AdSoyad);
        }

        Console.WriteLine($"\nEn çok albüm satan şarkıcı: {enCokSatan?.AdSoyad}");
        Console.WriteLine($"\nEn yeni çıkış yapan şarkıcı: {enYeniCikan?.AdSoyad}");
        Console.WriteLine($"\nEn eski çıkış yapan şarkıcı: {enEskiCikan?.AdSoyad}");
    }
}
