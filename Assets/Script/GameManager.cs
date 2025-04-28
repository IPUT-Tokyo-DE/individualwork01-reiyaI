using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameTimerMultipleTags : MonoBehaviour
{
    string[] targetTags = { "Square", "Circle", "Triangle" };
    public Text resultText; // クリアタイムやゲームオーバーだけを表示するText

    public float timeLimit = 20f;// 制限時間（秒）
    private bool gameEnded = false;

    void Start()
    {
        // ゲーム開始時には何も表示しない
        resultText.gameObject.SetActive(false);
    }

    void Update()
    {
        if (gameEnded) return;

        tanaka.time += Time.deltaTime;

        if (tanaka.time >= timeLimit)
        {
            EndGame(false); // 時間切れでゲームオーバー
        }

        int totalObjects = 0;
        foreach (string tag in targetTags)
        {
            totalObjects += GameObject.FindGameObjectsWithTag(tag).Length;
        }

        if (totalObjects == 0)
        {
            EndGame(true); // オブジェクト全部消えたらクリア
        }
    }

    void EndGame(bool cleared)
    {
        gameEnded = true;
        resultText.gameObject.SetActive(true); // テキストを表示

        if (cleared)
        {
            resultText.text = $"クリアタイム：{tanaka.time:F2} 秒";
            StartCoroutine(ending());
        }
        else
        {
            resultText.text = "Game Over";
            StartCoroutine(ending2());
        }
    }

private IEnumerator ending()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("start");
    }

private IEnumerator ending2()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("start");
    }

}