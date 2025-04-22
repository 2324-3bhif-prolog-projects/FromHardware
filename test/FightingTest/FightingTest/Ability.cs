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

    public void Use(Character user, Character target, AbilityType type, bool isPlayer)
    {
        int attackRollRaw = Roll(1, 21);
        int attackRoll = attackRollRaw + user.Accuracy;
        PhraseManager phraseMgr = new PhraseManager();
        double power = Roll(PowerRange.min, PowerRange.max);
        if (type == AbilityType.Attack)
        {
            if (attackRoll >= target.ArmorClass)
            {
                if (attackRollRaw == 20)
                {
                    power *= 1.5;
                    Console.WriteLine("Dein Angriff verursacht kritischen Schaden!");
                }
                target.HP -= (int)power;
                target.Stress += StressEffect;

                Console.WriteLine($"[Würfelergebnis: {attackRollRaw} + {user.Accuracy} (Treffer)] – Minos erleidet {power} Schaden.");
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
            user.HP += (int)power;
            Console.WriteLine($"Du betest und erhältst {power} HP wieder.");
        }
        else if (type == AbilityType.Buff || type == AbilityType.Debuff)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            if (type == AbilityType.Debuff)
            {
                power *= -1;
                Console.ForegroundColor = ConsoleColor.DarkRed;
                if (!isPlayer)
                {
                    Console.WriteLine("Für einen Moment flackert etwas in seinen Augen – nicht Wut, sondern Zweifel. Seine gewaltige Gestalt bebt, als lasteten Jahrhunderte der Schuld auf seinen Schultern.");
                    Console.WriteLine("„Was… habe ich getan…?“");
                    Console.WriteLine("Die Kraft weicht aus seinem Griff, seine Stimme wird schwach. Der Richter beginnt zu wanken.");
                }
            }
            else
            {
                if (!isPlayer)
                {
                    Console.WriteLine("Minos’ Brust hebt sich, als ob ein Sturm in seinem Inneren tobt. Doch statt zu zerbrechen, richtet er sich auf – größer, furchteinflößender denn je.");
                    Console.WriteLine("„Eure Angst… nährt meine Macht.“");
                    Console.WriteLine("Die Ketten um seinen Geist zerreißen – was bleibt, ist pures Zornfeuer.");
                    Console.WriteLine("Minos entfesselt seinen Zorn.");
                }
            }
            switch (TypeBuff)
            {
                case BuffType.Accuracy:
                    target.Accuracy += (int)power;
                    break;
                case BuffType.Hp:
                    target.MaxHP += (int)power;
                    target.HP += (int)power;
                    break;
                case BuffType.Damage:
                    target.damageMod += (int)power;
                    break;
                case BuffType.Stress:
                    target.stressMod += (int)power;
                    break;
            }

            if (isPlayer)
            {
                Console.WriteLine(Description);
            }
            Console.WriteLine();
            Console.ResetColor();
        }
    }
    public static int Roll(int min, int max)
    {
        Random rnd = new Random();
        return rnd.Next(min, max);
    }
}