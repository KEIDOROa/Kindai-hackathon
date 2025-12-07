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
        // 必要な参照がすべて設定されているか確認
        if (hpManager == null)
        {
            Debug.LogError("[HeartDisplay] HPManager が設定されていません。");
            enabled = false;
            return;
        }
        if (heartPrefab == null)
        {
            Debug.LogError("[HeartDisplay] Heart Prefab が設定されていません。");
            enabled = false;
            return;
        }
        if (heartContainer == null)
        {
            Debug.LogError("[HeartDisplay] Heart Container が設定されていません。");
            enabled = false;
            return;
        }
        if (fullHeartSprite == null || emptyHeartSprite == null)
        {
            Debug.LogError("[HeartDisplay] ハート用スプライトが設定されていません。");
            enabled = false;
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
                Debug.LogError("[HeartDisplay] Heart prefab に Image コンポーネントがありません。");
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
        // 安全チェック：heartImages が null の場合は何もしない
        if (heartImages == null) return;
        
        // 安全チェック：hpManager が null の場合は何もしない
        if (hpManager == null) return;

        int currentHP = hpManager.CurrentHP;
        for (int i = 0; i < heartImages.Length; i++)
        {
            // 安全チェック：heartImages[i] が null の場合はスキップ
            if (heartImages[i] == null) continue;
            
            heartImages[i].sprite = i < currentHP ? fullHeartSprite : emptyHeartSprite;
        }
    }
}
