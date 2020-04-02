using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameModeSwitcher : MonoBehaviour
{
    public static void GoOnlineStatic()
    {
        SceneManager.LoadScene("InGame");
    }
    public static void GoToDesktopStatic()
    {
        Application.Quit();
    }
    public static void GoToMenuStatic()
    {
        SceneManager.LoadScene("Menu");
    }
    public void GoOnline()
    {
        GoOnlineStatic();
    }
    public void GoToDesktop()
    {
        GoToDesktopStatic();
    }
    public void GoToMenu()
    {
        GoToMenuStatic();
    }
}
