using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{

    // Game state
    int level;
    enum Screen { MainMenu, Password, Win };
    string password;
    Screen currentScreen;

    string[] level1Passwords = {"books", "aisle", "self", "password", "font", "borrow"};
    string[] level2Passwords = {"crazy", "hard", "super", "difficult"};


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
        Terminal.WriteLine("Press 3 for NSA");
        Terminal.WriteLine("");
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
        if (input == "1") {
            level = 1;
            password = level1Passwords[2];
            StartGame();
        }
        else if (input == "2") {
            level = 2;
            password = level2Passwords[2];
            StartGame();
        }
        
        else {
            Terminal.WriteLine("Choose a valid level");
        }
    }

    void StartGame() {
        currentScreen = Screen.Password;
        Terminal.WriteLine("You have chosen level " +  level);
        Terminal.WriteLine("Enter the password");
    }

    void CheckPassword(string input) {
        if (input == password){
            Terminal.WriteLine("Well done!");
        }
        else {
            Terminal.WriteLine("Try again");
        }
    }
}