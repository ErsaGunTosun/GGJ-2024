using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Cinemachine.DocumentationSortingAttribute;

public class MainMenu : MonoBehaviour
{
    public void ordu()
{
    Debug.Log("Ordu");
    SceneManager.LoadScene("Level1");
}
    public void konya()
{
    Debug.Log("Konya");
    SceneManager.LoadScene("Level2");
}
    public void kocaeli()
{
    Debug.Log("Kocaeli");
    SceneManager.LoadScene("Level3");
}
    public void izmir()
{
    Debug.Log("İzmir");
    SceneManager.LoadScene("Level4");
}
    public void istanbul()
{
     Debug.Log("İstanbul");
    SceneManager.LoadScene("Level5");
}
    public void QuitGame()
{
    Debug.Log("Oyundan cikildi");
    Application.Quit();
}
    public void ReturnToMainMenu()
{
    Debug.Log("Ana menuye donuldu");
    SceneManager.LoadScene("MainMenu");
}
}
