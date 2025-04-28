using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToNextSceneOnDestroy : MonoBehaviour
{
    public string nextSceneName = "NextScene"; // Inspector�Őݒ��

    private void OnDestroy()
    {
        // �V�[�����؂�ւ��O��null�`�F�b�N�i�K�v�ɉ����āj
        if (!string.IsNullOrEmpty(nextSceneName))
        {
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
