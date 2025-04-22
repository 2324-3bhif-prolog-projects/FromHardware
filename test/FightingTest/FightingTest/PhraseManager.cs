namespace FightingTest;

public class PhraseManager
{
    private Random rnd = new Random();

    private string[] hpHigh = {
        "Der Gegner wirkt selbstsicher und unbeeindruckt.",
        "Seine Haltung ist aufrecht – der Kampf hat noch kaum begonnen.",
        "Lachend fragt Minos dich „War das alles was du hast?“",
        "Minos steht gähnend vor dir."
    };

    private string[] hpMid = {
        "Blut tropft auf den Boden.",
        "Er beginnt zu schwanken, doch sein Blick bleibt entschlossen.",
        "Seine Bewegungen wirken langsamer."
    };

    private string[] hpLow = {
        "Er taumelt und kann kaum noch stehen.",
        "Sein Körper zittert.",
        "Blut spritzt aus sämtlichen Körperstellen.",
        "Minos' Kinn sieht verschoben und gebrochen aus.",
        "Er wirkt wie eine Hülle seiner selbst.",
        "Er röchelt, sein Blick verschwimmt.",
        "Sein Körper ist zerfetzt, sein Wille bricht – doch noch lebt er."
    };

    public string GetHPPhrase(int currentHP, int maxHP)
    {
        double percent = (double)currentHP / maxHP * 100;

        if (percent > 70)
            return hpHigh[rnd.Next(hpHigh.Length)];
        else if (percent > 40)
            return hpMid[rnd.Next(hpMid.Length)];
        else
            return hpLow[rnd.Next(hpLow.Length)];
    }
}