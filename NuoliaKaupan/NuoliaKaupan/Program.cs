string kärki = "a";
string perä = "b";
int pituus = 0;
string haluttupituus;
string pre;

Console.WriteLine("Teetkö valmiin nuolen vai oman? (v = valmis, o = oma)");
while (true)
{
    pre = Console.ReadLine();
    if (pre == "v" || pre == "o")
    {
        break;
    }
}

Nuoli tilattuNuoli;
if (pre == "v")
{
    Console.WriteLine("Valitse nuolen tyyppi (1 = Heikkonuoli, 2 = perusnuoli, 3 = hyvänuoli)");
    while (true)
    {
        string valittuNuoli = Console.ReadLine();
        if (valittuNuoli == "1")
        {
            tilattuNuoli = Nuoli.LuoAloittelijanuoli();
            Console.WriteLine("Nuolessa on puu kärki, kanansulka perä sekä se on 70cm pitkä");
            break;
        }
        else if (valittuNuoli == "2")
        {
            tilattuNuoli = Nuoli.LuoPerusnuoli();
            Console.WriteLine("Nuolessa on teräs kärki, kanansulka perä sekä se on 85cm pitkä");
            break;
        }
        else if (valittuNuoli == "3")
        {
            tilattuNuoli = Nuoli.LuoEliittiNuoli();
            Console.WriteLine("Nuolessa on timantti kärki, kotkansulka perä sekä se on 100cm pitkä");
            break;
        }
    }
}
else
{
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
        if (int.TryParse(haluttupituus, out pituus) == true && pituus < 100 && pituus > 60)
        {
            break;
        }
    }
    tilattuNuoli = new Nuoli(kärki, perä, pituus);
}

Console.WriteLine("Nuoli maksaa " + tilattuNuoli.PalautaHinta + " kultaa");

public class Nuoli
{
    private string _karki;
    private string _pera;
    private double _pituus;
    private double nuolenhinta;

    public Nuoli(string karki, string pera, int pituus)
    {
        _karki = karki;
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
        nuolenhinta = nuolenhinta + _pituus * 0.05;
        return;
    }
    public static Nuoli LuoEliittiNuoli()
    {
        return new Nuoli("timantti", "kotkansulka", 100);
    }
    public static Nuoli LuoAloittelijanuoli()
    {
        return new Nuoli("puu", "kanansulka", 70);
    }
    public static Nuoli LuoPerusnuoli()
    {
        return new Nuoli("teräs", "kanansulka", 85);
    }

    public double PalautaHinta
    {
        get { return nuolenhinta; }
        set { nuolenhinta = value; }
    }
    public string Karki
    {
        get { return _karki; }
        set { _karki = value; }
    }
    public string Pera
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
