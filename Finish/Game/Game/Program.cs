using System.Net.Mime;

namespace Game;

public class Game
{
    public static string[] minosStress = new string[]
    {
        "Ein Zittern geht durch den gewaltigen Leib des Richters.",
        "Der Zorn, der ihn jahrtausendelang antrieb, flackert – nur für einen Moment – und bricht.",
        "Minos’ Atem geht stoßweise, der Blick flackert. Die Stimmen der Verdammten hallen in seinem Kopf, lauter als je zuvor.",
        "„Ich... kann nicht mehr unterscheiden… schuldlos, schuldig… sie schreien alle.“",
        "Die Ketten, die andere banden, schlingen sich nun um sein Herz."
    };
    
    public static string[] kreaturDerHoffnungslosigkeitStress = new string[]
    {
        "Ein stummes Beben durchfährt die gebrechliche Hülle der Kreatur.",
        "Ihr Blick irrt leer durch die Finsternis, als suche sie einen Ausweg, den es nie gab.",
        "Ein Flüstern bricht aus ihrer Kehle – kein Wort, nur reines Leid.",
        "„Hoffnung…? Ich erinnere mich nicht…“",
        "Die Schatten, aus denen sie geboren wurden, scheinen sich enger um ihre Glieder zu winden.",
        "Mit jedem Atemzug zerfällt ein Stück ihres einstigen Selbst.",
        "Der Boden unter ihr wirkt wie ein Spiegel – er zeigt nur Leere.",
        "Für einen Moment wirkt sie… menschlich. Dann verzehrt der Nebel alles."
    };
    
    public static string[] karontheusStress = new string[]
    {
        "„Karantheus hält inne – seine Schultern zucken, als würde ein unsichtbarer Druck auf ihm lasten.“",
        "„Ein unheilvolles Leuchten bricht in seinen Augen auf – Wahnsinn oder Macht?“",
        "„Er lacht. Erst leise, dann schrill – als würde etwas in ihm brechen… oder wachsen.“",
        "„Die Schatten um ihn beginnen sich schneller zu winden. Etwas verändert sich.“",
        "„Ein Riss geht durch seine Erscheinung – als würde Realität ihn nicht mehr vollständig fassen können.“"
    };
    
    public static string[] verloreneVersuchungStress = new string[]
    {
        "„Ein Zittern geht durch ihre Gestalt – als hätte ein Riss das seidene Gewebe ihres Wesens durchdrungen.“",
        "„Die Illusion flackert. Für einen Moment siehst du ihr wahres Gesicht: leer, ausgehöhlt, alt.“",
        "„Sie lacht – ein Laut wie Glas, das bricht. Schönheit und Wahnsinn verschwimmen.“",
        "„Ihre Stimme wird schriller, überschlägt sich – als würde sie dich mit Worten festhalten wollen, während sie selbst zerfällt.“",
        "„Ein Teil von ihr beginnt zu verglühen. Duft, Gestalt, Lockung – alles beginnt zu fliehen.“"
    };


    
    public static string[] minosTod = new string[]
    {
        "Minos ist gefallen. "
    };

    public static string[] karontheusTod = new string[]
    {
        "Karontheus sinkt auf die Knie."
    };

    public static string[] verloreneVerlockungTod = new string[]
    {
        "Du stößt deine Klinge in die brüchige Gestalt der Verlorenen Versuchung – ein leises, klagendes Stöhnen entweicht, als wäre es ihr erster und letzter Laut zugleich.",
        "Aus der Wunde entweicht kein Blut, nur grauer Staub, der sich lautlos im Nebel auflöst.",
        "Die Kreatur sackt zusammen wie ein Schatten, dem das Licht entrissen wurde.",
        "Ein letzter Blick trifft dich – leer, doch voller unausgesprochener Worte. Dann verflüchtigt sie sich.",
        "Ihre Gestalt zerfällt, als hätte sie nie existiert – nur die eisige Kälte bleibt zurück."
    };
    
    public static string[] kreaturDerHoffnungslosigkeitTod = new string[]
    {
        "Du stößt deine Klinge durch die morsche Brust der Kreatur – ein erstickter Laut entweicht, als wäre es ihr erster und letzter Atem zugleich.",
        "Aus der Wunde rinnt kein Blut, nur graue Asche, die sich lautlos im Nebel verliert.",
        "Die Kreatur fällt in sich zusammen wie ein Schatten ohne Lichtquelle.",
        "Ein letzter Blick trifft dich – leer, aber voller Bedeutung. Dann vergeht sie.",
        "Ihre Form löst sich auf, als hätte sie nie existiert – nur die Kälte bleibt zurück.",
        "Du atmest schwer, blickst dich hastig um – aber es scheint still geworden zu sein. Ohne zu zögern rennst du zurück, zurück zu Virgil."
    };
    
    public static string[] niederlageSumpf = new string[]
    {
        "Du schlägst um dich, wehrst Angriff um Angriff ab. Doch es sind zu viele.",
        "Plötzlich spürst du einen Griff an deinem Rücken – einer der Kreaturen hält dich fest. Ein zweiter schnappt zu.",
        "Ein beißender Schmerz durchfährt deine Kehle. Warmes Blut rinnt an deinem Hals herab, und deine Kräfte schwinden.",
        "Du fällst zu Boden.",
        "Der Himmel verdunkelt sich.",
        "Und so endet deine Reise hier – in Hoffnungslosigkeit."
    };
    
    public static string[] niederlageMinos = new string[]
    {
        "Du kämpfst verbissen, wehrst Angriff um Angriff des Richters ab. Doch seine Macht ist überwältigend.",
        "Plötzlich spürst du Minos’ eisige Hand, die dich packt und zu Boden drückt.",
        "Sein kalter Griff schnürt dir die Luft ab, ein stechender Schmerz durchfährt deinen Brustkorb.",
        "Dein Atem stockt, das Licht vor deinen Augen flackert und erlischt langsam.",
        "Die Schatten um dich verdichten sich,",
        "und so endet dein Kampf – im Schatten der Verdammnis."
    };
    
    public static string[] niederlageVerloreneVerlockung = new string[]
    {
        "Du kämpfst gegen die Verlorene Versuchung, wehrst ihren verführerischen Angriffen stand. Doch ihre List ist überwältigend.",
        "Plötzlich spürst du, wie sie dich mit eisigen Fingern berührt – ein Netz aus Schatten umschlingt dich.",
        "Ein stechender Schmerz zieht durch deine Seele, dunkle Flammen lodern in deinem Geist auf.",
        "Deine Willenskraft zerbricht, und du sinkst zu Boden.",
        "Die Welt um dich verschwimmt,",
        "und so endet deine Hoffnung in Verlockung und Verfall."
    };
    
    public static string[] niederlageKarontheus = {
        "Du kämpfst gegen Karontheus, seine Schattenangriffe sind schnell und gnadenlos. Doch du hältst dagegen, jeder Schlag ein Kampf ums Überleben.",
        "Plötzlich spürst du, wie seine kalte Hand nach dir greift – ein dunkler Nebel breitet sich aus und umhüllt dich.",
        "Ein eisiger Schmerz durchfährt deinen Geist, als würde Dunkelheit selbst deine Seele zerreißen.",
        "Deine Kraft schwindet, und du fällst schwer zu Boden.",
        "Die Welt um dich verschwimmt,",
        "und so endet deine Reise hier – im Griff der Schatten und Verzweiflung."
    };
    




    
    
