string kärki = "a";
string perä = "b";
int pituus = 0;
string haluttupituus;

Console.WriteLine("Minkälainen kärki (puu, teräs, timantti) :");
while (kärki != "puu" || kärki != "teräs" || kärki != "timantti")
{
    kärki = Console.ReadLine();
    if (kärki == "puu" || kärki == "timantti" || kärki == "teräs")
    {
        break;
    }
}
Console.WriteLine("Minkälainen perä (lehti, kanansulka, kotkansulka) :");
while (perä != "lehti" || perä != "kanansulka" || perä != "kotkansulka")
{
    perä = Console.ReadLine();
    if (perä == "lehti" || perä == "kanansulka" || perä == "kotkansulka")
    {
        break;
    }
}
Console.WriteLine("Nuolen pituus (60-100cm) :");
while (pituus < 60 || pituus > 100)
{
    Console.WriteLine("Ollaan while-loopissa");

    haluttupituus = Console.ReadLine();
    if (int.TryParse(haluttupituus, out pituus) == true && pituus <= 100 && pituus >= 60)
    {
        Console.WriteLine("Ollaan if-lausessa");
        pituus = Convert.ToInt32(haluttupituus);
        break;
    }
}
Nuoli tilattuNuoli = new Nuoli(kärki, perä, pituus);
Console.WriteLine("Nuoli maksaa " + tilattuNuoli.PalautaHinta() + " kultaa");



public class Nuoli
{
    private string _karki;
    private string _pera;
    private double _pituus;
    private double nuolenhinta;

    public Nuoli(string karki, string pera, int pituus)
    {
        nuolenhinta = 0.0;
        _karki = karki;
        _pera = pera;
        _pituus = (double)pituus;
        if (_karki == "puu")
        {
            nuolenhinta += 3;
        }
        if (_karki == "teräs")
        {
            nuolenhinta += 5;
        }
        if (_karki == "timantti")
        {
            nuolenhinta += 50;
        }
        if (_pera == "kanansulka")
        {
            nuolenhinta += 1;
        }
        if (_pera == "kotkansulka")
        {
            nuolenhinta += 5;
        }
        nuolenhinta = nuolenhinta + (_pituus * 0.05);
        return;
    }

    public double PalautaHinta()
    {
        return nuolenhinta;
    }
    public string Kärki()
    {
        return _karki;
    }
    public string Perä()
    {
        return _pera;
    }
    public double Pituus()
    {
        return _pituus;
    }
}