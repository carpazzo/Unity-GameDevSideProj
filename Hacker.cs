  using UnityEngine;

public class Hacker : MonoBehaviour {

    //Game Data
    string[] Knowledge1 = {"boar", "cavern", "spear", "crayon", "silver"};
    string[] Knowledge2 = {"chivalry", "shield", "westfield", "monitoring", "atroucious"};
    string[] Knowledge3 = {"augumented", "mycilions", "adaptibity","convergence", "hologram" };
    const string menuHint = "type Menu and press Enter to restart";
    int level;
    enum Screen { MainMenu, Knowledge, Win };
    string knowledge;
    // declared a variable and inicialized it below
    Screen currentScreen;
    // Use this for initialization
    void Start()
    {
        print("Game initialized");
        ShowMainMenu();


    }
    void ShowMainMenu()
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("Choose the Timeline for trial?");
        Terminal.WriteLine("Press 1 for Primitive knowledge");
        Terminal.WriteLine("Press 2 for Era knowledge");
        Terminal.WriteLine("Press 3 for future knowledge");
        Terminal.WriteLine("Enter your selection: ");
    }



    void OnUserInput(string input)
    {

        if (input == "menu")
        {
            ShowMainMenu();
        }
        else if (input == "quit" || input == "close" || input == "exit" ) 
        {
            Application.Quit();//dont work on web aplications
        }
        else if (currentScreen == Screen.MainMenu)
        {
            RunMaiMenu(input);
        }
        else if (currentScreen == Screen.Knowledge)
        {
            CheckKnowledge(input);
        }
    }

    void RunMaiMenu(string input)
    {
        bool isValidNumber = (input == "1" || input == "2" || input == "3");
        if (isValidNumber)
        {
            level = int.Parse(input);
            StartGame();
        } 
        else
        {
            Terminal.WriteLine("Choose a valid option");
            Terminal.WriteLine(menuHint);
        }
    }

    void StartGame()
    {
        currentScreen = Screen.Knowledge;
        Terminal.ClearScreen();
        SetRandomKnowledge();
        Terminal.WriteLine("Type the Knowledge,Hint: " + knowledge.Anagram());
    }

    void SetRandomKnowledge()
    {
        switch (level)
        {
            case 1:
                knowledge = Knowledge1[Random.Range(0, Knowledge1.Length)];
                break;
            case 2:
                knowledge = Knowledge2[Random.Range(0, Knowledge2.Length)];
                break;
            case 3:
                knowledge = Knowledge3[Random.Range(0, Knowledge3.Length)];
                break;
            default:
                Debug.LogError("Invalid");
                break;

        }
    }

    void CheckKnowledge(string input)
    {
        if (input == knowledge)
        {
            WinScreen();
        }
        else
        {
            StartGame();
        }
    
    }

    void WinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        Reward();
    }

    void Reward()
    {
        switch (level)
        {
            case 1:
                Terminal.WriteLine("Have a book...");
                Terminal.WriteLine(@"
    _______
   /     //
  /     //
 /_____//   
(_____(/

"               );
                break;
            case 2:
                Terminal.WriteLine("Have a fish hook...");
                Terminal.WriteLine(@"
 /) 
(_______>>>>>>>>

");
                break;
            case 3:
                Terminal.WriteLine("Have a some money...");
                Terminal.WriteLine(@"
__________
(>$>>>$>>>$>
----------

");
                break;
            default:
                Debug.LogError("error");
                break;
        }

        Terminal.WriteLine("That is correct");
        Terminal.WriteLine(menuHint);

    }
}


