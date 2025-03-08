using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneMan : MonoBehaviour
{
    public static void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //SoundManager.Instance.ChangeMusic(SoundManager.Instance.musics[0]);
    }

    public static void LoadCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //SoundManager.Instance.ChangeMusic(SoundManager.Instance.musics[0]);
    }

    public static void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        //SoundManager.Instance.ChangeMusic(SoundManager.Instance.musics[2]);
    }

    public static void QuitGame()
    {
        Application.Quit();
    }
}
