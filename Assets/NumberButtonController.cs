﻿using UnityEngine;
using UnityEngine.UI;

public class NumberButtonController : MonoBehaviour
{
    public GameDirector GameDirector { get; set; }

    // ボタンに表示されるテキストと数値
    public string Text { get; private set; }
    public int Number { get; private set; }

    // ボタンのサイズ
    public int Width = 70;
    public int Heigh = 70;

    void Start()
    {
        this.GameDirector = GameObject.Find("GameDirector").GetComponent<GameDirector>();

        // ボタンクリック時の処理を追加
        this.GetComponent<Button>().onClick.AddListener(OnClick);

        // ボタンのサイズを設定
        this.GetComponent<RectTransform>().sizeDelta = new Vector2(this.Width, this.Heigh);
    }

    // ボタンの情報を設定する
    public void SetButtonInfos(int number, string text)
    {
        this.Text = text;
        this.Number = number;

        this.GetComponentsInChildren<Text>()[0].text = text;
    }

    // クリック時の処理
    private void OnClick()
    {
        if (this.GameDirector.CheckNumber(this.Number))
        {
            // 正しい番号の場合、数字を進めてボタンを消す
            this.GameDirector.ChangeNextValue();
            Destroy(gameObject);

            // クリア判定と処理を呼び出し
            this.GameDirector.ClearGameIfAllButtonClicked();
        }
    }
}
