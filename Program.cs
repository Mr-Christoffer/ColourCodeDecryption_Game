// [0]=red, [1]=green, [2]=blue, [3]=purple, [4]=yellow, [5]=black
string[] colours = { "red", "green", "blue", "purple", "yellow", "black" };
string[] slotNames = { "first", "second", "third", "fourth" };
int[] selectedColours = new int[4];
int[,] guessedColours = new int[12, 4];
int currentRound = 0;
Random rand = new Random();
int[] correctColours = new int[12];
int[] colourExistElseWhere = new int[12];
bool playing = true;
int playerScore;
int aiScore;
bool playersTurn = true;
string[] currentPlayer = { "player", "AI" };
List<int> possibleSolutions = new List<int>();

for (int i = 0; i < 4; i++)
{
    int randomColour = rand.Next(0, 6);
    selectedColours[i] = randomColour;
}

System.Console.WriteLine(colours[selectedColours[0]]);
System.Console.WriteLine(colours[selectedColours[1]]);
System.Console.WriteLine(colours[selectedColours[2]]);
System.Console.WriteLine(colours[selectedColours[3]]);
System.Console.WriteLine("");

while (playing)
{
    while (playersTurn == true)
    {
        PlayRound();
        CheckResult();
        DisplayPreviousRounds();
        if (correctColours[currentRound] == 4)
        {
            System.Console.WriteLine($"CONGRATULATIONS. YOU SOLVED THE PUZZLE IN {currentRound + 1} ROUNDS!!");
            playerScore = currentRound + 1;
            System.Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            playersTurn = false;
            continue;
        }
        if (currentRound == 11)
        {
            System.Console.WriteLine($"YOU FAILED! CORRECT COLOURS ARE:");
            System.Console.WriteLine($"{colours[selectedColours[0]]}\t{colours[selectedColours[1]]}\t{colours[selectedColours[2]]}\t{colours[selectedColours[3]]}");
            playerScore = 13;
            System.Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            playersTurn = false;
            continue;
        }
        currentRound++;

    }

    PrepareAiGame();
    while (playersTurn == false)
    {
        AiRound();
        CheckResult();
        DisplayPreviousRounds();
    }
}


void AiRound()
{

}

void PrepareAiGame()
{
    for (int s = 0; s < 4; s++)
    {
        System.Console.WriteLine("");
        bool validAnswer = false;
        while (validAnswer == false)
        {
            System.Console.WriteLine($"Choose the {slotNames[s]} colour:");
            char choice = Console.ReadKey().KeyChar;
            System.Console.WriteLine("");
            if (choice == '1' || choice == '2' || choice == '3' || choice == '4' || choice == '5' || choice == '6')
            {
                switch (choice)
                {
                    case '1':
                        selectedColours[s] = 0;
                        break;
                    case '2':
                        selectedColours[s] = 1;
                        break;
                    case '3':
                        selectedColours[s] = 2;
                        break;
                    case '4':
                        selectedColours[s] = 3;
                        break;
                    case '5':
                        selectedColours[s] = 4;
                        break;
                    case '6':
                        selectedColours[s] = 5;
                        break;
                }
                validAnswer = true;
            }
            continue;
        }
    }
    // Initialize possible solutions.
    for (int sol = 0 ; sol < 1296 ; sol++)
    {
        possibleSolutions.Add(sol);
    }
}


void DisplayPreviousRounds()
{
    Console.Clear();
    System.Console.WriteLine("Previous guesses: (CP = Correct colour and position, CE = Colur exists on other postion)");
    System.Console.WriteLine("");
    for (int i = 0; i <= currentRound; i++)
    {
        System.Console.WriteLine($"Round {i + 1} guesses:");
        System.Console.WriteLine($"{colours[guessedColours[i, 0]]}\t{colours[guessedColours[i, 1]]}\t{colours[guessedColours[i, 2]]}\t{colours[guessedColours[i, 3]]}");
        System.Console.WriteLine($"CP: {correctColours[i]} \nCE: {colourExistElseWhere[i]}");
        System.Console.WriteLine("");
    }
}

void CheckResult()
{
    List<int> selectedColoursList = new List<int>();
    selectedColoursList.Add(selectedColours[0]);
    selectedColoursList.Add(selectedColours[1]);
    selectedColoursList.Add(selectedColours[2]);
    selectedColoursList.Add(selectedColours[3]);
    for (int CC = 0; CC < 4; CC++)
    {
        if (guessedColours[currentRound, CC] == selectedColours[CC])
        {
            correctColours[currentRound]++;
            selectedColoursList.Remove(guessedColours[currentRound, CC]);
        }
    }
    for (int CE = 0; CE < 4; CE++)
    {
        if (guessedColours[currentRound, CE] == selectedColours[CE])
        {
            continue;
        }
        else if (selectedColoursList.Contains(guessedColours[currentRound, CE]))
        {
            colourExistElseWhere[currentRound]++;
            selectedColoursList.Remove(guessedColours[currentRound, CE]);
        }
    }
}

void PlayRound()
{
    System.Console.WriteLine("1. Red      2. Green    3. Blue     4.Purple    5. Yellow   6. Black");
    for (int s = 0; s < 4; s++)
    {
        System.Console.WriteLine("");
        bool validAnswer = false;
        while (validAnswer == false)
        {
            System.Console.WriteLine($"Choose the {slotNames[s]} colour:");
            char choice = Console.ReadKey().KeyChar;
            System.Console.WriteLine("");
            if (choice == '1' || choice == '2' || choice == '3' || choice == '4' || choice == '5' || choice == '6')
            {
                switch (choice)
                {
                    case '1':
                        guessedColours[currentRound, s] = 0;
                        break;
                    case '2':
                        guessedColours[currentRound, s] = 1;
                        break;
                    case '3':
                        guessedColours[currentRound, s] = 2;
                        break;
                    case '4':
                        guessedColours[currentRound, s] = 3;
                        break;
                    case '5':
                        guessedColours[currentRound, s] = 4;
                        break;
                    case '6':
                        guessedColours[currentRound, s] = 5;
                        break;
                }
                validAnswer = true;
            }
            continue;
        }
    }
}

