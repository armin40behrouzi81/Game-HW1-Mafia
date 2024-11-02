using System.Collections.Generic;
using UnityEngine; // Keep this for Unity types
using UnityEngine.UI; // Keep this for UI elements

public class RoleManager : MonoBehaviour
{
    public UnityEngine.UI.Text roleNameText; // Specify UnityEngine.UI.Text to avoid ambiguity
    public UnityEngine.UI.Button nextButton;  // Specify UnityEngine.UI.Button to avoid ambiguity
    private List<string> roles = new List<string>(); // List to hold roles
    private int currentPlayerIndex = 0; // Track the current player's index

    void Start()
    {
        // Check if GameSettings.PlayerCount is accessible
        if (GameSettings.PlayerCount <= 0)
        {
            UnityEngine.Debug.LogError("PlayerCount is not set! Please select a mode in the Main Menu."); // Use UnityEngine.Debug
            return; // Exit if PlayerCount is not set
        }

        int playerCount = GameSettings.PlayerCount;
        GenerateRoles(playerCount);

        // Display the first player's role
        DisplayRole();

        // Set up the next button to move to the next player
        nextButton.onClick.AddListener(NextPlayer);
    }

    void GenerateRoles(int playerCount)
    {
        // Define roles based on player count
        if (playerCount == 8)
        {
            roles.AddRange(new string[] { "Mafia", "Mafia", "Doctor", "Detective", "Citizen", "Citizen", "Citizen", "Citizen" });
        }
        else if (playerCount == 10)
        {
            roles.AddRange(new string[] { "Mafia", "Mafia", "Mafia", "Doctor", "Detective", "Citizen", "Citizen", "Citizen", "Citizen", "Citizen" });
        }
        else if (playerCount == 12)
        {
            roles.AddRange(new string[] { "Mafia", "Mafia", "Mafia", "Doctor", "Detective", "Citizen", "Citizen", "Citizen", "Citizen", "Citizen", "Citizen", "Citizen" });
        }

        // Shuffle roles to randomize distribution
        roles = ShuffleList(roles);
    }

    void DisplayRole()
    {
        // Show the current player's role
        roleNameText.text = $"Player {currentPlayerIndex + 1}'s Role: {roles[currentPlayerIndex]}";
    }

    void NextPlayer()
    {
        // Move to the next player
        currentPlayerIndex++;

        if (currentPlayerIndex < roles.Count)
        {
            DisplayRole();
        }
        else
        {
            // End of role display; handle game start here
            roleNameText.text = "All roles have been viewed.";
            nextButton.gameObject.SetActive(false);
        }
    }

    List<string> ShuffleList(List<string> list)
    {
        System.Random rng = new System.Random();
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            string value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
        return list;
    }
}
        