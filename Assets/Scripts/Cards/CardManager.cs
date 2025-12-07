using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    public List<CardData> cardDatabase;  // ScriptableObject のリスト
    public List<Card> deck = new List<Card>();

    void Start()
    {
        deck.Clear();

        // ScriptableObjectからゲーム用カードインスタンスを生成
        foreach (var data in cardDatabase)
        {
            for (int i = 0; i < data.initialCount; i++)
            {
                deck.Add(new Card(data));
            }
        }
        Debug.Log($"Deck generated: {deck.Count} cards");
    }

    //public void PlayerViewCard(Player player, Card card)
    //{
        //card.View();

        //if (card.IsDanger())
        //{
        //    // ライフダメージ
        //    player.Damage(1);

        //    Debug.Log($"{player.Name} saw forbidden card {card.data.cardName}! life -1");

        //    // カウンターリセットするならこちらで
        //    card.currentViewCount = 0;
        //}
        //else
        //{
        //    Debug.Log($"{player.Name} viewed {card.data.cardName}");
        //}
    //}
}
