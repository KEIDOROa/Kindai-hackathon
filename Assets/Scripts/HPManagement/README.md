# HP 管理スクリプト

## 概要

このフォルダには、シンプルな HP 管理システムとカード定義を提供する 2 つの Unity C# スクリプトが含まれています。

- **HPManager.cs** – 最大 HP、現在 HP、ダメージ適用、回復、死亡判定、HP 変更時のログ出力を実装。
- **Card.cs** – 3 種類のカード (`OneView`, `ThreeView`, `FiveView`) とそれぞれのダメージ値を定義。

## 使い方

1. **スクリプトの配置**
   - `HPManager.cs` と `Card.cs` を `Assets/Scripts/HPManagement/` に配置します。
   - 任意の GameObject（例: `Player`）に `HPManager` コンポーネントをアタッチします。

2. **HP の設定（任意）**
   - Inspector で `Max HP` を変更可能です（デフォルトは `15`）。

3. **カードでダメージを与える例**
```csharp
// Space キーでランダムカードのダメージを適用する例
public class ExampleUsage : MonoBehaviour
{
    [SerializeField] private HPManager hpManager;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // 0=OneView, 1=ThreeView, 2=FiveView のいずれかをランダムに選択
            Card.CardType type = (Card.CardType)Random.Range(0, 3);
            Card card = new Card(type);
            hpManager.ApplyDamage(card.Damage);
            Debug.Log($"Card {card.Type} が {card.Damage} ダメージを与えました。現在 HP: {hpManager.CurrentHP}");
        }
    }
}
```

4. **回復**
```csharp
hpManager.Heal(5); // 5 HP 回復（上限は maxHP）
```

5. **ステータス確認**
- `hpManager.CurrentHP` – 現在の HP。
- `hpManager.IsDead` – HP が 0 になったら `true`。

## 動作確認

- Unity で **Play** → **Space** キーを押すと、ランダムにカードが引かれダメージが適用され、コンソールにログが出ます。
- HP が 0 未満にならず、`IsDead` が正しく `true` になることを確認してください。

## 拡張方法

- `Card.cs` に新しい `CardType` とダメージを追加できます。
- `HPManager` の `OnHPChanged` / `OnDeath` を拡張して UI 更新やエフェクトを実装してください。

---

## Overview

This folder contains two Unity C# scripts that provide a simple HP management system and card definitions for a card‑based damage mechanic.

- **HPManager.cs** – Handles max HP, current HP, damage application, healing, death detection, and logs HP changes.
- **Card.cs** – Defines three card types (`OneView`, `ThreeView`, `FiveView`) with corresponding damage values.

## How to Use

1. **Add the scripts**
   - Place the `HPManager.cs` and `Card.cs` files in `Assets/Scripts/HPManagement/`.
   - Attach the `HPManager` component to a GameObject in your scene (e.g., an empty GameObject named `Player`).

2. **Configure HP (optional)**
   - In the Inspector, you can change the `Max HP` value (default is `15`).

3. **Apply Damage via Cards**
   ```csharp
   // Example: Apply random card damage when the Space key is pressed
   public class ExampleUsage : MonoBehaviour
   {
       [SerializeField] private HPManager hpManager;

       void Update()
       {
           if (Input.GetKeyDown(KeyCode.Space))
           {
               // Randomly select a card type (0 = OneView, 1 = ThreeView, 2 = FiveView)
               Card.CardType type = (Card.CardType)Random.Range(0, 3);
               Card card = new Card(type);
               hpManager.ApplyDamage(card.Damage);
               Debug.Log($"Card {card.Type} dealt {card.Damage} damage. HP is now {hpManager.CurrentHP}.");
           }
       }
   }
   ```

4. **Healing**
   ```csharp
   hpManager.Heal(5); // Heals 5 HP, up to the max HP limit.
   ```

5. **Check Status**
   - `hpManager.CurrentHP` – Current HP value.
   - `hpManager.IsDead` – `true` if HP has reached zero.

## Verification

- Open Unity, press **Play**, and press **Space** to see random damage applied and console logs.
- Ensure the HP never drops below `0` and the `IsDead` flag becomes `true` when HP reaches `0`.

## Extending

- Add more `CardType` values and corresponding damage in `Card.cs`.
- Hook into `HPManager` events (`OnHPChanged`, `OnDeath`) to update UI or trigger effects.

---