    public static void Main(string[] args)
    {
        
        List<int> targetPosition = new List<int> { 1, 2 };
        Ability veraSpada = new Ability("Vera Spada", "Ein schneller Hieb mit einer geweihten Klinge. (Moderater Schaden) (Target: x | x | o | o)", targetPosition, (12,19), AbilityType.Attack, 0);
        Ability gewissenserweckung = new Ability("Gewissenserweckung", "Mit einem Ausruf göttlicher Erkenntnis zwingt Dante den Gegner, sich seiner Schuld zu stellen. (Weniger Schaden + Stress) (Target: x | x | x | o)",  targetPosition, (4,8), AbilityType.Attack,  20);
        Ability gebetDerKlarheit = new Ability("Gebet der Klarheit", "Ein ruhiges Gebet stärkt Dantes Geist. (leichte Heilung)", targetPosition, (5,9), AbilityType.Heal, 0, BuffType.Hp);
        Ability klarerBlick = new Ability("Klarer Blick", "Dante schließt kurz die Augen, richtet seinen Geist – und öffnet sie mit tödlicher Entschlossenheit. (Erhöht die Trefferquote)", targetPosition, (1, 2), AbilityType.Buff, 0, BuffType.Accuracy);
        List<Ability> abilitiesPlayer = new List<Ability> { veraSpada,  gewissenserweckung, gebetDerKlarheit, klarerBlick};
        Character dante = new Character("Dante", 100, 11, 1, abilitiesPlayer, CharacterType.Player);
        
        string answer;
        Console.WriteLine("Kapitel 1: Der Ruf in die Tiefe");
        Console.WriteLine("-------------------------------");
        Console.WriteLine();
        Console.ReadKey(true);
        Console.WriteLine(">Ein wenig hiervon... und noch ein Hauch davon...<  Boom!");
        Console.WriteLine("Eine kleine Explosion hüllt das Gefäß in Rauch.");
        Console.WriteLine(
            "„Was tust du schon wieder, Dante?“, fragt Vater entsetzt und blickt über deine Schulter auf das qualmende Glas.");
        Console.ReadKey(true);
        Console.WriteLine(
            "„Ach, nichts...“, murmelst du und wischst dir den Ruß von der Stirn. „Ich bringe es ohnehin nicht zu Ende.“");
        Console.WriteLine(
            "„Meinst du nicht, dass du mittlerweile zu alt bist, um einer Legende nachzujagen?“ fragt Vater, sich müde an die Schläfen fassend.");
        Console.WriteLine(
            "„Nein! Es muss möglich sein. Ich war so nah dran! Mir fehlt nur noch ein letzter Bestandteil...“");
        Console.WriteLine(">aber was könnte es nur sein?<, führst du den Satz in Gedanken zu Ende.");
        Console.ReadKey(true);
        Console.WriteLine("Mutter betritt neugierig das Zimmer.");
        Console.WriteLine("„Bist du schon wieder mit deiner Alchemie beschäftigt?“");
        Console.WriteLine("„Ja. Ich bin kurz vor dem Durchbruch, ich spüre es!“ antwortest du mit Funkeln in den Augen.");
        Console.ReadKey(true);
        Console.WriteLine("„Na schön – dann lassen wir dich in Ruhe, aber komm nicht zu spät zum Schwertkampf!“");
        Console.WriteLine("„Ja, ich brauche nicht mehr lange!“");
        Console.WriteLine("Die Tür schließt sich hinter ihnen, dann hörst du leises Flüstern.");
        Console.ReadKey(true);
        Console.WriteLine(
            "„Seit Beatrices Tod ist er ganz von seinen Alchemisten-Träumen eingenommen... Ich will nicht, dass er das Schwert aus der Hand legt – schließlich steht ihm bald der Ritterschlag bevor.“, hörst du Vater murmeln.");
        Console.WriteLine("„Er wird schon seinen Weg finden. Er hat Herz unser Junge, soviel ist zu sagen.“, antwortet Mutter leise.");
        Console.WriteLine(
            "„Sie wissen doch gar nicht, wie es ist, jemanden zu verlieren…“ murmelst du, während du auf das halb verkohlte Rezept blickst. \nEin letztes Mal versuchst du, die geheimen Anweisungen umzudeuten, das Verhältnis der Zutaten zu ändern – vielleicht ist es der Atem der Nachtkerze? Oder ein Tropfen Tränenkraut? Es ist ein Trank, wie ihn nur wenige wagen zu denken – eine Essenz, von der alte Schriften raunen, dass sie einem den Weg in die Tiefe der neun Höllenkreise öffnen könnte.\n");
        Console.ReadKey(true);
        Console.WriteLine(
            "Von alten Druiden, so heißt es, stammt die Legende. Von alten Druiden, die einst in verborgenen Hainen in den Tiefen ihrer Wälder mit den Schatten jenseits unserer Welt sprachen.");
        Console.WriteLine("Die Wand zwischen Leben und Tod sei dort nur ein dünner Schleier, so sagt man, und man könne hindurchtreten, hinab in dunkle Gefilde, wenn man nur das Gleichgewicht der Elemente wahre.");
        Console.WriteLine("„ES KLAPPT!“ rufst du plötzlich, erfüllt von neuem Leben.");
        Console.WriteLine("„Es sieht genauso aus wie im Buch beschrieben…“");
        Console.ReadKey(true);
        Console.WriteLine(
            "Voller Erwartung – und Sehnsucht nach Beatrice – führst du das Glas an deine Lippen und trinkst, bis nur die Hälfte des Trankes verbleibt.");
        Console.WriteLine("Ein mulmiges Gefühl umfängt deinen Magen, dann wird langsam Schwindel deiner Sinne Herr. Ein schwarzer Vorhang verhüllt deine Sicht.");
        Console.WriteLine("Und dann… – platsch");
        Console.ReadKey(true);
        Console.WriteLine("Du fällst zu Boden.");
        Console.WriteLine("Langsam findet dein Bewusstsein zurück zu dir.");
        Console.WriteLine("„Aah… mein Kopf…“, stöhnst du benommen.");
        Console.ReadKey(true);
        Console.WriteLine(
            "Langsam öffnest du die Augen. Um dich herum nur dichter Wald – uralte Bäume mit gewundenen Ästen, deren Rinde wie verbrannt wirkt.  \nDie Welt scheint finster und rötliche Schlieren bluten vom Horizont in den dunklen Himmel über dir, als hätte sich ein Fluch über die Welt gelegt und sie der Gänze ihres Lichtes beraubt.");
        Console.WriteLine("Plötzlich hörst du eine Stimme hinter dir.");
        Console.WriteLine("„Welch’ verirrte Seele zeigt sich hier?“");
        Console.ReadKey(true);
        Console.WriteLine("Mit einem Ruck fährst du herum. Panik liegt in deinem Blick.");
        Console.WriteLine("Ein fremder Schatten steht zwischen zwei Bäumen.");
        Console.WriteLine("„So weiß ich um euren Namen, nicht jedoch um das Warum eurer Reise.“");
        Console.ReadKey(true);
        Console.WriteLine();

        bool answered = false;
        do
        {
            Console.WriteLine("Was willst du fragen?");
            Console.WriteLine("1. \"Wer seid Ihr?\"");
            Console.WriteLine("2. \"Wo bin ich hier?\"");
            answer = Console.ReadLine();
            Console.WriteLine();

            if (answer == "1" || answer == "1.")
            {
                answered = true;
                Console.WriteLine("Du machst einen Schritt zurück. Deine Stimme zittert.");
                Console.WriteLine("„Wer… wer seid Ihr?“");
                Console.WriteLine("Der Mann neigt leicht den Kopf, seine Stimme ist ruhig, gar würdevoll.");
                Console.ReadKey(true);
                Console.WriteLine("„Ein Freund, wenn es euch beliebt und ein Führer, sofern Ihr bereit dafür seid.“");
                Console.WriteLine(
                    "Langsam tritt die Gestalt aus dem Schatten der Bäume. Der Umhang, dessen Kragen locker ihren Hals gürtet, wirkt alt, wie aus einer anderen Zeit, und sein Blick ist ruhig, aber durchdringend.");
                Console.WriteLine("„Nicht bin ich, jedoch war ich Mensch und Poet sogleich.“");
                Console.ReadKey(true);
                Console.WriteLine(
                    "Dein Atem stockt und die Intuition flüstert dir einen Namen zu.");
                Console.WriteLine("“Virgil? Ihr…Virgil der Dichter?“");
                Console.WriteLine("Nur ein sanftes Nicken kommt dir als Antwort zugute, ein Windhauch zieht durch die verdorben wirkenden Äste und das Rascheln der Blätter umfängt deinen Geist wie das Flüstern einer Geliebten.");
                Console.ReadKey(true);
                Console.WriteLine("„Ihr seid gefallen. Gefallen in eine Welt jenseits der euren, doch Zufall war es keiner.“, seine Stimme wird ernster, „Nun sprecht, euer Begehr, Freund.“");
                Console.WriteLine(
                    "Du zögerst, in den Tiefen deines Geistes nach den richtigen Worten suchend.");
                Console.WriteLine(
                    "„Welch’ Motiv sei stärker als die Liebe und welch’ Begehr noch größer als sie zu erhalten?“");
                Console.ReadKey(true);
                Console.WriteLine("Gänsehaut bedeckt deinen Körper. ");
            }
            else if (answer == "2" || answer == "2.")
            {
                answered = true;
                Console.WriteLine("„Wo bin ich hier?“ fragst du benommen, während du dich langsam aufrichtest.");
                Console.WriteLine(
                    "Die Luft ist schwer, die Bäume verdreht und schwarz, der Himmel von einem düsteren Rot durchzogen.");
                Console.WriteLine("Die Gestalt vor dir antwortet mit tiefer, ruhiger Stimme:");
                Console.ReadKey(true);
                Console.WriteLine(
                    "„Selbst die Tapfersten meiden diesen Ort, dies’ Vorzimmer des Bösen.");
                Console.WriteLine("Ein Schauer läuft dir über den Rücken.");
                Console.WriteLine("Du blickst ihn genauer an. Etwas an ihm kommt dir seltsam vertraut vor.");
                Console.ReadKey(true);
                Console.WriteLine(
                    "„Ich... ich kenne dich doch. Du bist... dieser Dichter... wie war dein Name noch gleich?“");
                Console.WriteLine("Er senkt leicht den Kopf.");
                Console.WriteLine("„Virgil ist mein Name.“");
                Console.WriteLine("Du erstarrst kurz.");
                Console.ReadKey(true);
                Console.WriteLine("„Ja, genau! Virgil... Was machst du hier unten?“");
                Console.WriteLine("Sein Blick wird ernst.");
                Console.WriteLine("„Das ist ohne Bedeutung. Was zählt, ist, dass ich weiß, warum du hier bist.“");
                Console.ReadKey(true);
                Console.WriteLine("Er tritt näher, seine Stimme wird klar und eindringlich:");
                Console.WriteLine(
                    "„Wenn du Beatrice wirklich retten willst, musst du weitergehen. Aber allein wirst du keinen Schritt weit kommen.“");
                Console.WriteLine("Ein eisiger Hauch streicht durch die Bäume. Dir läuft Gänsehaut über den Körper.");
            }
            else
            {
                Console.WriteLine("Ungültige Wahl. Bitte wähle 1 oder 2.");
            }
        } while (!answered);

        answered = false;
        Console.ReadKey(true);
        Console.WriteLine("Du blickst dich langsam um, während der Nebel zwischen den Bäumen tanzt.");
        Console.WriteLine(
            "Im Norden erkennst du vage die Umrisse eines Gebäudes – halb verborgen im Dunst, wie ein Schatten der Vergangenheit. Ist es eine alte Ruine? Vielleicht findest du dort etwas Nützliches... Doch aus derselben Richtung hallen verzerrte Schreie durch die Luft – gequält und fern, und doch beunruhigend nah.");
        Console.WriteLine(
            "Im Osten führt ein schmaler Pfad weiter. Der Boden wirkt dort fester, und zwischen den krummen Bäumen liegt der Weg in bedrückender Stille.");
        Console.ReadKey(true);
        Console.WriteLine(
            "Virgil hebt langsam die Hand und deutet auf diesen Pfad, ohne ein Wort zu sagen – doch seine Geste ist eindeutig.");
        Console.WriteLine(
            "Im Süden breitet sich ein düsteres Sumpfgebiet aus. Schwarzes Wasser glitzert zwischen faulen Bäumen, und der Gestank von Verwesung liegt in der Luft.");
        Console.WriteLine("Der Wind schweigt. Alles schweigt.");
        Console.ReadKey(true);
        Console.WriteLine();

        do
        {
            Console.WriteLine("Wohin gehst du?");
            Console.WriteLine("1. Zum Gebäude im Norden – trotz der Schreie");
            Console.WriteLine("2. Dem Pfad im Osten folgen, Virgils Zeichen vertrauen");
            Console.WriteLine("3. In das Sumpfgebiet im Süden wagen");
            answer = Console.ReadLine();
            Console.WriteLine();
            if (answer == "1" || answer == "1.")
            {
                answered = true;
                Console.WriteLine("Du entscheidest dich, in Richtung Norden aufzubrechen.");
                Console.WriteLine("Der Weg dorthin ist still, nur das Knacken deiner Schritte auf dem toten Laub begleitet dich. Als du näher kommst, bestätigt sich dein Verdacht – vor dir erhebt sich eine alte, verfallene Ruine. Die Mauern sind vom Zahn der Zeit gezeichnet, mit tiefen Rissen und überwachsenen Steinen.");
                Console.WriteLine("Trotz der düsteren Stimmung spürst du einen Hauch von Neugier – vielleicht verbirgt sich hier etwas Nützliches?");
                Console.ReadKey(true);
                Console.WriteLine("Mit Bedacht trittst du ein. Das Innere ist leer und still, fast gespenstisch. Räume brechen an vielen Stellen ein, Wände sind von feuchtem Moos und seltsam leblosen Pflanzen überwuchert. Doch dann entdeckst du zwischen den Ranken etwas Metallisches.");
                Console.WriteLine("Ein alter, aber erstaunlich gut erhaltener Helm liegt halb verborgen im Grün. Du hebst ihn auf – er ist schwer, robust, und könnte dir durchaus nützen.");
                Console.ReadKey(true);
                Console.WriteLine("Du setzt ihn auf und fühlst dich ein wenig sicherer.");
                Console.WriteLine("Deine Rüstungsklasse wurde um 1 erhöht.");
                Console.WriteLine("Mit einem letzten Blick in die verlassene Halle kehrst du zurück – der Weg zu Virgil scheint nun klarer als zuvor.");
                dante.ArmorClass += 1;
            }
            else if (answer == "2" || answer == "2.")
            {
                answered = true;
            }
            else if (answer == "3" || answer == "3.")
            {
                answered = true;
                Console.WriteLine("Du begibst dich mit der leisen Hoffnung, im Süden vielleicht etwas Verwertbares zu finden, in Richtung des düsteren Sumpfgebiets.");
                Console.WriteLine("Der Boden wird weicher, bald schon schlammig. Deine Schritte sinken ein, und mit jedem Meter breitet sich ein schwerer Gestank aus – nach Teer, Moder und altem Blut.");
                Console.WriteLine("Doch plötzlich... Stimmen. Flüsternd, drohend, überall um dich herum.");
                Console.ReadKey(true);
                Console.WriteLine("„Was ist das…?“ flüsterst du dir selbst zu, während dein Blick suchend durch den Nebel gleitet.");
                Console.WriteLine("Dann siehst du sie: Aus dem Morast erheben sich Gestalten – halb verwest, mit leeren Blicken und schleppenden Bewegungen. Ihre Augen flackern träge, als wäre jeder Funke Leben aus ihnen gewichen.");
                Console.WriteLine("Kreaturen der Hoffnungslosigkeit.");
                Console.ReadKey(true);
                Console.WriteLine("Mit jedem Schritt, den sie auf dich zugehen, spürst du, wie sich Kälte in deinem Herzen ausbreitet.");
                Console.WriteLine();
                Console.WriteLine("= Es kommt zum Kampf gegen die Hoffnungslosen =");
                Console.ReadKey(true);
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                List<Ability> test1 = new List<Ability> { veraSpada };
                Character test = new Character("test", 20, 10, 2, test1, CharacterType.Enemy);
                List<Character> enemy = new List<Character> {KreaturDerHoffnungslosigkeit(), test};
                Fight(enemy, dante, niederlageSumpf, kreaturDerHoffnungslosigkeitTod, kreaturDerHoffnungslosigkeitStress);
            }
            else
            {
                Console.WriteLine("Ungültige Wahl. Bitte wähle 1, 2 oder 3.");
            }
        } while (!answered);
        
        Console.WriteLine("Du begibst dich gemeinsam mit Virgil auf den Weg nach Osten.");
        Console.WriteLine("Der schmale Pfad windet sich durch kahle Bäume, deren Äste wie knochige Finger in den düsteren Himmel ragen. Zwischen den Sträuchern leuchten seltsame Beeren – in Farben, die du nie zuvor gesehen hast. Du gehst vorsichtig, fast schon paranoid, mit jedem Rascheln in der Dunkelheit rechnend.");
        Console.WriteLine("Die Reise zieht sich endlos, als würde die Zeit selbst hier nicht weiterfließen.");
        Console.ReadKey(true);
        Console.WriteLine("Dann endlich – eine Lichtung. Vor euch: eine große Menschenmenge.");
        Console.WriteLine("Menschliche Gestalten, stumm, blass, in sich zusammengesunken. Ihre Augen leer, ihre Körper kaum mehr als Schatten ihres einstigen Selbst.");
        Console.WriteLine("Sie warten.");
        Console.ReadKey(true);
        Console.WriteLine("„Die Nächsten, bitte!\"");
        Console.WriteLine("Eine schneidende Stimme ruft über den Platz.");
        Console.WriteLine("„Das ist Charon“, flüstert Virgil dir zu. „Der Fährmann. Er bringt die Seelen über den Fluss Acheron – von der Vorhölle zu Minos, dem Richter. Wir sollten uns beeilen und an Bord gehen.“");
        Console.ReadKey(true);
        Console.WriteLine("Ohne groß zu überlegen rufst du: „Hey! Ich möchte mitfahren!“");
        Console.WriteLine("Wie auf ein unsichtbares Kommando teilt sich die wartende Menge.");
        Console.WriteLine("Ein schmaler Pfad öffnet sich direkt zur Fähre.");
        Console.ReadKey(true);
        Console.WriteLine("Verwirrt blickst du zu Virgil. „Warum machen die uns Platz?“");
        Console.WriteLine("Er sieht dich ernst an. „Glaubst du wirklich, jemand zieht das Leid eines der Kreise dem Warten auf sein Urteil vor?“");
        Console.WriteLine("Du schluckst.");
        Console.ReadKey(true);
        Console.WriteLine("Dann setzt du langsam einen Fuß vor den anderen und gehst auf die Fähre zu – bereit, dich dem zu stellen, was jenseits des Flusses liegt.");
        Console.WriteLine();
        
        Console.WriteLine("Kapitel 2: Urteil");
        Console.WriteLine("-----------------\n");
        Console.ReadKey(true);

        Console.WriteLine("Das Wasser liegt still da – unnatürlich still. Kein Windhauch kräuselt die Oberfläche, kein Laut durchbricht die gespenstische Stille.");
        Console.WriteLine("Du hast noch nie zuvor eine Überfahrt erlebt, die so still, so bedrückend war.");
        Console.WriteLine("Kaum zwanzig Minuten vergehen, da erreicht ihr bereits das andere Ufer.");
        Console.ReadKey(true);
        Console.WriteLine("Langsam steigst du aus dem Boot und betrittst einen morsch wirkenden Holzsteg. Jeder Schritt knarrt unter deinem Gewicht, als würde das Holz selbst vor dem fürchten, was vor dir liegt.");
        Console.WriteLine("Dein Herz schlägt schneller. Deine Hände zittern leicht.");
        Console.WriteLine("Vor dir erhebt sich ein dunkler Durchgang – der Eingang zur Halle des großen Richters: Minos – derjenige, der über die Verdammten urteilt und sie den Kreisen zuweist, die ihrem innersten Wesen entsprechen.");
        Console.ReadKey(true);
        Console.WriteLine("Du stehst nun an der Schwelle.");
        Console.WriteLine();
        answered = false;
        do
        {
            Console.WriteLine("Bist du bereit, dich seinem Urteil zu stellen?");
            Console.WriteLine("1. Ja");
            Console.WriteLine("2. Nein");
            answer = Console.ReadLine();
            Console.WriteLine();

            if (answer == "1" || answer == "1.")
            {
                Console.WriteLine("Mit fester Miene und dem Anschein von Selbstbewusstsein schreitest du durch die Tore zum Urteilssaal von Minos.");
                Console.WriteLine("Dunkelheit empfängt dich – dicht und undurchdringlich –, doch du bleibst standhaft.");
                answered = true;
            }
            else if (answer == "2" || answer == "2.")
            {
                Console.WriteLine("Der Wind steht still, doch in dir tobt ein Sturm.");
                Console.WriteLine("Dein Blick schweift suchend über das dunkle Gemäuer, während dein Herz rast.");
                Console.WriteLine("„Was, wenn ich dort drinnen sterbe? Was, wenn alles hier endet?“");
                Console.ReadKey(true);
                Console.WriteLine("Du spürst, wie sich Kälte in deinem Inneren ausbreitet.");
                Console.WriteLine("„Dann verliere ich nicht nur Beatrice… sondern auch alles andere. Meine Familie. Meine Zukunft. Mich selbst.“");
                Console.WriteLine("Für einen Moment zögerst du. Doch dann ballst du deine Faust.");
                Console.ReadKey(true);
                Console.WriteLine("„Nein. So darf es nicht enden.“");
                Console.WriteLine("Ein letzter Gedanke, der sich wie eine Klinge durch den Nebel deiner Angst schneidet.");
                Console.WriteLine("Du nimmst deinen ganzen Mut auf und schreitest durch die Tore zum Urteilssaal von Minos.");
                Console.ReadKey(true);
                answered = true;
            }
            else
            {
                Console.WriteLine("Ungültige Wahl. Bitte wähle 1 oder 2.");
            }
        } while (!answered);

        Console.WriteLine("Am Eingang entdeckst du eine alte, verstaubte Fackel, die in einer Wandhalterung steckt.");
        Console.WriteLine("Mit einer schnellen, beinahe nervösen Geste zündest du sie an.");
        Console.WriteLine("Das zitternde Licht offenbart das Innere des Korridors: kalt, verlassen, leblos.");
        Console.ReadKey(true);
        Console.WriteLine("„Warum sollte hier überhaupt jemand etwas gestalten?“ denkst du dir.");
        Console.WriteLine("Die Wände sind roh, von Zeit und Leid gezeichnet, überwuchert von totem Pflanzenwerk.");
        Console.WriteLine("Die Schatten tanzen an den Wänden, einzig von deiner Fackel zum Leben erweckt.");
        Console.ReadKey(true);
        Console.WriteLine("Mit jedem Schritt, den du näher an den Saal des Richters trittst, wächst das Gewicht auf deinen Schultern.");
        Console.WriteLine("Deine Nervosität kriecht langsam in deine Glieder.");
        Console.WriteLine("Eine alte Steintreppe führt dich hinauf. Jeder Tritt hallt bedrohlich wider.");
        Console.ReadKey(true);
        Console.WriteLine("Virgil bleibt zurück, sein Blick ruht auf dir.");
        Console.WriteLine("„Ich glaube an dich“, sagt er leise – und seine Stimme klingt, als käme sie aus weiter Ferne.");
        Console.WriteLine("Dann stehst du vor der Tür.");
        Console.ReadKey(true);
        Console.WriteLine("Du atmest tief ein und trittst ein.");
        Console.WriteLine("Ein Wispern aus der Dunkelheit. Dann eine Stimme – tief und rau:");
        Console.WriteLine("„Dante. Ich habe dich bereits erwartet.“");
        Console.ReadKey(true);
        Console.WriteLine("Du spannst deine Schultern an.");
        Console.WriteLine("„Du kannst mir gar nichts!“ rufst du, die Fackel fest in der Hand.");
        Console.WriteLine("Aus der Dunkelheit schält sich langsam eine massive Gestalt – Minos.");
        Console.ReadKey(true);
        Console.WriteLine("Mit jedem Schritt, den er auf dich zumacht, spürst du die Luft um dich schwerer werden.");
        Console.WriteLine("Seine Augen sind leer und doch durchdringend, als würden sie deine tiefsten Ängste lesen.");
        Console.WriteLine("Um seinen Körper winden sich lebendige Schlangen – träge, aber wachsam –, als wären sie seine Kinder, seine Gedanken, seine Strafe.");
        Console.ReadKey(true);
        Console.WriteLine("Nun steht er vor dir.");
        Console.WriteLine("Ein Wesen voller uraltem Zorn.");
        Console.WriteLine("Ein Richter mit einer Macht, die du dir kaum ausmalen kannst.");
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("= Der Kampf gegen Minos geht los =");
        int richterSpruchDamage = (int)(7 + (35 - 5) * ((double)dante.HP / dante.MaxHP));
        Ability richterSpruch = new Ability("Richterspruch", "Minos zeigt mit seiner Klauenhand auf einen Gegner – ein unsichtbares Gewicht lastet auf ihm. (Mehr schaden bei Voller HP)", targetPosition, (richterSpruchDamage, richterSpruchDamage), AbilityType.Attack, 0);
        Ability zungenurteil = new Ability("Zungenurteil", "Aus seinem Maul fährt eine peitschende, schwarze Zunge. (Stress + wenig Schaden)", targetPosition, (4, 7), AbilityType.Attack, 11);
        Ability richtHammer = new Ability("Richthammer", "Minos schwingt mit seinem Richterhammer. (Moderater Schaden)", targetPosition, (8, 11), AbilityType.Attack, 0);
        List<Ability> abilitiesMinos = new List<Ability> { richterSpruch, zungenurteil, richtHammer };
        Character minos = new Character("Minos", 200, 13, 1, abilitiesMinos, CharacterType.Boss);
        List<Character> minosReal = new List<Character> { minos };
        Fight(minosReal, dante, niederlageMinos,minosTod, minosStress);
        
        Console.WriteLine("Kaum berührt sein lebloser Körper den Boden, beginnt die Erde unter deinen Füßen zu beben.");
        Console.WriteLine("Erst ein Zittern, dann ein Dröhnen – so heftig, dass die Mauern des uralten Gemäuers zu ächzen beginnen.");
        Console.WriteLine("Risse durchziehen den Boden wie dunkle Adern, Steine lösen sich aus den Wänden und stürzen scheppernd in die Tiefe.");
        Console.ReadKey(true);
        Console.WriteLine("Du spürst, wie Panik in dir aufkeimt.");
        Console.WriteLine("„Das ganze Anwesen… es stürzt ein!“");
        Console.WriteLine("Staub wirbelt auf, du hustest, dein Blick irrt umher. Du brauchst einen Ausweg – jetzt.");
        Console.WriteLine();

        answered = false;
        do
        {
            Console.WriteLine("Was tust du?");
            Console.WriteLine("1. Versteck dich in einem aus Stein gebauten leeren Sarg.");
            Console.WriteLine("2. Renn auf die Tür hinter Minos zu.");
            answer = Console.ReadLine();
            Console.WriteLine();

            if (answer == "1" || answer == "1.")
            {
                Console.WriteLine("Du rennst, so schnell du kannst, vorbei an zerbröckelnden Säulen und stürzenden Steinen – direkt auf den steinernen Sarg zu.");
                Console.WriteLine("Ohne zu zögern wirfst du den Deckel auf, wirfst dich hinein und ziehst ihn mit zitternden Händen zu.");
                Console.WriteLine("Finsternis umhüllt dich. Nur dein Atem bleibt – flach, hektisch, begleitet vom Beben des einstürzenden Anwesens über dir.");
                Console.ReadKey(true);
                Console.WriteLine("Dann beginnt der Boden unter dir zu vibrieren. Ein feines Knacken – dann ein Riss, der sich durch das Gestein zieht.");
                Console.WriteLine("Plötzlich fühlst du es: Der Sarg fällt.");
                Console.WriteLine("Du wirst mitgerissen in die Tiefe.");
                Console.ReadKey(true);
                Console.WriteLine("Du spürst den Wind an deinem Körper, der Druck der Tiefe, die dich verschlingt.");
                Console.WriteLine("Felsen rauschen an dir vorbei, doch der Sarg schützt dich wie ein letzter Schild.");
                Console.WriteLine("Mit einem dumpfen, fast sanften Aufprall endet der Sturz.");
                Console.ReadKey(true);
                Console.WriteLine("Stille.");
                Console.WriteLine("Der Deckel kippt zur Seite.");
                Console.WriteLine("Du richtest dich auf – benommen, aber unverletzt.");
                Console.ReadKey(true);
                Console.WriteLine("Als du dich umsiehst, erkennst du es sofort:");
                Console.WriteLine("Dies ist nicht mehr das zerfallene Gemäuer von Minos. Der Himmel ist grau und ruhelos, die Luft schwer von Bedeutung.");
                Console.WriteLine("Du bist weiter unten. Viel weiter.");
                Console.ReadKey(true);
                Console.WriteLine("Der nächste Kreis.");
                Console.WriteLine("Ein flaches, weites Land liegt vor dir. Nebel kriecht über den Boden.");
                Console.WriteLine("In der Ferne erkennst du Silhouetten – viele, stumm, bleich, langsam wandelnd.");
                Console.ReadKey(true);
                Console.WriteLine("Virgil steht einige Schritte entfernt und blickt dich ruhig an.");
                Console.WriteLine("„Willkommen im zweiten Kreis. Lust..“");
                answered = true;
            }
            else if (answer == "2" || answer == "2.")
            {
                Console.WriteLine("Du stürzt los – dein Blick fixiert die Tür hinter Minos’ lebloser Gestalt.");
                Console.WriteLine("Da muss doch ein Ausgang sein, hoffst du fieberhaft.");
                Console.WriteLine("Du erreichst die Tür, wirfst dich dagegen, rüttelst mit aller Kraft daran – aber sie bleibt verschlossen. Kein Spalt, kein Nachgeben.");
                Console.ReadKey(true);
                Console.WriteLine("Mit zitternden Fingern tastest du die Wände ab, suchst panisch nach einem anderen Ausweg. Doch es ist zu spät.");
                Console.WriteLine("Ein tiefes Grollen durchdringt den Boden – dann bricht er unter dir ein.");
                Console.WriteLine("Du fällst. Schwerelos. Zeitlos.");
                Console.ReadKey(true);
                Console.WriteLine("Keine vier Sekunden – und doch scheint es eine Ewigkeit zu sein.");
                Console.WriteLine("Mit einem dumpfen Aufprall triffst du auf festen Untergrund.");
                Console.WriteLine("Du lebst.");
                Console.ReadKey(true);
                Console.WriteLine("Atem flackert durch deine Lungen. Dein ganzer Körper schmerzt, als würdest du innerlich zerschlagen – aber du kannst dich bewegen.");
                Console.WriteLine("(Du erleidest 10 Schaden.)");
                dante.HP -= 10;
                Console.WriteLine("Langsam richtest du dich auf und blickst dich um.");
                Console.ReadKey(true);
                Console.WriteLine("Dies ist nicht mehr Minos’ Gemäuer.");
                Console.WriteLine("Der Himmel ist bleiern und bewegt sich kaum – grau, schwer und von gespenstischer Ruhe.");
                Console.WriteLine("Du bist tiefer gefallen. Viel tiefer.");
                Console.ReadKey(true);
                Console.WriteLine("Ein weites, flaches Land liegt vor dir, überzogen von fahlem Nebel, der sich über den Boden schleicht wie verlorene Gedanken.");
                Console.WriteLine("In der Ferne erkennst du schemenhafte Gestalten – bleich, langsam, schweigend.");
                Console.WriteLine("Ein vertrauter Schatten tritt aus dem Dunst.");
                Console.ReadKey(true);
                Console.WriteLine("Virgil.");
                Console.WriteLine("Er blickt dich mit ruhigem Ernst an.");
                Console.WriteLine("„Willkommen im zweiten Kreis. Lust.“");
                Console.ReadKey(true);
                answered = true;
            }
            else
            {
                Console.WriteLine("Ungültige Wahl. Bitte wähle 1 oder 2.");
            }
        } while (!answered);
        
        Console.WriteLine();
        Console.WriteLine("Kapitel 3: Lust");
        Console.WriteLine("-----------------");
        Console.ReadKey(true);
        Console.WriteLine();
        Console.WriteLine("Ein kalter Wind zieht auf – plötzlich und voller Verlangen. Er trägt kein Leben in sich, nur flüsternde Stimmen, verhallte Seufzer, gebrochene Schwüre.");
        Console.WriteLine("Du folgst Virgil durch die dichten Nebel, bis sich das graue Land langsam verändert. Die Ebene weicht steinernen Mauern, zerfetzen Tüchern, zerbrochenen Statuen von Liebenden in ewiger Umarmung – oder Trennung. Der Boden ist unruhig, als würde er atmen. Oder beben.");
        Console.WriteLine("Und dann hörst du es: das Heulen.");
        Console.ReadKey(true);
        Console.WriteLine("Nicht tierisch. Menschlich. Roh. Lust, Schmerz und Verzweifnung in einem einzigen Laut, der aus allen Richtungen kommt. Über dir wirbelt der Wind stärker – und du erkennst Gestalten, die durch die Luft geschleudert werden, von einem Sturm, der niemals endet. Liebende, verdammt, für ihre Begierden für alle Zeit voneinander getrennt zu sein.");
        Console.WriteLine("Virgil bleibt stehen.");
        Console.WriteLine("„Dies ist der Ort derer, die sich der Leidenschaft mehr hingaben als der Vernunft. Der Sturm reißt sie auseinander, wie einst ihr Begehren sie verband.“");
        Console.ReadKey(true);
        Console.WriteLine("Du schluckst schwer. Der Wind zerrt bereits an deinem Mantel.");
        Console.WriteLine("Dies ist kein Ort für Zweifel – und doch flüstert etwas in deinem Inneren: Was wärst du bereit zu tun… um Beatrice wieder in deinen Armen zu halten?");
        Console.WriteLine();

        answered = false;
        do
        {
            Console.WriteLine("Was willst du tun?");
            Console.WriteLine("1. „Ich folge dem Pfad in die Tiefe.“");
            Console.WriteLine("2. „Ich gehe nicht weiter. Ich suche einen anderen Weg.“");
            answer = Console.ReadLine();
            Console.WriteLine();

            if (answer == "1" || answer == "1.")
            {
                Console.WriteLine("Du trittst weiter. Der Wind weht wie das Flüstern ungezählter Lippen über die Ebene, der Nebel kriecht wie atmende Haut um deine Beine. Virgil bleibt hinter dir, seine Silhouette verschmilzt mit dem Grau.");
                Console.WriteLine("Vor dir liegt ein schmaler Steg aus morschem Holz, der sich in eine dunkle Schlucht zieht. Jeder Schritt hallt durch die Leere. Der Sturm wird stärker – warm, fast lebendig, wie ein Atem. Du hörst kein Brüllen, sondern Seufzer… Lust… Qual.");
                Console.WriteLine("Du zögerst. Etwas an diesem Wind schreckt dich ab. Ein Teil von dir will zurück – doch du zwingst dich, weiterzugehen.");
                Console.ReadKey(true);
                Console.WriteLine("Da – eine Gestalt schlägt wie vom Himmel gefallen auf den Steg. Weiblich. Nackt. Blass. Ihre Augen durchbohren dich mit tiefer Sehnsucht, die an deine eigenen Gedanken rührt.");
                Console.WriteLine("Ein Schattenwesen. Die Verlorene Versuchung.");
                Console.WriteLine("Sie spricht nicht. Doch du fühlst, was sie will.");
                Console.ReadKey(true);
                Console.WriteLine("= Kampf gegen die Verlorene Versuchung =");
                List<Character> verloreneVersuchung = new List<Character> { VerloreneVersuchung() };
                Fight(verloreneVersuchung, dante, niederlageVerloreneVerlockung, verloreneVerlockungTod, verloreneVersuchungStress);
                Console.WriteLine("Du gehst weiter. Doch dann, als du fast das Plateau erreichst, stürzt ein Felsbrocken vor dir herab – der Weg ist blockiert.");
                Console.WriteLine("Verflucht.");
                Console.ReadKey(true);
                Console.WriteLine("Du wendest dich zurück und entdeckst am Rand der Klippe etwas, das du vorher nicht bemerkt hast: eine fast überwucherte Felsöffnung, verborgen unter totem Efeu und versandeten Statuen. Dahinter – ein schmaler, kaum begehbarer Pfad, der sich in den Fels schraubt.");
                Console.WriteLine("Mit pochendem Herzen folgst du ihm. Die Luft verändert sich. Warm. Schwer. Duftend. Die Stimmen verstummen. Stattdessen Stille – und eine Präsenz.");
                Console.WriteLine("In einer natürlichen Grotte, halb aus Fels, halb aus uraltem Marmor gehauen, sitzt eine gefesselte Frau auf einem Thron. Ihre Ketten bestehen aus Licht und Schmerz zugleich. Die Wände erzählen Geschichten in verblassten Fresken – Götter, Begierde, verbotene Liebe.");
                Console.ReadKey(true);
                answered = true;
            }
            else if (answer == "2" || answer == "2.")
            {
                Console.WriteLine("Der Sturm ist zu stark. Etwas daran schreckt dich ab – nicht nur körperlich. Es liegt ein Bann auf diesem Wind, der mehr mit sich trägt als nur Staub.");
                Console.WriteLine("Du beginnst, den Klippenrand abzusuchen. Und tatsächlich – verborgen unter Efeu und zerfallenen Statuen findest du einen engen Pfad, der sich an der Felswand entlangwindet.");
                Console.WriteLine("Du folgst ihm, tief in eine Felsspalte hinein. Die Luft wird stickig, warm – der Sturm ist nicht mehr zu hören.");
                Console.ReadKey(true);
                Console.WriteLine("Im Inneren: eine alte Grotte. An den Wänden hängen verblasste Fresken von Göttern der Liebe und Lust.");
                Console.WriteLine("In der Mitte der Höhle sitzt eine Gestalt auf einem steinernen Thron – in Ketten, die aus Licht bestehen.");
                Console.ReadKey(true);
                answered = true;
            }
            else
            {
                Console.WriteLine("Ungültige Wahl. Bitte wähle 1 oder 2.");
            }
        } while (!answered);
        
        Console.WriteLine("Die Gebundene Muse:");
        Console.WriteLine("Einst eine Inspirationsquelle für Dichter, nun verflucht, weil sie den Menschen zu viel Lust und Begehren offenbarte.");
        Console.WriteLine();

        answered = false;
        string answer2 = "";
        do
        {
            Console.WriteLine("Was willst du tun?");
            Console.WriteLine("1. Mit ihr sprechen – sie kennt den Pfad durch den Kreis, verlangt aber eine Gegenleistung.");
            Console.WriteLine("2. Sie befreien – was Risiken birgt.");
            Console.WriteLine("3. Sie zurücklassen – und vielleicht den Zorn des Kreises auf dich ziehen.");
            answer = Console.ReadLine();
            Console.WriteLine();
            if (answer == "1" || answer == "1.")
            {
                Console.WriteLine("Du trittst näher. Die Ketten der Muse schimmern und pulsieren.");
                Console.WriteLine("„Du suchst den Weg, Sterblicher? Ich kenne ihn. Aber Wissen hat seinen Preis.“");
                Console.WriteLine("Sie verlangt, dass du ihr einen Teil deiner eigenen Erinnerungen an Beatrice gibst, um den Weg zu offenbaren. Dies würde deine Bindung an Beatrice schwächen, aber den Weg ebnen.");
                Console.WriteLine();
                bool answered2 = false;
                do
                {
                    Console.WriteLine("Was tust du? (annehmen/ablehnen)");
                    answer2 = Console.ReadLine();
                    Console.WriteLine();

                    if (answer2 == "annehmen")
                    {
                        Console.WriteLine("Du schließt die Augen und konzentrierst dich auf deine Erinnerungen an Beatrice.");
                        Console.WriteLine("Ein Teil von dir zögert, doch der Wunsch, sie zu retten, ist größer.");
                        Console.WriteLine("Du spürst, wie eine Welle der Wärme von dir weicht, als die Muse ihre Hand ausstreckt und etwas aus deinem Geist zieht.");
                        Console.ReadKey(true);
                        Console.WriteLine("„Der Pfad liegt jenseits des großen Wächters… doch es gibt einen schmalen Seitengang, wenn dein Blick klar ist.“");
                        Console.WriteLine("(+1 Treffsicherheit, Muse gibt Hinweis auf Abkürzung)");
                        Console.ReadKey(true);
                        dante.Accuracy += 1;
                        answered2 = true;
                    }
                    else if (answer2 == "ablehnen")
                    {
                        Console.WriteLine("Du schüttelst den Kopf. „Ich werde meine Erinnerungen nicht opfern. Beatrice ist es wert, dass ich den schwierigeren Weg gehe.“");
                        Console.WriteLine("Die Muse lächelt traurig. „Dann sei es so, Wanderer. Mögen deine Erinnerungen dich leiten.“");
                        Console.ReadKey(true);
                        answered2 = true;
                    }
                    else
                    {
                        Console.WriteLine("Ungültige Eingabe. Bitte gib \"annehmen\" oder \"ablehnen\" ein.");
                    }
                } while (!answered2);

                answered = true;
            }
            else if (answer == "2" || answer == "2.")
            {
                Console.WriteLine("Du versuchst, die leuchtenden Ketten der Muse zu berühren. Ein stechender Schmerz durchfährt deine Hand, doch du hältst stand.");
                Console.WriteLine("Mit einem Aufschrei zersplittern die Lichtketten. Die Muse steht auf, ihre Augen leuchten vor Dankbarkeit – und einem Funken dunkler Macht.");
                Console.WriteLine("„Du wagst es, mich zu befreien? Eine mutige, aber törichte Tat. Doch deine Entschlossenheit ist rein. Ich gewähre dir, was ich kann.“");
                Console.WriteLine("(Du erleidest 10 Schaden, +1 Treffsicherheit durch göttlichen Segen)");
                Console.ReadKey(true);
                dante.HP -= 10;
                dante.Accuracy += 1;
                answered = true;
            }
            else if (answer == "3" || answer == "3.")
            {
                answered = true;
            }
            else
            {
                Console.WriteLine("Ungültige Wahl. Bitte wähle 1, 2 oder 3.");
            }
        } while (!answered);

        if (answer2 == "annehmen")
        {
            Console.WriteLine("Du folgst dem Hinweis der Muse und entdeckst einen verborgenen Riss in der Felswand.");
            Console.WriteLine("Der Spalt ist eng, dunkel und feucht – doch hierher dringen weder Wind noch die unheilvollen Schreie, die du zuvor vernommen hast.");
            Console.WriteLine("Nach einiger Zeit des Kriechens und Kletterns öffnet sich der Gang zu einem weiteren Durchlass.");
            Console.ReadKey(true);
        }
        else
        {
            Console.WriteLine("Du spürst, dass du hier nichts finden wirst, oder dass die Risiken zu groß sind.");
            Console.WriteLine("Mit einem letzten Blick auf die gefesselte Muse drehst du dich um und verlässt die Grotte.");
            Console.WriteLine("Ein kalter Hauch des Zorns scheint dir zu folgen.");
            Console.ReadKey(true);
            Console.WriteLine("etwas verändert sich.");
            Console.WriteLine("Der Boden bebt leicht. Der Nebel reißt auf. Der warme, stöhnende Wind wird zum peitschenden Sturm.");
            Console.WriteLine("Du hörst Flügelschläge.");
            Console.ReadKey(true);
            Console.WriteLine("Nicht weit entfernt erhebt sich aus einer Schlucht ein gewaltiger, humanoider Schatten mit geblähten Flügeln aus Haut und Rauch – gezeichnet von Narben, mit einem Blick, der tiefer reicht als Begierde.");
            Console.WriteLine("Er ist keine Erscheinung. Kein Geist. Kein Verführer.");
            Console.WriteLine("Er ist der Wächter dieses Kreises.");
            Console.ReadKey(true);
            Console.WriteLine("Karontheus, der Herr der Verlorenen Leidenschaften");
            Console.WriteLine("Einst ein Engel der Schönheit, jetzt verzerrt durch die Lust der Menschheit. Er trägt Ketten wie Schmuck, seine Worte reißen alte Wunden auf:");
            Console.WriteLine("„Du willst weiter? Dann zeige mir, wie stark dein Wille ist. Oder geh unter im Sturm der Sehnsucht!“");
            Console.WriteLine();
            Console.WriteLine("= Bosskampf: Karontheus =");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            List<Character> karontheus = new List<Character> { Karontheus() };
            Fight(karontheus, dante, niederlageKarontheus, karontheusTod, karontheusStress);
            Console.WriteLine("Der Boden beginnt zu beben. Der Sturm fällt in sich zusammen.");
            Console.WriteLine("Noch einmal spricht er:");
            Console.WriteLine("„Dein Herz… ist rein genug, um weiterzugehen. Doch die Tiefe wird dich mehr kosten, als du ahnst.“");
            Console.ReadKey(true);
            Console.WriteLine("Hinter seinem zerschlagenen Leib öffnet sich ein uraltes, kreisrundes Portal aus Marmor, umwoben mit Symbolen von Venus, Eros – und Schmerz.");
            Console.WriteLine("Ein gewaltiger Sog zieht dich hinein.");
            Console.WriteLine("Virgil tritt neben dich.");
            Console.ReadKey(true);
            Console.WriteLine("„Bereit für die Gier?“");
            Console.WriteLine("Dann:");
            Console.WriteLine("Schwarz.");
            Console.ReadKey(true);
        }
        Console.WriteLine();
        Console.WriteLine("Kapitel 4: Gier");
        Console.WriteLine("-----------------");
        Console.ReadKey(true);
        Console.WriteLine();

        Console.WriteLine("Dunkelheit umhüllt dich, schwer wie Blei.");
        Console.WriteLine("Ein Gefühl von Sog, von Enge – du fällst nicht, du wirst gezogen.");
        Console.WriteLine("Als deine Füße wieder Boden spüren, riechst du es sofort:");
        Console.ReadKey(true);
        Console.WriteLine("Altes Eisen. Modernde Münzen.");
        Console.WriteLine("Der Gestank von kaltem Schweiß, verbrannter Haut und altem Papier.");
        Console.WriteLine("Langsam öffnest du die Augen.");
        Console.ReadKey(true);
        Console.WriteLine("Du stehst in einem riesigen Höhlensystem, dessen Wände aus Goldadern bestehen.");
        Console.WriteLine("Überall glitzert es. Doch es ist kein Glanz des Lebens. Es ist der Glanz der Gier – stumpf, kalt, besitzergreifend.");
        Console.WriteLine("In der Ferne hörst du Hämmern.");
        Console.ReadKey(true);
        Console.WriteLine("Zugriffe. Kreischen.");
        Console.WriteLine("Die Gequälten dieses Kreises sind verdammt, unablässig Reichtum zu schürfen, den sie niemals besitzen dürfen.");
        Console.WriteLine("Virgil steht neben dir.");
        Console.ReadKey(true);
        Console.WriteLine("Sein Blick ist hart, seine Stimme ruhiger denn je:");
        Console.WriteLine("„Die Seelen hier haben sich dem Besitzen verschrieben – Gold, Einfluss, Macht.");
        Console.WriteLine("Jetzt besitzen sie nichts… außer ihrer ewigen Habgier.“");
        Console.ReadKey(true);
        Console.WriteLine("Du erkennst nun:");
        Console.WriteLine("Zwischen den Gängen und Felsen kriechen Menschen mit goldenen Masken, klammern sich an Erzbrocken, beißen in Steine, prügeln sich um rostige Ringe.");
        Console.WriteLine("Sie bemerken dich kaum. Ihr Blick ist leer, ihr Wunsch ewig.");
        Console.WriteLine();
        Console.ReadKey(true);

        answered = false;
        do
        {
            Console.WriteLine("Was willst du tun?");
            Console.WriteLine("1. „Ich will wissen, was sie dazu getrieben hat…“");
            Console.WriteLine("2. „Wo ist der Ausgang? Ich will hier so schnell wie möglich weg.“");
            answer = Console.ReadLine();
            Console.WriteLine();

            if (answer == "1" || answer == "1.")
            {
                Console.WriteLine("Du näherst dich einem der Gierigen und versuchst, mit ihm zu sprechen.");
                Console.WriteLine("Danke für das Spielen der Demo!");
                answered = true;
            }
            else if (answer == "2" || answer == "2.")
            {
                Console.WriteLine("Du gehst weiter durch die Tunnel – direkt Richtung Boss.");
                Console.WriteLine("Danke für das Spielen der Demo!");
                answered = true;
            }
            else
            {
                Console.WriteLine("Ungültige Wahl. Bitte wähle 1 oder 2.");
            }
        } while (!answered);

    }

