namespace FightingTest;

public class Ability
{
    public string Name { get; private set; }
    public List<int> UsableFrom { get; private set; }
    public List<int> TargetPositions { get; private set; }
    public (int min, int max) DamageRange { get; private set; }
    public int StressEffect { get; private set; }

    public Ability(string name, List<int> usableFrom, List<int> targetPositions, (int, int) damageRange, int stressEffect = 0)
    {
        Name = name;
        UsableFrom = usableFrom;
        TargetPositions = targetPositions;
        DamageRange = damageRange;
        StressEffect = stressEffect;
    }

    public string Use(Character user, Character target)
    {
        if (!UsableFrom.Contains(user.Position))
            return $"{Name} kann aus Position {user.Position} nicht benutzt werden.";

        Random rnd = new Random();
        int damage = rnd.Next(DamageRange.min, DamageRange.max + 1);

        target.HP -= damage;
        target.Stress += StressEffect;

        return $"{user.Name} benutzt {Name} gegen {target.Name} und verursacht {damage} Schaden!";
    }
}