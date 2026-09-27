// [0]=red, [1]=green, [2]=blue, [3]=purple, [4]=yellow, [5]=black
string[] colours = { "red", "green", "blue", "purple", "yellow", "black" };
string[] slotNames = { "första", "andra", "tredje", "fjärde" };
int[] selectedColours = new int[4];
int[,] guessedColours = new int[12, 4];
int currentRound = 0;
Random rand = new Random();

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


PlayRound();
CheckResult();

void CheckResult()
{
    int correctColours = 0;
    for (int CC = 0; CC < 4 ; CC++)
    {
        if (guessedColours[currentRound, CC] == selectedColours[CC])
        {
            correctColours++;
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
            System.Console.WriteLine($"Välj den {slotNames[s]} färgen:");
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
System.Console.WriteLine("");
System.Console.WriteLine(currentRound);