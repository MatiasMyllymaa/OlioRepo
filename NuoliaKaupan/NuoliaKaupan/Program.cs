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
    haluttupituus = Console.ReadLine();
    if (int.TryParse(haluttupituus, out pituus) == true && pituus <= 100 && pituus >= 60)
    {
        
        pituus = Convert.ToInt32(haluttupituus);
        break;
    }
}
Nuoli tilattuNuoli = new Nuoli(kärki, perä, pituus);
Console.WriteLine("Nuoli maksaa " + tilattuNuoli.PalautaHinta + " kultaa");



public class Nuoli
{
    private string _karki;
    private string _pera;
    private double _pituus;
    private double nuolenhinta;

    public Nuoli(string karki, string pera, int pituus)
    {
        _karki= karki;
        _pera = pera;
        _pituus = pituus;
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

    public double PalautaHinta
    {
        get { return nuolenhinta; }
        set { nuolenhinta = value; }
    }
    public string Kärki
    {
        get { return _karki; }
        set { _karki = value; }
    }
    public string Perä
    {
        get { return _pera; }
        set { _pera = value; }
    }
    public double Pituus
    {
        get { return _pituus; }
        set { _pituus = value; }
    }
}