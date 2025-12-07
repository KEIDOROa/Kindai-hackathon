using UnityEngine;
using UnityEngine.UI;

public class CardUI : MonoBehaviour
{
    public Text nameText;
    public Image artworkImage;
    public Text costText;
    public Text descText;

    public void UpdateUI(CardData data)
    {
        nameText.text = data.cardName;
        artworkImage.sprite = data.artwork;
        costText.text = data.cost.ToString();
        descText.text = data.description;
    }
}
