namespace Game;

public class PhraseManager
{
    private Random rnd = new Random();

    private string[] kreaturDerHoffnungslosigkeitAttack =
    {
        "Die Kreatur der Hoffnungslosigkeit erhebt sich und entfesselt ihre Qual -",
        "Die verlorene Gestalt richtet sich auf und setzt ihre düstere Macht ein -",
        "Der finstere Hauch formt sich und greift mit finsterer Kraft an -",
        "Der verlorene Schatten erhebt sich und entfacht seinen grausamen Fluch -",
        "Das gequälte Wesen regt sich und entfesselt seine lähmende Energie -"
    };
    
    private string[] minosKampf = {
        "Der große Richter erhebt sich – sein Urteil manifestiert sich in brutaler Wucht –",
        "Minos spannt seinen schlangenartigen Leib – und entfesselt das Gewicht aller Sünden –",
        "Der Zorn des Richters erwacht – und mit ihm die Ketten der Verdammnis –",
        "Sein Stab kracht auf den Boden – das Echo seines Urteils lässt die Mauern beben –",
        "Minos öffnet den Mund – ein Schrei wie aus tausend Kehlen bricht hervor –",
        "Der Körper des Richters windet sich – und richtet seine gerechte Wut auf dich –",
        "Seine Augen glühen auf – die Seelen der Toten sprechen durch ihn –",
        "Minos' Schlangen zischen – ein Angriff der Schuld bricht über dich herein –"
    };
    
    private string[] verloreneVersuchung = {
        "Die Verlorene Versuchung erhebt sich – ein süßer Duft liegt in der Luft, gefolgt von schneidender Kälte –",
        "Ihre Gestalt tanzt im Nebel – Schönheit und Verderben zugleich –",
        "Ein Blick aus leeren Augen trifft dich – zu tief, zu echt – und doch nicht menschlich –",
        "Die Luft flimmert – flüstert – lockt – als strecke sich ein vergessener Wunsch nach dir aus –",
        "Die Versuchung lächelt – ein Lächeln, das dir das Herz einfrieren lässt –",
        "Ihre Stimme schneidet durch dein Denken – honigsüß, giftig, unausweichlich –",
        "Ein Schatten berührt deine Seele – sanft – ehe er sich wie Dornen schließt –",
        "Sie tanzt nicht, sie gleitet – ein Wesen aus Sehnsucht und Schmerz – und nun ist sie bei dir –"
    };
    
    private string[] karontheus = {
        "Karontheus erhebt sich – ein Riss geht durch die Welt, als würde sie selbst ihn nicht tragen wollen –",
        "Sein Schatten breitet sich aus – nicht über den Boden, sondern über dein Bewusstsein –",
        "Ein namenloses Grollen erfüllt die Luft – kein Laut, sondern das Fehlen von allem –",
        "Die Zeit stockt für einen Moment – Karontheus bewegt sich nicht, und doch bist du in Gefahr –",
        "Aus seiner Brust dringt Rauch – schwarz, schwer – als würde Erinnerung selbst verglühen –",
        "Du spürst seine Nähe nicht auf der Haut – sondern in den Gedanken, die du nicht denken willst –",
        "Karontheus existiert nicht – und doch steht er vor dir – falsch, gewaltig, unausweichlich –",
        "Ein Zucken durchläuft sein Körpergerüst – und mit ihm krümmt sich die Realität –"
    };




    
    private string[] minosHpHigh = {
        "Der Gegner wirkt selbstsicher und unbeeindruckt.",
        "Seine Haltung ist aufrecht – der Kampf hat noch kaum begonnen.",
        "Lachend fragt Minos dich „War das alles was du hast?“",
        "Minos steht gähnend vor dir."
    };

    private string[] minosHpMid = {
        "Blut tropft auf den Boden.",
        "Er beginnt zu schwanken, doch sein Blick bleibt entschlossen.",
        "Seine Bewegungen wirken langsamer."
    };

    private string[] minosHpLow = {
        "Er taumelt und kann kaum noch stehen.",
        "Sein Körper zittert.",
        "Blut spritzt aus sämtlichen Körperstellen.",
        "Minos' Kinn sieht verschoben und gebrochen aus.",
        "Er wirkt wie eine Hülle seiner selbst.",
        "Er röchelt, sein Blick verschwimmt.",
        "Sein Körper ist zerfetzt, sein Wille bricht – doch noch lebt er."
    };
    
