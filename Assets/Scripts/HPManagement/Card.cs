using UnityEngine;

/// <summary>
/// Represents a card that inflicts damage based on its type.
/// </summary>
public class Card
{
    public enum CardType
    {
        OneView,   // 1回見たら -1 HP
        ThreeView, // 3回見たら -5 HP
        FiveView   // 5回見たら -3 HP
    }

    public CardType Type { get; private set; }
    public int Damage { get; private set; }

    public Card(CardType type)
    {
        Type = type;
        Damage = GetDamageFromType(type);
    }

    private int GetDamageFromType(CardType type)
    {
        switch (type)
        {
            case CardType.OneView:
                return 1;
            case CardType.ThreeView:
                return 5;
            case CardType.FiveView:
                return 3;
            default:
                return 0;
        }
    }
}
