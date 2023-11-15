using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour {
    // Game configuration data
    string[] level1Passwords = { "book", "password", "library", "font" };
    string[] level2Passwords = { "car", "badge", "doughnut", "gun" };
    string[] level3Passwords = { "bigbang", "voyager", "mars", "startrek" };
    const string menuHint = "You may type 'menu' at any time to see the main menu.";
    // Game State
    public int level;
    public enum Screen { MainMenu, Password, Win }
    public Screen currentScreen;
    public string password;

	// Use this for initialization
	void Start () {
        ShowMainMenu();
	}
	
    private void ShowMainMenu()
    {
        currentScreen = Screen.MainMenu;

        Terminal.ClearScreen();
        Terminal.WriteLine("What would you like to hack into?\n\n");
        Terminal.WriteLine("Press 1 for the library");
        Terminal.WriteLine("Press 2 for the police station");
        Terminal.WriteLine("Press 3 for NASA\n\n");
        Terminal.WriteLine("Enter your selection: ");
    }

	// Update is called once per frame
	void Update () {
		
	}

    void OnUserInput(string input)
    {
        if (input == "menu")
            ShowMainMenu();
        else
        {
            switch (currentScreen)
            {
                case Screen.MainMenu:
                    MainMenuInput(input);
                    break;
                case Screen.Password:
                    PasswordInput(input);
                    break;
                case Screen.Win:
                    WinInput(input);
                    break;
                default:
                    break;
            }
        }
    }

    private void MainMenuInput(string input)
    {
        switch (input.ToLower())
        {
            case "1":
            case "2":
            case "3":
                level = Convert.ToInt32(input);
                StartGame();
                break;
            case "007":
                Terminal.WriteLine("Please choose a level, Mr. Bond.");
                break;
            default:
                Terminal.WriteLine("Unknown command. Please try again.");
                Terminal.WriteLine(menuHint);
                break;
        }
    }

    private void PasswordInput(string input)
    {
        if (input == password)
            Win();
        else
        {
            Terminal.WriteLine("Wrong password!");
            Terminal.WriteLine("Please enter your password: ");
            Terminal.WriteLine(menuHint);
        }
    }

    private void WinInput(string input)
    {

    }

    public void StartGame()
    {
        currentScreen = Screen.Password;

        switch(level)
        {
            case 1:
                password = level1Passwords[UnityEngine.Random.Range(0, level1Passwords.Length)];
                break;
            case 2:
                password = level2Passwords[UnityEngine.Random.Range(0, level2Passwords.Length)];
                break;
            case 3:
                password = level3Passwords[UnityEngine.Random.Range(0, level3Passwords.Length)];
                break;
            default:
                break;
        }

        Terminal.ClearScreen();
        Terminal.WriteLine("Enter your password (hint: " + password.Anagram() + "): ");
    }

    public void Win()
    {
        currentScreen = Screen.Win;

        Terminal.ClearScreen();
        ShowLevelReward();
    }

    public void ShowLevelReward()
    {
        switch(level)
        {
            case 1:
                Terminal.WriteLine("Have a book!");



                string book = @"            /;
                                           / |'-,.
                                          /  '    `""-- -,.__
                                          / '    ,'     ,  '""--,""|
                                        / '    ,     ,'     ,""::|
                                      / '   ,'    ,      ,""::::|
                                    / '   ,    ,'     ,""::::::L
                                  / '  ,'   ,'     ,""::::::::L
                                / '  ,    ,     ,"":::::::::J
                                    k -,._    ,'   _."":::::::::::J
                                     \\.  `""----'"""".J::::::::::::|
                                      \\.    .-,    .L:::::::::::|
                                       \\.  (       .J:::::::::::!
                                        \\.  `--     .L:::::::::/
                                         \\.   .-.   .|::::::::/
                                          \\. (   ).J:::::::/
                                           \\. `-'    .L:::::/
                                            \\.  L.|::::/
                                             \\. !__.J:::/
                                              \\.  __.L:/
                                               \\. L_) .|/
                                                `-,__,-'   ";
                
                Terminal.WriteLine(book);
                break;
            case 2:
                Terminal.WriteLine("Have a doughnut!");
                string doughnut = @"        _.-------._
                                          .'    ___    '.
                                         /     (___)     \
                                         |'._         _.'|
                                         |   `'-----'`   |
                                          \             /
                                           '-.______..-'";
                Terminal.WriteLine(doughnut);
                break;
            case 3:
                Terminal.WriteLine("Have a pen that writes upside down!");
                string pen = @"         .=======================ooooooo
                                 ___   ,'    \_________________________________________
                                /   /-/   dP  /                           ////////////  ''--..._
                                \___\-\  dP   \                           \\\\\\\\\\\\  __..--'
                                       `---------------------------------''''''''''''''";
                Terminal.WriteLine(pen);
                break;
            default:
                break;
        }
    }
}
