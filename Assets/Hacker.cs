using UnityEngine;

public class Hacker : MonoBehaviour
{

    // Game state
    int level;
    enum Screen { MainMenu, Password, Win };
    string password;
    Screen currentScreen;

    string[] level1Passwords = {"books", "aisle", "shelf", "password", "font", "borrow"};
    string[] level2Passwords = {"handcuff", "baton", "badge", "arrest"};


    // Start is called before the first frame update
    void Start()
    {
        ShowMainMenu();
    }

    void ShowMainMenu() {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        string greeting = "What would you like to hack into?";
        Terminal.WriteLine(greeting);
        Terminal.WriteLine("");
        Terminal.WriteLine("Press 1 for the local library");
        Terminal.WriteLine("Press 2 for the police station");
        Terminal.WriteLine("Enter your selection: ");
    }

    

    void OnUserInput(string input) {
        input = input.ToLower();
        if (input == "menu"){
            ShowMainMenu();
        } 
        else if (currentScreen == Screen.MainMenu) {
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.Password) {
            CheckPassword(input);
        }
    }

    void RunMainMenu(string input) {
        bool isValidLevelNumber = (input == "1" || input == "2");
        if (isValidLevelNumber){
            level = int.Parse(input);
            AskForPassword();
        }        
        else {
            Terminal.WriteLine("Choose a valid level");
        }
    }

    void AskForPassword() {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        SetRandomPassword();
        Terminal.WriteLine("Enter the password, hint: " + password.Anagram());
    }

    void SetRandomPassword(){
    switch(level){
            case 1:
                password = level1Passwords[Random.Range(0, level1Passwords.Length -1)];
            break;
            case 2:
                password = level2Passwords[Random.Range(0, level2Passwords.Length -1)];
            break;
            default:
                Debug.LogError("Invalid Level");
                break;
        }
    }
    void CheckPassword(string input) {
        if (input == password){
            DisplayWinScreen();
        }
        else {
            Terminal.WriteLine("Try again");
            AskForPassword();
        }
    }

    void DisplayWinScreen(){
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
    }

    void DisplayMenuTip(){
        Terminal.WriteLine("Type 'menu' to return to Main Menu...");
    }

    void ShowLevelReward(){
        switch(level){
            case 1:
                Terminal.WriteLine("Level 1 Complete");
                Terminal.WriteLine(@"
                Yay.
                ");
                DisplayMenuTip();
                break;
            case 2:
                Terminal.WriteLine("Level 2 Complete");
                Terminal.WriteLine(@"
                1337.
                ");
                DisplayMenuTip();
            break;
            
        }
    }
}