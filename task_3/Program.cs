static int CountCombinations(int numDice, int targetSum)
{
    int[,] dp = new int[numDice + 1, targetSum + 1]; 

    for (int i = 1; i <= 6; i++)
    {
        if (i <= targetSum)
        {
            dp[1, i] = 1;
        }
    }

    for (int d = 2; d <= numDice; d++)
    {
        for (int s = 2; s <= targetSum; s++)
        {
            for (int roll = 1; roll <= 6; roll++)
            {
                if (s - roll >= 1)
                {
                    dp[d, s] += dp[d - 1, s - roll];
                }
            }
        }
    }

    return dp[numDice, targetSum];
}



if (CountCombinations(2, 6) == 5 &&
    CountCombinations(2, 2) == 1 &&
    CountCombinations(1, 3) == 1 &&
    CountCombinations(2, 5) == 4 &&
    CountCombinations(3, 4) == 3 &&
    CountCombinations(4, 18) == 80 &&
    CountCombinations(6, 20) == 4221)
        Console.WriteLine("all tests passed");
