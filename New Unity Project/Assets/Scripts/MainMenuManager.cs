using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public Dropdown modeDropdown;
    public Button startButton;
    private int selectedPlayerCount;

    void Start()
    {
        selectedPlayerCount = 8;
        modeDropdown.onValueChanged.AddListener(delegate { ModeSelectionChanged(); });
        startButton.onClick.AddListener(StartGame);
    }

    void ModeSelectionChanged()
    {
        switch (modeDropdown.value)
        {
            case 0:
                selectedPlayerCount = 8;
                break;
            case 1:
                selectedPlayerCount = 10;
                break;
            case 2:
                selectedPlayerCount = 12;
                break;
        }
    }

    void StartGame()
    {
        GameSettings.PlayerCount = selectedPlayerCount;
        SceneManager.LoadScene("GameScene");
    }
}
