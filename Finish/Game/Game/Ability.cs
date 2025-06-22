using System.Net.Mime;

namespace Game;

public class Ability
{
    string[] minosPosStress = new string[]
    {
        "Minos’ Brust hebt sich, als ob ein Sturm in seinem Inneren tobt. Doch statt zu zerbrechen, richtet er sich auf – größer, furchteinflößender denn je.",
        "„Eure Angst… nährt meine Macht.“",
        "Die Ketten um seinen Geist zerreißen – was bleibt, ist pures Zornfeuer.",
        "Minos entfesselt seinen Zorn."
    };
    
    string[] minosNegStress = new string[]
    {
        "Für einen Moment flackert etwas in seinen Augen – nicht Wut, sondern Zweifel. Seine gewaltige Gestalt bebt, als lasteten Jahrhunderte der Schuld auf seinen Schultern.",
        "„Was… habe ich getan…?“",
        "Die Kraft weicht aus seinem Griff, seine Stimme wird schwach. Der Richter beginnt zu wanken."
    };
    
    string[] karantheusPosStress = new string[]
    {
        "Ein donnerndes Grollen durchzieht den Raum – Karantheus’ Körper bebt, doch aus den Rissen dringt reines Unlicht.",
        "Seine Augen lodern auf, leer und allwissend.",
        "Er lacht – nicht aus Freude, sondern aus Erkennen.",
        "Der Schmerz hat ihn nicht geschwächt – er hat ihn erinnert, wer er einmal war.",
        "Karantheus erhebt sich – nicht gebrochen, sondern entfesselt."
    };
    string[] verloreneVerlockungPosStress = new string[]
    {
        "Ihr Blick flackert, ihr Lächeln zittert – und doch… sie tanzt.",
        "Die Maske fällt – aber darunter liegt keine Schwäche, sondern eine tiefere, rohere Schönheit.",
        "Sie flüstert deinen Namen. Nicht um dich zu locken – sondern um dich zu brechen.",
        "Ihre Wunden glühen wie Runen – du erkennst: Das ist kein Verfall. Das ist Verwandlung.",
        "Die Verlorene Verlockung kehrt zurück – schärfer, bitterer, unwiderstehlich."
    };
    
    string[] kreaturDerHoffnungslosigkeitPosStress = new string[]
    {
        "Ein heiseres, klagendes Wimmern hallt durch den Nebel – und wird zum Knurren.",
        "Die Schatten an ihrem Leib beginnen sich zu drehen – wie Klingen.",
        "Ihr Elend ist endlos – und du spürst: Sie will, dass du es ebenso kennst.",
        "Sie wächst nicht an Hoffnung, sondern am Zusammenbruch der deinen.",
        "Die Kreatur erhebt sich. Was schwach wirkte, war nur ein Spiegel deiner Gnade."
    };
    
    string[] karantheusNegStress = new string[]
    {
        "Für einen Moment erlischt das dunkle Feuer in seinen Augen, ersetzt von einem Schatten der Unsicherheit.",
        "Sein gewaltiger Leib zittert, als trügen ihn Jahrhunderte von verlorenen Seelen.",
        "Ein Flüstern entgleitet seinen Lippen: ‚Was habe ich… verloren?‘",
        "Sein Griff auf die Schatten lockert sich, und sein Lachen klingt plötzlich hohl.",
        "Karantheus taumelt – der Sturm in ihm beginnt zu schwinden."
    };
    
    string[] verloreneVerlockungNegStress = new string[]
    {
        "Ein Moment der Klarheit durchdringt ihren Blick – keine Verführung mehr, sondern reine Verzweiflung.",
        "Ihr Lächeln bricht auseinander, zitternd und zerbrechlich wie Glas.",
        "‘Warum... verliere ich mich?’ haucht sie, während ihre Gestalt schwankt.",
        "Die Schatten um sie herum flackern und fallen zurück.",
        "Die Verlorene Verlockung sinkt, gefangen zwischen Sehnsucht und Vergessen."
    };
    
    string[] kreaturDerHoffnungslosigkeitNegStress = new string[]
    {
        "Ein schmerzhaftes Röcheln entkommt ihrem Leib, der unter der Last von Äonen zusammenzubrechen scheint.",
        "Ihre bleichen Augen verlieren den Glanz, getrübt von Zweifeln und Schmerz.",
        "‘Warum soll ich weiter leiden?’ hallt es in der düsteren Stille.",
        "Die Schatten an ihr zerfallen, ihr Flüstern wird leiser.",
        "Die Kreatur sackt zusammen, gebrochen von der eigenen Qual."
    };








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
        double power = Roll(PowerRange.min, PowerRange.max+1);
        if (type == AbilityType.Attack)
        {
            if (attackRoll >= target.ArmorClass)
            {
                if (attackRollRaw == 20)
                {
                    power *= 1.5;
                    Console.WriteLine("Dein Angriff verursacht kritischen Schaden!");
                }
                target.HP -= (int)power + user.DamageMod;
                target.Stress += StressEffect + user.StressMod;

                Console.WriteLine($"[Würfelergebnis: {attackRollRaw} + {user.Accuracy} (Treffer)] – {target.Name} erleidet {(int)power} + {user.DamageMod} Schaden.");
                Console.WriteLine();
                if(target.HP > 0 && target.Type == CharacterType.Boss)
                {
                    Console.WriteLine(phraseMgr.GetHPPhrase(target, target.HP, target.MaxHP));
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
            if (user.HP > user.MaxHP)
            {
                user.HP = user.MaxHP;
            }
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
                    if (user.Name == "Minos")
                    {
                        TextOutput(minosNegStress);
                    }
                    else if (user.Name == "Kreatur der Hoffnungslosigkeit")
                    {
                        TextOutput(kreaturDerHoffnungslosigkeitNegStress);
                    }
                    else if (user.Name == "Karantheus")
                    {
                        TextOutput(karantheusNegStress);
                    }
                    else if (user.Name == "Verlorene Verlockung")
                    {
                        TextOutput(verloreneVerlockungNegStress);
                    }
                }

                if (this.Name == "Peitsche der Begierde")
                {
                    Game.Attack(user, target);
                }
            }
            else
            {
                if (!isPlayer)
                {
                    if (user.Name == "Minos")
                    {
                        TextOutput(minosPosStress);
                    }
                    else if (user.Name == "Kreatur der Hoffnungslosigkeit")
                    {
                        TextOutput(kreaturDerHoffnungslosigkeitPosStress);
                    }
                    else if (user.Name == "Karantheus")
                    {
                        TextOutput(karantheusPosStress);
                    }
                    else if (user.Name == "Verlorene Verlockung")
                    {
                        TextOutput(verloreneVerlockungPosStress);
                    }
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
                    target.DamageMod += (int)power;
                    break;
                case BuffType.Stress:
                    target.StressMod += (int)power;
                    break;
                case BuffType.Armor:
                    target.ArmorClass += (int)power;
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
    
    private static void TextOutput(string[] text)
    {
        foreach (string zeile in text)
        {
            Console.WriteLine(zeile);
        }
    }
}