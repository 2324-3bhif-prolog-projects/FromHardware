namespace FightingTest;

public class Character
{
    private static List<int> targetPositionEffects = new List<int> { 1 };
    private Ability[] buffs = new []
    {
        new Ability("Adlerauge", "Inmitten des Chaos verengt sich Dantes Blick – klar, tödlich. Jede Bewegung des Gegners wird zum offenen Buch. \n „Ich sehe... alles.“ \n(+1 auf Accuracy)", targetPositionEffects, (1,2), AbilityType.Buff, 0, BuffType.Accuracy),
        new Ability("Göttliche Fokussierung", "Ein Licht brennt in seinem Innersten, reinigend und klar. Die Stimmen schweigen, der Wille richtet sich auf. \n „Der Pfad ist mir offenbart.“ \n(+1 auf Accuracy)", targetPositionEffects, (1,2), AbilityType.Buff, 0, BuffType.Accuracy),
        new Ability("Segen des Lebens", "Wärme durchströmt ihn wie ein fernes Gebet – als hätte eine höhere Macht ihren Blick nicht abgewendet. \n „Solange ich atme, gebe ich nicht auf.“ \n(+ 5-8 HP)", targetPositionEffects, (5,9), AbilityType.Buff, 0, BuffType.Hp),
        new Ability("Eiserner Leib", "Schmerz vergeht, der Körper erinnert sich an Stärke. Die Wunden bluten, doch er steht – unbeugsam. \n „Du wirst mich nicht brechen.“ \n(+ 4-9 HP)", targetPositionEffects, (4,10), AbilityType.Buff, 0, BuffType.Hp),
        new Ability("Heilige Wut", "Zorn gepaart mit Glaube lodert in seinen Adern. Jeder Schlag wird zum Urteil, jeder Blick zum Befehl. \n „Im Namen des Lichts – stirb.“ \n(+ 1-5 auf Damage)", targetPositionEffects, (1,6), AbilityType.Buff, 0, BuffType.Damage),
        new Ability("Blutrausch", "Der Verstand verflüchtigt sich im Rausch. Die Klinge tanzt, der Blick ist wahnsinnig – aber zielgerichtet. \n „Mehr... gib mir mehr!“ \n(+ 2-4 auf Damage)", targetPositionEffects, (2,5), AbilityType.Buff, 0, BuffType.Damage),
        new Ability("Worte der Verdammnis", "Seine Stimme trägt Gewicht – nicht aus Autorität, sondern aus Abgrund. Jeder Satz zersägt die Seele der Feinde. \n „Du weißt, dass du verloren bist...“ \n(+ 2-5 auf Stresseffekte)", targetPositionEffects, (2,6), AbilityType.Buff, 0, BuffType.Stress),
        new Ability("Schmerzbringer", "Seine Präsenz allein reicht aus, um den Mut der Gegner zu zerbrechen. Ein Dämon in Menschengestalt. \n „Fühlst du es? Das Zittern in deinem Geist?“ \n(+ 1-7 auf Stresseffekte)", targetPositionEffects, (1,8), AbilityType.Buff, 0, BuffType.Stress)
    };

