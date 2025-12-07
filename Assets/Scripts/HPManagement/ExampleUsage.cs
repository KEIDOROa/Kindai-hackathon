using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// UI ボタンでカードを引き、HPManager にカード登録を行うコンポーネント。
/// Space キーは現在 HP をコンソールに表示するだけです。
/// </summary>
public class ExampleUsage : MonoBehaviour
{
    [Header("References")]
    [Tooltip("HP を管理しているコンポーネント")] public HPManager hpManager;
    [Tooltip("UI ボタン（クリックでカードを引く）")] public Button drawButton;

    void Start()
    {
        Debug.Log("[ExampleUsage] Start() が呼ばれました");
        
        // 参照チェック
        if (hpManager == null)
        {
            Debug.LogError("[ExampleUsage] HPManager が設定されていません！Inspector で設定してください。");
        }
        else
        {
            Debug.Log("[ExampleUsage] HPManager が正しく設定されています");
        }
        
        if (drawButton == null)
        {
            Debug.LogError("[ExampleUsage] Draw Button が設定されていません！Inspector で設定してください。");
        }
        else
        {
            Debug.Log("[ExampleUsage] Draw Button が正しく設定されています");
            drawButton.onClick.AddListener(() =>
            {
                Debug.Log("[ExampleUsage] UI Button がクリックされました");
                RegisterRandomCard();
            });
            Debug.Log("[ExampleUsage] ボタンのクリックイベントを登録しました");
        }
    }



    /// <summary>
    /// ボタンをクリックするたびに HP を 1 減らす。
    /// </summary>
    public void RegisterRandomCard()
    {
        // HP を 1 減らす
        hpManager.ApplyDamage(1);
        Debug.Log($"[ExampleUsage] ボタンがクリックされました → HP {hpManager.CurrentHP}");
    }
}
