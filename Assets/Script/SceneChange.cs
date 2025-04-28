using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToNextSceneOnDestroy : MonoBehaviour
{
    public string nextSceneName = "NextScene"; // Inspectorで設定可

    private void OnDestroy()
    {
        // シーンが切り替わる前にnullチェック（必要に応じて）
        if (!string.IsNullOrEmpty(nextSceneName))
        {
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
