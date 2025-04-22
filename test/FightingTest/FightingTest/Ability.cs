using System.Diagnostics;

namespace FightingTest;

public class Ability
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public List<int> TargetPositions { get; private set; } 
    public (int min, int max) PowerRange { get; private set; }
    public AbilityType Type { get; private set; }
    public BuffType TypeBuff { get; private set; }
    public int StressEffect { get; private set; }

    public Ability(string name, string description,  List<int> targetPositions, (int, int) powerRange, AbilityType type,  int stressEffect, BuffType buffType)
    {
        Name = name;
        Description = description;
        TargetPositions = targetPositions;
        PowerRange = powerRange;
        Type = type;
        StressEffect = stressEffect;
        TypeBuff = buffType;
    }
    public Ability(string name, string description,  List<int> targetPositions, (int, int) powerRange, AbilityType type,  int stressEffect)
    {
        Name = name;
        Description = description;
        TargetPositions = targetPositions;
        PowerRange = powerRange;
        Type = type;
        StressEffect = stressEffect;
    }

    public void Use(Character user, Character target, AbilityType type)
    {
        int attackRollRaw = Roll(1, 21);
        int attackRoll = attackRollRaw + user.Accuracy;
        PhraseManager phraseMgr = new PhraseManager();
        if (type == AbilityType.Attack)
        {
            if (attackRoll >= target.ArmorClass)
            {
                double damage = Roll(PowerRange.min, PowerRange.max);

                if (attackRollRaw == 20)
                {
                    damage *= 1.5;
                    Console.WriteLine("Dein Angriff verursacht kritischen Schaden!");
                }
                target.HP -= (int)damage;
                target.Stress += StressEffect;

                Console.WriteLine($"[Würfelergebnis: {attackRollRaw} + {user.Accuracy} (Treffer)] – Minos erleidet {damage} Schaden.");
                Console.WriteLine();
                if(target.HP > 0 && target.Type == CharacterType.Boss)
                {
                    Console.WriteLine(phraseMgr.GetHPPhrase(target.HP, target.MaxHP));
                }
                else if(target.HP > 0)
                {
                    Console.WriteLine($"Der Gegner hat noch {target.HP} von {target.MaxHP} HP.");
                }
            }
            else
            {
                Console.WriteLine($"[Würfelergebnis: {attackRollRaw} + {user.Accuracy} (Verfehlt)] – Du schwingst dein Schwert knapp an ihn vorbei.");
            }
            Console.WriteLine();
        }
        else if (type == AbilityType.Heal)
        {
            int power = Roll(PowerRange.min, PowerRange.max);

            user.HP += power;
            Console.WriteLine($"Du betest und erhältst {power} HP wieder.");
        }
        else if (type == AbilityType.Buff)
        {
            int power = Roll(PowerRange.min, PowerRange.max);

            if (TypeBuff == BuffType.Accuracy)
            {
                user.Accuracy += 5;
                Console.WriteLine("Dante fokussiert seinen Geist. Kein Zweifel, kein Zögern. Nur Ziel und Wille.");
            }
        }
    }
    public static int Roll(int min, int max)
    {
        Random rnd = new Random();
        return rnd.Next(min, max);
    }
}