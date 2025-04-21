namespace FightingTest;

public class Character
{
    public string Name { get; private set; }
    public int MaxHP { get; private set; }
    public int HP { get; set; }
    public int ArmorClass { get; set; }
    public int Stress { get; set; }
    public int Position { get; set; } // 1 = vorne, 4 = hinten
    public List<Ability> Abilities { get; private set; }
    public List<string> StatusEffects { get; private set; }
    
    public Character(string name, int maxHP, int armorClass, int position, List<Ability> abilities)
    {
        Name = name;
        MaxHP = maxHP;
        HP = maxHP;
        ArmorClass = armorClass;
        Stress = 0;
        Position = position;
        Abilities = abilities;
        StatusEffects = new List<string>();
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
}