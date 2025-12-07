using UnityEngine;



[CreateAssetMenu(fileName = "CardData", menuName = "CardData")]
public class CardData : ScriptableObject
{
    public string cardName;
    public Sprite cardImage;
    public CardType cardType;
    [Header("見たら死ぬ回数")]
    public int deathCount = 0;
    [Header("山札に用意する枚数")]
    public int initialCount = 1;
}
