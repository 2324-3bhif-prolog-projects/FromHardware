namespace FightingTest;

public class Program
{
    public static void Main(string[] args)
    {
        List<int> usableFrom = new List<int> { 1, 2 };
        List<int> targetPosition = new List<int> { 1, 2 };
        Ability slash = new Ability("Slash", usableFrom, targetPosition, (8, 10), 0);
        Ability throw_ = new Ability("Throw", usableFrom, targetPosition, (4,6), 10);
        List<Ability> abilities = new List<Ability> { slash,  throw_ };
        Character Player = new Character("Dante", 100, 12, 1, abilities);
        Character Minos = new Character("Minos", 100, 13, 1, abilities);
        Console.WriteLine("Du stehst Minos gegenüber. Seine Ketten rasseln. Er rollt sich auf dich zu.");
        Console.ReadKey();
        int initPlayer = Roll(1,21);
        int initEnemy = Roll(1,21);
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
        bool isFinished = false;
        int attackRoll = 0;
        int damage = 0;
        int stress = 0;
        do
        {
            try
            {
                if(Player.HP > 0) {
                Console.WriteLine($"[Deine Position: {Player.Position} | HP: {Player.HP}/{Player.MaxHP} | Stress: {Player.Stress}]");
                Console.WriteLine("Was willst du tun?");
                Console.WriteLine($"1. {Player.Abilities[0].Name}");
                Console.WriteLine($"2. {Player.Abilities[1].Name}");
                Console.WriteLine("3. Spell Informations");
                int playerInput = Convert.ToInt32(Console.ReadLine());
                if (playerInput == 3)
                {
                    Console.WriteLine("1. bla bla");
                    Console.WriteLine("2. bla bla");
                }
                else 
                {
                    attackRoll = Roll(1, 21);
                    if (attackRoll >= Minos.ArmorClass)
                    {
                        if (playerInput == 1)
                        {
                            damage = Roll(Player.Abilities[0].DamageRange.min, Player.Abilities[0].DamageRange.max);
                            stress = Player.Abilities[0].StressEffect;
                        }
                        else
                        {
                            damage = Roll(Player.Abilities[1].DamageRange.min, Player.Abilities[1].DamageRange.max);
                            stress = Player.Abilities[1].StressEffect;
                        }
                        Minos.HP = Minos.HP - damage;
                        Minos.Stress += stress;
                        
                        Console.WriteLine($"[Würfelergebnis: {attackRoll} (Treffer)] – Minos erleidet {damage} Schaden.");
                        Console.WriteLine($"Er hat jetzt {Minos.HP} HP");
                    }
                    else
                    {
                        Console.WriteLine($"[Würfelergebnis: {attackRoll} (Verfehlt)] - Minos ist deinem Angriff ausgewichen.");
                    }
                    
                    if (Minos.HP > 0)
                    {
                        int getAttack = Roll(1, 3);
                        if (getAttack == 1)
                        {
                            Console.Write($"{Minos.Name} schlägt zurück mit „{Minos.Abilities[0].Name}“!");
                        }
                        else
                        {
                            Console.Write($"{Minos.Name} schlägt zurück mit „{Minos.Abilities[1].Name}“!");
                        }

                        attackRoll = Roll(1, 21);
                        stress = 0;
                        if (attackRoll >= Player.ArmorClass)
                        {
                            if (getAttack == 1)
                            {
                                damage = Roll(Minos.Abilities[0].DamageRange.min, Minos.Abilities[0].DamageRange.max);
                                stress = Minos.Abilities[0].StressEffect;
                            }
                            else
                            {
                                damage = Roll(Minos.Abilities[1].DamageRange.min, Minos.Abilities[1].DamageRange.max);
                                stress = Minos.Abilities[1].StressEffect;
                            }
                            Player.HP -= damage;
                            Player.Stress += stress;

                            Console.Write($" Du erleidest {damage} Schaden, Stress +{stress}");
                            Console.WriteLine();
                        }
                        else
                        {
                            Console.WriteLine(" Er verfehlt.");
                        }
                    }
                    else
                    {
                        isFinished = true;
                        Console.WriteLine("Du hast ihn besiegt!");
                    }
                }
                }
                else
                {
                    isFinished = true;
                    Console.WriteLine("Du hast leider Verloren!");
                }
            }
            catch(Exception)
            {
                Console.WriteLine("Please enter a number!");
            }
        } while (!isFinished);
        
        Console.WriteLine("ENDE");
    }
    
    public static int Roll(int min, int max)
    {
        Random rnd = new Random();
        return rnd.Next(min, max);
    }
}