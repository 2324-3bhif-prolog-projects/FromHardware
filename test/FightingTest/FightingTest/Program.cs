namespace FightingTest;

public class Program
{
    public static void Main(string[] args)
    {
        List<int> targetPosition = new List<int> { 1, 2 };
        Ability veraSpada = new Ability("Vera Spada", "Ein schneller Hieb mit einer geweihten Klinge. (Moderater Schaden)", targetPosition, (11,18), AbilityType.Attack, 0);
        Ability gewissenserweckung = new Ability("Gewissenserweckung", "Mit einem Ausruf göttlicher Erkenntnis zwingt Dante den Gegner, sich seiner Schuld zu stellen. (Weniger Schaden + Stress)",  targetPosition, (6,10), AbilityType.Attack,  20);
        Ability gebetDerKlarheit = new Ability("Gebet der Klarheit", "Ein ruhiges Gebet stärkt Dantes Geist. (leichte Hilung)", targetPosition, (3,9), AbilityType.Heal, 0, BuffType.Hp);
        Ability klarerBlick = new Ability("Klarer Blick", "Dante schließt kurz die Augen, richtet seinen Geist – und öffnet sie mit tödlicher Entschlossenheit. (Erhöht die Wahrscheinlichkeit von Angriffen)", targetPosition, (4, 5), AbilityType.Buff, 0, BuffType.Accuracy);
        List<Ability> abilitiesPlayer = new List<Ability> { veraSpada,  gewissenserweckung, gebetDerKlarheit, klarerBlick};
        Character Player = new Character("Dante", 100, 11, 1, abilitiesPlayer, CharacterType.Player);
        int richterSpruchDamage = (int)(7 + (35 - 5) * ((double)Player.HP / Player.MaxHP));
        Ability richterSpruch = new Ability("Richterspruch", "Minos zeigt mit seiner Klauenhand auf einen Gegner – ein unsichtbares Gewicht lastet auf ihm. (Mehr schaden bei Voller HP)", targetPosition, (richterSpruchDamage, richterSpruchDamage), AbilityType.Attack, 0);
        Ability zungenurteil = new Ability("Zungenurteil", "Aus seinem Maul fährt eine peitschende, schwarze Zunge. (Stress + wenig Schaden)", targetPosition, (4, 7), AbilityType.Attack, 11);
        Ability richtHammer = new Ability("Richthammer", "Minos schwingt mit seinem Richterhammer. (Moderater Schaden)", targetPosition, (8, 11), AbilityType.Attack, 0);
        List<Ability> abilitiesMinos = new List<Ability> { richterSpruch, zungenurteil, richtHammer };
        Character Minos = new Character("Minos", 200, 13, 1, abilitiesMinos, CharacterType.Boss);
        Console.WriteLine("Du stehst Minos gegenüber. Seine Ketten rasseln. Er rollt sich auf dich zu.");
        Console.ReadKey(true);
        Console.WriteLine();
        Console.WriteLine();
        int initPlayer = Ability.Roll(1,21);
        int initEnemy = Ability.Roll(1,21);
        int order = 0;
        if (initPlayer > initEnemy)
        {
            order = 1;
        }
        else
        {
            order = 2;
        }
        
        Console.WriteLine($"Du bist als {order}. an der Reihe.");
        Console.WriteLine();
        bool isFinished = false;
        PhraseManager phraseMgr = new PhraseManager();
        if (order == 2)
        {
            MinosAttack(Minos, Player);
        }
        do
        {
            try
            {
                if (Player.HP > 0)
                {
                    if (Player.Stress >= 100)
                    {
                        Console.WriteLine("Dantes Atem geht flach, Schweiß glänzt auf seiner Stirn. Die Schatten in seinem Blick tanzen wild – Gedanken an Hoffnung schwinden.");
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Ein Urteil naht.");
                        Console.ResetColor();
                        Console.WriteLine();
                        Console.ReadKey(true);
                        Player.StressOut();
                        Console.ReadKey(true);
                    }
                    Console.WriteLine();
                    Console.WriteLine(
                        $"[Deine Position: {Player.Position} | HP: {Player.HP}/{Player.MaxHP} | Stress: {Player.Stress}]");
                    Console.WriteLine();
                    Console.WriteLine("Was willst du tun?");
                    for (int i = 0; i < Player.Abilities.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {Player.Abilities[i].Name}");
                    }

                    Console.WriteLine($"{Player.Abilities.Count() + 1}. Spell Informations");
                    Console.WriteLine();
                    int playerInput = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine();
                    if (playerInput == Player.Abilities.Count() + 1)
                    {
                        for (int i = 0; i < Player.Abilities.Count; i++)
                        {
                            Console.WriteLine(
                                $"{i + 1}. {Player.Abilities[i].Name}: {Player.Abilities[i].Description}");
                        }

                        Console.WriteLine();
                    }
                    else
                    {
                        if (playerInput == 3 || playerInput == 4)
                        {
                            Player.Abilities[playerInput - 1]
                                .Use(Player, Player, Player.Abilities[playerInput - 1].Type, true);
                        }
                        else
                        {
                            Player.Abilities[playerInput - 1]
                                .Use(Player, Minos, Player.Abilities[playerInput - 1].Type, true);
                        }

                        if (Minos.HP > 0)
                        {
                            if (Minos.Stress >= 100)
                            {
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine("Ein Zittern geht durch den gewaltigen Leib des Richters.");
                                Console.WriteLine("Der Zorn, der ihn jahrtausendelang antrieb, flackert – nur für einen Moment – und bricht.");
                                Console.WriteLine("Minos’ Atem geht stoßweise, der Blick flackert. Die Stimmen der Verdammten hallen in seinem Kopf, lauter als je zuvor.");
                                Console.WriteLine("„Ich... kann nicht mehr unterscheiden… schuldlos, schuldig… sie schreien alle.“");
                                Console.WriteLine("Die Ketten, die andere banden, schlingen sich nun um sein Herz.");
                                Console.WriteLine();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Ein Urteil naht.");
                                Console.ResetColor();
                                Console.WriteLine();
                                Console.ReadKey(true);
                                Minos.StressOut();
                                Console.ReadKey(true);
                            }
                            MinosAttack(Minos, Player);
                        }
                        else
                        {
                            isFinished = true;
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine(
                                "Du reißt dein Schwert durch seine schuppige Kehle – schwarzes Blut spritzt, und Minos stürzt röchelnd zu Boden.");
                            Console.ReadKey();
                            Console.WriteLine(
                                "Sein Blut vermischt sich mit der Glut des Kreises. So endet seine Herrschaft.");
                            Console.ResetColor();
                        }
                    }
                }
                else
                {
                    isFinished = true;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Du bist jetzt auf 0 HP.");
                    Console.WriteLine("Du hast leider Verloren!");
                }
            }
            catch(Exception)
            {
                Console.WriteLine($"Please enter a number that is not zero and under {Player.Abilities.Count()}!");
            }
        } while (!isFinished);
        
        Console.WriteLine("ENDE");
    }

    public static void MinosAttack(Character Minos, Character Player)
    {
        int getAttack = Ability.Roll(1, Minos.Abilities.Count());
        int damage = 0;
        int stress = 0;
        
        Console.Write($"{Minos.Name} erhebt sich und setzt {Minos.Abilities[getAttack].Name} ein -");
        
        int attackRoll = Ability.Roll(1, 21);
        if (attackRoll >= Player.ArmorClass)
        {
            damage = Ability.Roll(Minos.Abilities[getAttack].PowerRange.min, Minos.Abilities[getAttack].PowerRange.max);
            stress = Minos.Abilities[getAttack].StressEffect;

            Player.HP -= damage;
            Player.Stress += stress;

            Console.Write($" Du erleidest {damage} Schaden, Stress +{stress}");
        }
        else
        {
            Console.WriteLine(" Er verfehlt.");
        }
        Console.WriteLine();
    }
}