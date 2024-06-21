using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlendShapeController : MonoBehaviour
{
    // 眉毛のスキンメッシュレンダラー
    public SkinnedMeshRenderer _refEyebrowsDef;

    // 目のスキンメッシュレンダラー
    public SkinnedMeshRenderer _refEyeDef;

    // 瞼のスキンメッシュレンダラー
    public SkinnedMeshRenderer _refEyelidDef;

    // 口のスキンメッシュレンダラー
    public SkinnedMeshRenderer _refMouthDef;

    // マウスホイールの感度
    public float sensitivity = 10f;

    // キーとブレンドシェイプの名前リストの辞書
    private Dictionary<KeyCode, List<(SkinnedMeshRenderer, string)>> _keyToBlendShapes;

    void Start()
    {
        _keyToBlendShapes = new Dictionary<KeyCode, List<(SkinnedMeshRenderer, string)>>();

        // 怒りの表情に対するキーとBlendShapeリストを設定
        _keyToBlendShapes.Add(KeyCode.F1, new List<(SkinnedMeshRenderer, string)>
        {
            (_refEyebrowsDef, "blendShape3.BLW_ANG1"),
            (_refEyeDef, "blendShape2.EYE_ANG1"),
            (_refEyelidDef, "blendShape2.EYE_ANG1"),
            (_refMouthDef, "blendShape1.MTH_ANG1")
        });

        // 驚きの表情に対するキーとBlendShapeリストを設定
        _keyToBlendShapes.Add(KeyCode.F2, new List<(SkinnedMeshRenderer, string)>
        {
            (_refEyebrowsDef, "blendShape3.BLW_SAP"),
            (_refEyeDef, "blendShape2.EYE_SAP"),
            (_refEyelidDef, "blendShape2.EYE_SAP"),
            (_refMouthDef, "blendShape1.MTH_SAP")
        });

        // 笑顔の表情に対するキーとBlendShapeリストを設定
        _keyToBlendShapes.Add(KeyCode.F3, new List<(SkinnedMeshRenderer, string)>
        {
            (_refEyebrowsDef, "blendShape3.BLW_SMILE1"),
            (_refEyeDef, "blendShape2.EYE_SMILE1"),
            (_refEyelidDef, "blendShape2.EYE_SMILE1"),
            (_refMouthDef, "blendShape1.MTH_SMILE1")
        });

        Debug.Log("BlendShapeController initialized.");
    }

    void Update()
    {
        // 各キーに対応するブレンドシェイプの設定をチェック
        foreach (var keyBlendShapesPair in _keyToBlendShapes)
        {
            if (Input.GetKey(keyBlendShapesPair.Key))
            {
                // マウススクロール入力を取得
                float scroll = Input.GetAxis("Mouse ScrollWheel");

                if (scroll != 0)
                {
                    // 対応するブレンドシェイプのウェイトを更新
                    foreach (var (renderer, blendShapeName) in keyBlendShapesPair.Value)
                    {
                        UpdateBlendShapeWeight(renderer, blendShapeName, scroll);
                    }
                }
            }
        }
    }

    /// <summary>
    /// ブレンドシェイプのウェイトを更新するメソッド
    /// </summary>
    /// <param name="renderer">ウェイトを更新するスキンメッシュレンダラー</param>
    /// <param name="blendShapeName">更新するブレンドシェイプの名前</param>
    /// <param name="scroll">マウスホイールのスクロール値</param>
    private void UpdateBlendShapeWeight(SkinnedMeshRenderer renderer, string blendShapeName, float scroll)
    {
        // ブレンドシェイプのインデックスを取得
        int index = renderer.sharedMesh.GetBlendShapeIndex(blendShapeName);
        if (index >= 0)
        {
            // 現在のウェイトを取得
            float currentWeight = renderer.GetBlendShapeWeight(index);
            // 新しいウェイトを計算し、クランプして設定
            float newWeight = Mathf.Clamp(currentWeight + scroll * sensitivity, 0f, 100f);
            renderer.SetBlendShapeWeight(index, newWeight);
        }
    }
}