    private string[] karontheusHpHigh = {
        "Karontheus steht fest und unerschütterlich – unversehrt, als hätte der Kampf für ihn kaum begonnen.",
        "Sein Blick ist kalt und unbewegt, seine Kraft ungebrochen.",
        "Mit voller Stärke hält Karontheus die Stellung – noch keine Schwäche ist in ihm zu spüren.",
        "Unerschrocken und voller Energie blickt Karontheus dich herausfordernd an.",
        "Seine mächtige Gestalt strahlt die Sicherheit aus, die nur völlige Unversehrtheit geben kann.",
        "Noch unbeschadet steht Karontheus da, und sein Selbstvertrauen wirkt fast übermenschlich.",
        "Sein Körper zeigt keine Spuren von Schaden – er ist bereit, jeden Angriff zu erwidern.",
        "Karontheus’ Standhaftigkeit scheint unerschütterlich, getragen von seiner vollen Kraft."
    };
    
    private string[] karontheusHpMid = {
        "Karontheus’ Haltung wird etwas wackliger, doch seine Augen funkeln weiterhin entschlossen.",
        "Blut tropft von seiner Rüstung, doch sein Griff an der Waffe bleibt fest.",
        "Seine Bewegungen sind nicht mehr so flüssig wie zuvor, doch er gibt nicht nach.",
        "Ein leises Knurren entweicht ihm, während er den Schmerz zu ignorieren scheint.",
        "Er schwankt leicht, sammelt sich aber sofort wieder, bereit zum Gegenangriff.",
        "Die Spuren des Kampfes sind deutlich sichtbar, doch Karontheus wirkt noch lange nicht besiegt.",
        "Sein Atem geht schwerer, doch sein Wille bleibt ungebrochen.",
        "Die Schatten um ihn wirken dichter, doch Karontheus hält stand."
    };
    
    private string[] karontheusHpLow = {
        "Karontheus taumelt, sein Stand wankt bedrohlich.",
        "Sein Körper zittert vor Erschöpfung und Schmerz.",
        "Blut rinnt aus zahlreichen Wunden, seine Rüstung ist zerfetzt.",
        "Seine Bewegungen sind schwach, jeder Schritt fällt ihm schwer.",
        "Der Glanz in seinen Augen beginnt zu verblassen, sein Blick wird glasig.",
        "Er wirkt wie ein Schatten seiner selbst, von Schmerzen gezeichnet.",
        "Ein heiseres Röcheln entweicht seinen Lippen, der Kampf zehrt an ihm.",
        "Trotz seiner Qual kämpft er verbissen weiter, doch sein Ende naht."
    };




    public string GetMinosHPPhrase(int currentHP, int maxHP)
    {
        double percent = (double)currentHP / maxHP * 100;

        if (percent > 70)
            return minosHpHigh[rnd.Next(minosHpHigh.Length)];
        else if (percent > 40)
            return minosHpMid[rnd.Next(minosHpMid.Length)];
        else
            return minosHpLow[rnd.Next(minosHpLow.Length)];
    }

    public string GetKreaturDerHoffnungslosigkeitAttack()
    {
        return kreaturDerHoffnungslosigkeitAttack[rnd.Next(kreaturDerHoffnungslosigkeitAttack.Length)];
    }

    public string GetAttack(Character enemy)
    {
        if (enemy.Name == "Kreatur der Hoffnungslosigkeit")
        {
            return GetKreaturDerHoffnungslosigkeitAttack();
        }
        if (enemy.Name == "Minos")
        {
            return minosKampf[rnd.Next(minosKampf.Length)];
        }

        if (enemy.Name == "Verlorene Versuchung")
        {
            return verloreneVersuchung[rnd.Next(verloreneVersuchung.Length)];
        }

        if (enemy.Name == "Karontheus")
        {
            return karontheus[rnd.Next(karontheus.Length)];
        }

        return "";
    }

    public string GetHPPhrase(Character enemy, int currentHP, int maxHP)
    {
        double percent = (double)currentHP / maxHP * 100;
        if (enemy.Name == "Minos")
        {
            return GetMinosHPPhrase(currentHP, maxHP);
        }
        

        if (enemy.Name == "Karontheus")
        {
            if (percent > 70)
                return karontheusHpHigh[rnd.Next(minosHpHigh.Length)];
            if (percent > 40)
                return karontheusHpMid[rnd.Next(minosHpMid.Length)];
            else
                return karontheusHpLow[rnd.Next(minosHpLow.Length)];
        }
        
        return "";
    }
}