    //Define ability(Name, Description, TargetPositions, MinPower, MaxPower, Type, StressEffect, BuffType).
    // Character: char(Name, HP, MaxHP, ArmorClass, Position, Abilities, Stress, Accuracy, DamageMod, StressMod, CharacterType).
    private static Character KreaturDerHoffnungslosigkeit()
    {
        List<int> targetPosition = new List<int> { 1, 2 };
        Ability modernderGriff = new Ability("modernderGriff", "Ein kalter Griff, der dir Lebensenergie entzieht. (Moderater Schaden)", targetPosition, (8,15), AbilityType.Attack,  10);
        Ability atemDerVerzweiflung = new Ability("Atem der Verzweiflung", "Ein Nebel des Zweifels umhüllt dich. (Geringer Schaden, hoher Stress)", targetPosition, (3,7), AbilityType.Heal, 25);
        List<Ability> abilities = new List<Ability> { modernderGriff, atemDerVerzweiflung };
        return new Character("Kreatur der Hoffnungslosigkeit", 60, 10, 1, abilities, CharacterType.Enemy);
    }

    private static Character VerloreneVersuchung()
    {
        List<int> targetPosition = new List<int> { 1, 2 };
        Ability verlockenderBlick = new Ability("Verlockender Blick", "Ein Blick, der deine Entschlossenheit schwächt. (Geringer Schaden, Stress)", targetPosition, (5,10), AbilityType.Attack,  15);
        Ability kussDerSehnsucht = new Ability("Kuss der Sehnsucht", "Ein Hauch, der dich nach dem Vergangenen sehnen lässt. (Debuff: Genauigkeit)", targetPosition, (1,1), AbilityType.Debuff, 0, BuffType.Accuracy);
        List<Ability> abilities = new List<Ability> { verlockenderBlick, kussDerSehnsucht };
        return new Character("Verlorene Versuchung", 80, 11, 1, abilities, CharacterType.Enemy);
    }

