using UnityEngine;

public class Card : MonoBehaviour
{
    public CardData data;

    public void Initialize(CardData newData)
    {
        data = newData;
        // ここでUI更新
        GetComponent<CardUI>().UpdateUI(data);
    }
}
