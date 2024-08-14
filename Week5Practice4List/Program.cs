internal class Program
{
    public static void Main(string[] args)
    {
        List<Film> filmList = new List<Film>();             //Film türünde liste


        while (true)                                                        //Sınırsız sayıda film adı ve puan isteyecek
        {
            Console.WriteLine("Film adını giriniz: ");
            string filmName = Console.ReadLine();

            Console.WriteLine("Filmin ımdb puanını giriniz");
            double imdbPoint;
            while (!double.TryParse(Console.ReadLine(), out imdbPoint))     //puanın geçerliliği kontrol edildi
            {
                Console.Write("Geçersiz Lütfen bir sayı giriniz:  ");
            }

            filmList.Add(new Film(filmName, imdbPoint));        // Yeni bir film nesnesi oluşturup listenin içine ekle 

            Console.Write("Başka film eklemek istiyor musunuz? (E/H): ");
            if (Console.ReadLine().Trim().ToUpper() != "E")
                break;
        }

        Console.WriteLine("Tüm filmlerin listesi : ");
        foreach (Film film in filmList)                 //Bütün filmler listelendi
        {
            Console.WriteLine("Film ismi : " + film.FilmName + "Film IMDB puanı : " + film.IMDBPoint);
        }

        Console.WriteLine("Puanı 4 ile 9 arasındaki filmler : ");
        //var FilterList = filmList.Where(p => p.IMDBPoint >= 4 && p.IMDBPoint <= 9);           //9 ile 4 puan arasındaki filmler filtrelendi   / Bu yöntem LİNQ ile sorgu kurma yöntemi aşağıdaki gibi if ile de yapılabilir
        //foreach (Film film in FilterList)
        //{
        //    Console.WriteLine("Film ismi : " + film.FilmName + "Film IMDB puanı : " + film.IMDBPoint);
        //}


        foreach (Film film in filmList)
        {
            if (film.IMDBPoint >= 4 && film.IMDBPoint <= 9)
            {
                Console.WriteLine("Film ismi : " + film.FilmName + "Film IMDB puanı : " + film.IMDBPoint);
            }
        }



        Console.WriteLine("İsmi A ile başlayan filmler : ");
        var FilterListA = filmList.Where(f => f.FilmName.StartsWith("A", StringComparison.OrdinalIgnoreCase));            //Burada da LİNQ kullanılıldı a il başlayan filmler filtrelendi

        foreach (var film in FilterListA)
        {
            Console.WriteLine("Film ismi : " + film.FilmName + "Film IMDB puanı : " + film.IMDBPoint);
        }


    }




}

public class Film
{
    public Film(string filmName, double ımdbPoint)
    {
        FilmName = filmName;
        IMDBPoint = ımdbPoint;
    }



    public string FilmName { get; set; }
    public double IMDBPoint { get; set; }


}




