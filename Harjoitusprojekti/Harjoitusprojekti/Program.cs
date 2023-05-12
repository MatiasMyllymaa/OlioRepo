using System;

namespace Harjoitusprojekti
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Tervetuloa ritaripeliin!");

            
            Player player = new Player();


            Enemy enemy;

            while (true)
            {
                
                Console.WriteLine();
                Console.WriteLine($"Tämä on päävalikko");
                Console.WriteLine($"Valitse mitä haluat tehdä");

                
                Console.WriteLine("Mitä aiot tehdä?");
                Console.WriteLine("1. Kauppa");
                Console.WriteLine("2. Örkki");
                Console.WriteLine("3. Ritari");
                Console.WriteLine("4. Lohikäärme");
                Console.Write("Valinta: ");

                int choice = int.Parse(Console.ReadLine());

                

                if (choice == 1)
                {
                    Console.WriteLine();
                    Console.WriteLine($"Tämä on Kauppa");
                    Console.WriteLine($"Pelaajan Kulta: {player.Money}");
                    Console.WriteLine($"Valitse mitä haluat tehdä");

                    
                    Console.WriteLine("Mitä aiot tehdä?");
                    Console.WriteLine("1. Armori (5 gold) (+5 hp)");
                    Console.WriteLine("2. Kyrpärä (5 gold) (+5 hp)");
                    Console.WriteLine("3. Heltti pottu (5 gold) (kun käytetty taistelussa lisää +20hp)");
                    Console.WriteLine("4. Miekkaan +1 dmg (5 gold)");
                    Console.WriteLine("5. Takaisin");
                    Console.Write("Valinta: ");
                    int valinta = int.Parse(Console.ReadLine());
                    if (player.Money < 5)
                    {
                        Console.WriteLine("sinulla ei ole varaa siihen");
                    }
                    else
                    {
                        if (valinta == 1)
                        {
                            Console.WriteLine("Ostit armorin ja sait 5 hp enemmän (-5 gold)");
                            player.Health += 5;
                            player.Money -= 5;
                        }
                        if (valinta == 2)
                        {
                            Console.WriteLine("Ostit kypärän ja sait 5 hp enemmpän (-5 gold)");
                            player.Health += 5;
                            player.Money -= 5;
                        }
                        if (valinta == 3)
                        {
                            Console.WriteLine("Ostit heltti potun ja käytit 5 kultaa");
                            player.pottu++;
                            player.Money -= 5;
                        }
                        if (valinta == 4)
                        {
                            Console.WriteLine("Ostit parannetun miekan ja sait +1 dmg (-5 gold)");
                            player.AttackDamage++;
                            player.Money -= 5;
                        }
                    }
                    
                    if (valinta == 5)
                    {
                        continue;
                    }
                }


                


                if (choice == 2)
                {
                    enemy = new Enemy("Örkki", 50, 5, false);
                    while (!enemy.IsDefeated)
                    {
                        
                        Console.WriteLine();
                        Console.WriteLine($"Pelaajan heltti: {player.Health}");
                        Console.WriteLine($"Örkin heltti: {enemy.Health}");

                        
                        Console.WriteLine("Mitä aiot tehdä?");
                        Console.WriteLine("1. Hyökkää");
                        Console.WriteLine("2. Käytä abilitysi");
                        Console.WriteLine($"3. Käytä heltti pottu (pottujen määrä : {player.pottu})");
                        Console.WriteLine("4. lähe pakoon");
                        Console.Write("Valinta: ");

                        int val = int.Parse(Console.ReadLine());

                        
                        switch (val)
                        {
                            case 1:
                                player.Attack(enemy);
                                break;
                            case 2:
                                player.UseAbility(enemy);
                                break;
                            case 3:
                                {
                                    if (player.pottu > 0)
                                    {
                                        player.Health += 20;
                                        player.pottu--;
                                    }
                                    if (player.pottu <= 0)
                                    {
                                        Console.WriteLine("Sinulla ei ole heltti pottuja");
                                    }
                                    break;
                                }
                            case 4:
                                Console.WriteLine("Lähdit pakoon taistelusta!");
                                return;
                            default:
                                Console.WriteLine("ei toimi!");
                                break;
                        }

                        
                        if (enemy.IsDefeated)
                        {
                            Console.WriteLine("Tapoit Örkki!");
                            player.Money += 5;
                            player.Health += 50;
                            break;
                        }

                        
                        enemy.Attack(player);

                        
                        if (player.IsDefeated())
                        {
                            Console.WriteLine("Örkki tappoi sinut!");
                            return;
                        }
                    }
                }
                if (choice == 3)
                {
                    enemy = new Enemy("Ritari", 80, 10, false);
                    while (!enemy.IsDefeated)
                    {
                        
                        Console.WriteLine();
                        Console.WriteLine($"Pelaajan heltti: {player.Health}");
                        Console.WriteLine($"Ritarin heltti: {enemy.Health}");

                        
                        Console.WriteLine("Mitä aiot tehdä?");
                        Console.WriteLine("1. Hyökkää");
                        Console.WriteLine("2. Käytä abilitysi");
                        Console.WriteLine($"3. Käytä heltti pottu (pottujen määrä : {player.pottu})");
                        Console.WriteLine("4. lähe pakoon");
                        Console.Write("Valinta: ");

                        int val = int.Parse(Console.ReadLine());

                        
                        switch (val)
                        {
                            case 1:
                                player.Attack(enemy);
                                break;
                            case 2:
                                player.UseAbility(enemy);
                                break;
                            case 3:
                                {
                                    if (player.pottu > 0)
                                    {
                                        player.Health += 20;
                                    }
                                    if (player.pottu <= 0)
                                    {
                                        Console.WriteLine("Sinulla ei ole heltti pottuja");
                                    }
                                    break;
                                }
                            case 4:
                                Console.WriteLine("Lähdit pakoon taistelusta!");
                                return;
                            default:
                                Console.WriteLine("ei toimi!");
                                break;
                        }

                        
                        if (enemy.IsDefeated)
                        {
                            Console.WriteLine("Tapoit Ritarin!");
                            player.Money += 10;
                            player.Health += 50;
                            break;
                        }

                        
                        enemy.Attack(player);

                        
                        if (player.IsDefeated())
                        {
                            Console.WriteLine("Ritari tappoi sinut!");
                            continue;
                        }
                    }
                }
                if (choice == 4)
                {
                    enemy = new Enemy("Lohikäärme", 150, 15, true);
                    while (!enemy.IsDefeated)
                    {
                        
                        Console.WriteLine();
                        Console.WriteLine($"Pelaajan heltti: {player.Health}");
                        Console.WriteLine($"Lohikäärmeen heltti: {enemy.Health}");

                        
                        Console.WriteLine("Mitä aiot tehdä?");
                        Console.WriteLine("1. Hyökkää");
                        Console.WriteLine("2. Käytä abilitysi");
                        Console.WriteLine($"3. Käytä heltti pottu (pottujen määrä : {player.pottu})");
                        Console.WriteLine("4. lähe pakoon");
                        Console.Write("Valinta: ");

                        int val = int.Parse(Console.ReadLine());

                        
                        switch (val)
                        {
                            case 1:
                                player.Attack(enemy);
                                break;
                            case 2:
                                enemy.IsWeakToAbility = true;

                                player.UseAbility(enemy);
                                break;
                            case 3:
                                {
                                    if (player.pottu > 0)
                                    {
                                        player.Health += 20;
                                    }
                                    if (player.pottu <= 0)
                                    {
                                        Console.WriteLine("Sinulla ei ole heltti pottuja");
                                    }
                                    break;
                                }
                            case 4:
                                Console.WriteLine("Lähdit pakoon taistelusta!");
                                return;
                            default:
                                Console.WriteLine("ei toimi!");
                                break;
                        }

                        
                        if (enemy.IsDefeated)
                        {
                            Console.WriteLine("Tapoit Lohikäärmeen!");
                            player.Money += 20;
                            player.Health += 100;
                            break;
                        }

                        
                        enemy.Attack(player);
                        if (player.IsDefeated())
                        {
                            Console.WriteLine("Lohikäärme tappoi sinut!");
                            continue;
                        }
                    }
                }
            }    
        }
    }
}