    private static Character Karontheus()
    {
        List<int> targetPosition = new List<int> { 1, 2 };
        Ability sturmDerSehnsucht = new Ability("Sturm der Sehnsucht", "Ein Wirbelwind aus zerbrochenen Träumen. (Hoher Schaden, hoher Stress)", targetPosition, (15,20), AbilityType.Attack,  35);
        Ability peitscheDerBegierde = new Ability("Peitsche der Begierde", "Eine Kette aus Leiden schlägt nach dir. (Moderater Schaden, Debuff: Rüstung)", targetPosition, (10,15), AbilityType.Debuff, 10, BuffType.Armor);
        Ability verloreneSchoenheit = new Ability("Verlorene Schönheit", "Karontheus besinnt sich auf seine einstige Schönheit und heilt sich. (Buff: Heilung)", targetPosition, (5,12), AbilityType.Heal, 0);
        List<Ability> abilities = new List<Ability> { sturmDerSehnsucht, peitscheDerBegierde, verloreneSchoenheit };
        return new Character("Karontheus", 250, 13, 1, abilities, CharacterType.Boss);
    }

    private static int Roll(int min, int max)
    {
        Random rnd = new Random();
        return rnd.Next(min, max + 1);
    }

    private static void TextOutput(string[] text)
    {
        foreach (string zeile in text)
        {
            Console.WriteLine(zeile);
        }
    }
    
