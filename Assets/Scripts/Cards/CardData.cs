using UnityEngine;

[CreateAssetMenu(fileName = "CardData", menuName = "CardGame/Card")]
public class CardData : ScriptableObject
{
    public string cardName;
    public Sprite artwork;
    public int cost;
    public string description;
}
