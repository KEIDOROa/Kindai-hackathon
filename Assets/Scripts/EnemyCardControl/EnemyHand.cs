using System.Collections.Generic;
using UnityEngine;

public class EnemyHand : MonoBehaviour
{
    private readonly List<Card> hand = new List<Card>();

    public IReadOnlyList<Card> Cards => hand;
    public int Count => hand.Count;

    public bool TryAdd(Card card)
    {
        if (card == null)
        {
            Debug.LogWarning("Tried to add a null card to the enemy hand.");
            return false;
        }

        hand.Add(card);
        return true;
    }

    public bool TryRemove(Card card)
    {
        if (card == null) return false;
        return hand.Remove(card);
    }

    public bool TryPlayCard(int index, out Card card)
    {
        card = null;
        if (index < 0 || index >= hand.Count) return false;

        card = hand[index];
        hand.RemoveAt(index);
        return true;
    }

    public Card Peek(int index)
    {
        if (index < 0 || index >= hand.Count) return null;
        return hand[index];
    }

    public void Clear()
    {
        hand.Clear();
    }
}
