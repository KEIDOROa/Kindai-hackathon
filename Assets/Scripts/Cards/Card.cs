public class Card
{
    public CardData data;
    public int currentViewCount = 0;

    public Card(CardData data)
    {
        this.data = data;
    }

    public bool IsDanger()
    {
        // ジョーカーだけ判定する
        if (data.cardType != CardType.Joker) return false;

        return currentViewCount >= data.deathCount;
    }

    public void View()
    {
        currentViewCount++;
    }
}
