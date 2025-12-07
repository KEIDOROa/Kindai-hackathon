using UnityEngine;



[CreateAssetMenu(fileName = "CardData", menuName = "CardData")]
public class CardData : ScriptableObject
{
    public string cardName;
    public Sprite cardImage;
    public CardType cardType;
    public int deathCount = 0;
}
