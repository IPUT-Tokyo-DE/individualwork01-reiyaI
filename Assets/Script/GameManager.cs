using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameTimerMultipleTags : MonoBehaviour
{
    string[] targetTags = { "Square", "Circle", "Triangle" };
    public Text resultText; // �N���A�^�C����Q�[���I�[�o�[������\������Text

    public float timeLimit = 20f;// �������ԁi�b�j
    private bool gameEnded = false;

    void Start()
    {
        // �Q�[���J�n���ɂ͉����\�����Ȃ�
        resultText.gameObject.SetActive(false);
    }

    void Update()
    {
        if (gameEnded) return;

        tanaka.time += Time.deltaTime;

        if (tanaka.time >= timeLimit)
        {
            EndGame(false); // ���Ԑ؂�ŃQ�[���I�[�o�[
        }

        int totalObjects = 0;
        foreach (string tag in targetTags)
        {
            totalObjects += GameObject.FindGameObjectsWithTag(tag).Length;
        }

        if (totalObjects == 0)
        {
            EndGame(true); // �I�u�W�F�N�g�S����������N���A
        }
    }

    void EndGame(bool cleared)
    {
        gameEnded = true;
        resultText.gameObject.SetActive(true); // �e�L�X�g��\��

        if (cleared)
        {
            resultText.text = $"�N���A�^�C���F{tanaka.time:F2} �b";
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