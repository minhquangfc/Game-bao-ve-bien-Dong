using UnityEngine;
using System.Collections;

public class MainMenuController : MonoBehaviour {

	public void _PlayGameButton()
    {
        Application.LoadLevel("GamePlay");

    }
    public void _QuitGameButton()
    {
        Application.Quit();
    }
}