    private Ability[] debuffs = new[]
    {
        new Ability("Nebel des Zweifels", "Die Gewissheit verschwimmt. Jeder Gedanke zieht einen Schatten hinter sich. \n „Ist das der richtige Weg...? War es das je?“ \n(-1 auf Accuracy)", targetPositionEffects, (1, 2), AbilityType.Debuff, 0, BuffType.Accuracy),
        new Ability("Blindes Urteil", "Die Realität verzerrt sich. Die Klinge schlägt ins Leere, Entscheidungen wirken sinnlos. \n „Ich... weiß nicht, was ich tue...“ \n(-1 auf Accuracy)", targetPositionEffects, (1, 2), AbilityType.Debuff, 0, BuffType.Accuracy),
        new Ability("Verwirrung der Verdammten", "Stimmen flüstern, Bilder flackern. Die Sinne taumeln wie auf stürmischem Meer. \n „Warte... wo... bin ich?“ \n(-1 auf Accuracy)", targetPositionEffects, (1, 2), AbilityType.Debuff,
            0, BuffType.Accuracy),
        new Ability("Krankhafter Verfall", "Der Körper wird schwer, jede Bewegung zieht sich wie durch Sumpf. Etwas zerrt an seinen Knochen. \n „Ich spüre den Tod... in mir.“ \n(- 1-5 auf HP)", targetPositionEffects, (2, 6), AbilityType.Debuff, 0, BuffType.Hp),
        new Ability("Blutverlust", "Jeder Atemzug kostet mehr Kraft. Das Leben rinnt – langsam, unausweichlich. \n „So viel... Blut...“ \n (- 3-8 auf HP)", targetPositionEffects, (3, 9), AbilityType.Debuff, 0, BuffType.Hp),
        new Ability("Verdammnis des Körpers", "Glieder verkrampfen, der Schmerz tanzt durch die Nervenbahnen. \n „Mein Körper... gehorcht mir nicht mehr.“ \n(- 5-7 auf HP)", targetPositionEffects, (5, 8), AbilityType.Debuff, 0, BuffType.Hp),
        new Ability("Erschöpfung", "Der Wille ist da – doch der Leib folgt nicht mehr. Alles wird schwer. \n „Nur ein Moment... nur kurz ausruhen...“ \n(- 1-2 auf Damage)", targetPositionEffects, (1, 3), AbilityType.Debuff, 0, BuffType.Damage),
        new Ability("Verlorene Kraft", "Die einstige Stärke – dahin. Jeder Schlag ein Schatten seiner selbst. \n„ Ich... war einst stärker.“ \n(- 3-6 auf Damage)", targetPositionEffects, (3, 7), AbilityType.Debuff, 0, BuffType.Damage),
        new Ability("Kälte des Zweifels", "Ein eisiger Strom durchzieht sein Herz. Jede Entscheidung erstarrt vor Angst. \n „Was, wenn ich falsch liege?“ \n(- 4-7 auf Damage)", targetPositionEffects, (4, 8), AbilityType.Debuff, 0, BuffType.Damage),
        new Ability("Innere Leere", "Kein Zorn, keine Hoffnung. Nur Leere, still und allumfassend. \n „Was bringt das alles?“ \n (- 3-6 auf Stresseffekte)", targetPositionEffects, (3, 7), AbilityType.Debuff, 0 ,BuffType.Stress),
        new Ability("Geistige Erschöpfung", "Die Gedanken brechen auseinander wie alte Mauern. Konzentration? Ein ferner Traum. \n „Ich kann... nicht mehr denken...“ \n(- 2-5 auf Stresseffekte)", targetPositionEffects, (2, 6),
            AbilityType.Debuff, 0, BuffType.Stress),
        new Ability("Verlorene Autorität", "Sein Blick verliert den Glanz, seine Stimme das Gewicht. Niemand hört mehr hin. \n „Ich war doch... jemand.“ \n(- 7-9 auf Stresseffekte)", targetPositionEffects, (7, 10),
            AbilityType.Debuff, 0, BuffType.Stress)
    };
    
    public string Name { get; private set; }
    public int MaxHP { get; set; }
    public int HP { get; set; }
    public int ArmorClass { get; set; }
    public int Stress { get; set; }
    public int Position { get; set; } // 1 = vorne, 4 = hinten
    public List<Ability> Abilities { get; private set; }
    public List<string> StatusEffects { get; private set; }
    public int Accuracy { get; set; }
    public int damageMod { get; set; }
    public int stressMod { get; set; }
    public CharacterType Type { get; private set; }
    
    public Character(string name, int maxHP, int armorClass, int position, List<Ability> abilities, CharacterType type)
    {
        Name = name;
        MaxHP = maxHP;
        HP = maxHP;
        ArmorClass = armorClass;
        Stress = 0;
        Position = position;
        Abilities = abilities;
        StatusEffects = new List<string>();
        Type = type;
    }

    public bool IsAlive()
    {
        return HP > 0;
    }

    public void MoveForward()
    {
        if (Position > 1)
            Position--;
    }

    public void MoveBackward()
    {
        if (Position < 4)
            Position++;
    }

    public void StressOut()
    {
        bool isPlayer = Name == "Dante";
        int effect = Ability.Roll(0, buffs.Length + debuffs.Length);
        
        if (effect > buffs.Length - 1)
        {
            effect -= buffs.Length - 1;
            debuffs[effect].Use(this, this, AbilityType.Debuff, isPlayer);
        }
        else
        {
            buffs[effect].Use(this, this, AbilityType.Buff, isPlayer);
        }

        Stress = 0;
    }
}