    private static void Fight(List<Character> enemies, Character dante, string[] death, string[] enemyDeath, string[] stressText)
    {
        List<Character> allParticipants = new List<Character>(enemies);
        allParticipants.Add(dante);

        // Initiative bestimmen
        foreach (var character in allParticipants)
        {
            character.Initiative = Roll(1, 20);
        }

        // Nach Initiative sortieren (höchste zuerst)
        allParticipants = allParticipants.OrderByDescending(c => c.Initiative).ToList();

        bool isFinished = false;

        while (!isFinished)
        {
            foreach (var current in allParticipants.ToList())
            {
                if (dante.HP <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    TextOutput(death);
                    Console.ResetColor();
                    Environment.Exit(0);
                }

                if (enemies.All(e => e.HP <= 0))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    TextOutput(enemyDeath);
                    Console.ResetColor();
                    dante.Stress = 0;
                    return;
                }

                if (current.HP <= 0) continue;

                if (current == dante)
                {
                    PlayerTurn(dante, enemies, stressText);
                }
                else
                {
                    if (current.Stress >= 100)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        TextOutput(stressText);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Ein Urteil naht.");
                        Console.ResetColor();
                        Console.ReadKey(true);
                        current.StressOut();
                        Console.ReadKey(true);
                    }

                    // Angriff auf Dante
                    Attack(current, dante);
                }
            }
        }
    }
    
    private static void PlayerTurn(Character dante, List<Character> enemies, string[] stressText)
{
    Console.WriteLine();
    Console.WriteLine($"[Deine Position: {dante.Position} | HP: {dante.HP}/{dante.MaxHP} | Accuracy: {dante.Accuracy} | Stress: {dante.Stress} | DmgMod: {dante.DamageMod} | StressMod: {dante.StressMod}]");
    Console.WriteLine("Was willst du tun?");
    for (int i = 0; i < dante.Abilities.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {dante.Abilities[i].Name}");
    }
    Console.WriteLine($"{dante.Abilities.Count() + 1}. Spell Informations");

    int playerInput = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine();

    if (playerInput == dante.Abilities.Count() + 1)
    {
        for (int i = 0; i < dante.Abilities.Count; i++)
        {
            if (dante.Abilities[i].Type == AbilityType.Attack)
                Console.ForegroundColor = ConsoleColor.Red;
            else if (dante.Abilities[i].Type == AbilityType.Buff)
                Console.ForegroundColor = ConsoleColor.Blue;
            else if (dante.Abilities[i].Type == AbilityType.Heal)
                Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine($"{i + 1}. {dante.Abilities[i].Name}: {dante.Abilities[i].Description}");
            Console.ResetColor();
        }

        Console.WriteLine();
    }
    else
    {
        Ability chosen = dante.Abilities[playerInput - 1];

        Character target = null;
        if (chosen.Type == AbilityType.Attack)
        {
            Console.WriteLine("Wähle ein Ziel:");
            for (int i = 0; i < enemies.Count; i++)
            {
                if (enemies[i].HP > 0)
                    Console.WriteLine($"{i + 1}. {enemies[i].Name} (HP: {enemies[i].HP})");
            }

            int targetIndex = Convert.ToInt32(Console.ReadLine()) - 1;
            target = enemies[targetIndex];
        }

        dante.Abilities[playerInput - 1].Use(dante, target ?? dante, chosen.Type, true);
    }

    if (dante.Stress >= 100)
    {
        Console.WriteLine("Dantes Atem geht flach... Ein Urteil naht.");
        dante.StressOut();
    }
}



    /*private static void Fight(List<Character> enemies, Character dante, string[] death, string[] enemyDeath, string[] stressText)
{
    int initPlayer = Roll(1, 20);
    int initEnemy = Roll(1, 20);
    int order = initPlayer > initEnemy ? 1 : 2;

    Console.WriteLine($"Du bist als {(order == 1 ? "Erster" : "Zweiter")} an der Reihe.");
    Console.WriteLine();
    bool isFinished = false;

    if (order == 2)
    {
        foreach (var enemy in enemies.Where(e => e.HP > 0))
        {
            Attack(enemy, dante);
        }
    }

    do
    {
        try
        {
            if (dante.HP > 0)
            {
                if (dante.Stress >= 100)
                {
                    Console.WriteLine("Dantes Atem geht flach, Schweiß glänzt auf seiner Stirn. Die Schatten in seinem Blick tanzen wild – Gedanken an Hoffnung schwinden.");
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ein Urteil naht.");
                    Console.ResetColor();
                    Console.ReadKey(true);
                    dante.StressOut();
                    Console.ReadKey(true);
                }

                Console.WriteLine();
                Console.WriteLine($"[Deine Position: {dante.Position} | HP: {dante.HP}/{dante.MaxHP} | Accuracy: {dante.Accuracy} | Stress: {dante.Stress} | DmgMod: {dante.DamageMod} | StressMod: {dante.StressMod}]");
                Console.WriteLine();
                Console.WriteLine("Was willst du tun?");
                for (int i = 0; i < dante.Abilities.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {dante.Abilities[i].Name}");
                }

                Console.WriteLine($"{dante.Abilities.Count + 1}. Spell Informations");
                Console.WriteLine();

                int playerInput = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();

                if (playerInput == dante.Abilities.Count + 1)
                {
                    for (int i = 0; i < dante.Abilities.Count; i++)
                    {
                        var ability = dante.Abilities[i];
                        if (ability.Type == AbilityType.Attack) Console.ForegroundColor = ConsoleColor.Red;
                        else if (ability.Type == AbilityType.Buff) Console.ForegroundColor = ConsoleColor.Blue;
                        else if (ability.Type == AbilityType.Heal) Console.ForegroundColor = ConsoleColor.Green;

                        Console.WriteLine($"{i + 1}. {ability.Name}: {ability.Description}");
                        Console.ResetColor();
                    }
                    Console.WriteLine();
                }
                else
                {
                    var selectedAbility = dante.Abilities[playerInput - 1];

                    // Zielauswahl (außer Buffs/Heals auf sich selbst)
                    Character target = dante;
                    if (selectedAbility.Type == AbilityType.Attack)
                    {
                        Console.WriteLine("Wähle ein Ziel:");
                        for (int i = 0; i < enemies.Count; i++)
                        {
                            if (enemies[i].HP > 0)
                                Console.WriteLine($"{i + 1}. {enemies[i].Name} [Pos: {enemies[i].Position} | HP: {enemies[i].HP}]");
                        }

                        int targetIndex = Convert.ToInt32(Console.ReadLine()) - 1;
                        target = enemies[targetIndex];
                    }

                    selectedAbility.Use(dante, target, selectedAbility.Type, true);

                    // Gegnerzug
                    foreach (var enemy in enemies.Where(e => e.HP > 0))
                    {
                        if (enemy.Stress >= 100)
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            TextOutput(stressText);
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Ein Urteil naht.");
                            Console.ResetColor();
                            Console.WriteLine();
                            Console.ReadKey(true);
                            enemy.StressOut();
                            Console.ReadKey(true);
                        }

                        Attack(enemy, dante);
                    }

                    // Siegbedingung
                    if (enemies.All(e => e.HP <= 0))
                    {
                        isFinished = true;
                        Console.ForegroundColor = ConsoleColor.Green;
                        TextOutput(enemyDeath);
                        Console.ResetColor();
                        dante.Stress = 0;
                    }
                }
            }
            else
            {
                isFinished = true;
                Console.ForegroundColor = ConsoleColor.Red;
                TextOutput(death);
                Console.ReadKey(true);
                Environment.Exit(0);
            }
        }
        catch (Exception)
        {
            Console.WriteLine($"Bitte gib eine gültige Zahl ein (1–{dante.Abilities.Count})!");
        }
    } while (!isFinished);
}*/


    public static void Attack(Character Enemy, Character Player)
    {
        int getAttack = Ability.Roll(1, Enemy.Abilities.Count());
        int damage;
        int stress;

        PhraseManager mngr = new PhraseManager();

        Console.Write($"{mngr.GetAttack(Enemy)}");
        
        int attackRoll = Ability.Roll(1, 21);
        
        if (attackRoll >= Player.ArmorClass)
        {
            damage = Ability.Roll(Enemy.Abilities[getAttack].PowerRange.min, Enemy.Abilities[getAttack].PowerRange.max);
            stress = Enemy.Abilities[getAttack].StressEffect;

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