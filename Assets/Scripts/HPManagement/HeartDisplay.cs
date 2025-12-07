using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// HP の表示をハートの UI として管理します。
/// HPManager の現在 HP に応じてハートを満タン/空に切り替えます。
/// </summary>
public class HeartDisplay : MonoBehaviour
{
    [Header("References")]
    [Tooltip("HP を管理しているコンポーネント")] public HPManager hpManager;
    [Tooltip("ハート UI のプレファブ（Image コンポーネントを持つ GameObject）")] public GameObject heartPrefab;
    [Tooltip("ハートを配置する親オブジェクト (RectTransform)")] public Transform heartContainer;

    [Header("Sprites")]
    [Tooltip("満タンのハートスプライト")] public Sprite fullHeartSprite;
    [Tooltip("空のハートスプライト")] public Sprite emptyHeartSprite;

    // ハートの Image コンポーネントリスト
    private Image[] heartImages;

    void Start()
    {
        if (hpManager == null || heartPrefab == null || heartContainer == null || fullHeartSprite == null || emptyHeartSprite == null)
        {
            Debug.LogError("HeartDisplay: 必要な参照が設定されていません");
            return;
        }

        // 最大 HP 分だけハートを生成
        int maxHP = hpManager.MaxHP;
        heartImages = new Image[maxHP];
        for (int i = 0; i < maxHP; i++)
        {
            GameObject heartObj = Instantiate(heartPrefab, heartContainer);
            Image img = heartObj.GetComponent<Image>();
            if (img == null)
            {
                Debug.LogError("Heart prefab に Image コンポーネントがありません");
                continue;
            }
            img.sprite = fullHeartSprite;
            heartImages[i] = img;
        }
        UpdateHearts();
    }

    void Update()
    {
        // HP が変化したらハート表示を更新
        UpdateHearts();
    }

    private void UpdateHearts()
    {
        if (heartImages == null) return;
        int currentHP = hpManager.CurrentHP;
        for (int i = 0; i < heartImages.Length; i++)
        {
            heartImages[i].sprite = i < currentHP ? fullHeartSprite : emptyHeartSprite;
        }
    }
}
