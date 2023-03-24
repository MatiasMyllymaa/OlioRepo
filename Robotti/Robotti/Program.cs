﻿public abstract class RobottiKäsky
{
    public abstract void Suorita(Robotti robotti);
}

public class Käynnistä : RobottiKäsky
{
    public override void Suorita(Robotti robotti)
    {
        robotti.OnKäynnissä = true;
    }
}

public class Sammuta : RobottiKäsky
{
    public override void Suorita(Robotti robotti)
    {
        robotti.OnKäynnissä = false;
    }
}

public class YlösKäsky : RobottiKäsky
{
    public override void Suorita(Robotti robotti)
    {
        if (robotti.OnKäynnissä)
        {
            robotti.Y += 1;
        }
    }
}

public class AlasKäsky : RobottiKäsky
{
    public override void Suorita(Robotti robotti)
    {
        if (robotti.OnKäynnissä)
        {
            robotti.Y -= 1;
        }
    }
}

public class VasenKäsky : RobottiKäsky
{
    public override void Suorita(Robotti robotti)
    {
        if (robotti.OnKäynnissä)
        {
            robotti.X -= 1;
        }
    }
}

public class OikeaKäsky : RobottiKäsky
{
    public override void Suorita(Robotti robotti)
    {
        if (robotti.OnKäynnissä)
        {
            robotti.X += 1;
        }
    }
}

public class Robotti
{
    public int X { get; set; }
    public int Y { get; set; }
    public bool OnKäynnissä { get; set; }
    public RobottiKäsky?[] Käskyt { get; } = new RobottiKäsky?[3];

    public void Suorita()
    {
        foreach (RobottiKäsky? käsky in Käskyt)
        {
            käsky?.Suorita(this);
            Console.WriteLine($"[{X} {Y} {OnKäynnissä}]");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Robotti robotti = new Robotti();

        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine("Anna käsky (käynnistä, sammuta, ylös, alas, vasen, oikea):");
            string syöte = Console.ReadLine();

            switch (syöte.ToLower())
            {
                case "käynnistä":
                    robotti.Käskyt[i] = new Käynnistä();
                    break;
                case "sammuta":
                    robotti.Käskyt[i] = new Sammuta();
                    break;
                case "ylös":
                    robotti.Käskyt[i] = new YlösKäsky();
                    break;
                case "alas":
                    robotti.Käskyt[i] = new AlasKäsky();
                    break;
                case "vasen":
                    robotti.Käskyt[i] = new VasenKäsky();
                    break;
                case "oikea":
                    robotti.Käskyt[i] = new OikeaKäsky();
                    break;
                default:
                    Console.WriteLine("Tuntematon käsky, yritä uudelleen.");
                    i--;
                    break;
            }
        }
        robotti.Suorita();
    }
}