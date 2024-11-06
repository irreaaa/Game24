using System;
Console.WriteLine("Введите 4 числа через пробел:");
string input = Console.ReadLine();
try
{
    int[] numbers = input.Split(' ').Select(x => Convert.ToInt32(x)).ToArray();
    bool canMake24 = false;

    for (int i = 0; i < numbers.Length; i++)
    {
        for (int j = 0; j < numbers.Length; j++)
        {
            if (i != j)
            {
                int[] remaining = new int[2];
                int idx = 0;
                for (int k = 0; k < numbers.Length; k++)
                {
                    if (k != i && k != j)
                    {
                        remaining[idx] = numbers[k];
                        idx++;
                    }
                }

                double[] results = new double[]
                {
                        numbers[i] + numbers[j],
                        numbers[i] - numbers[j],
                        numbers[i] * numbers[j],
                        numbers[j] != 0 ? (double)numbers[i] / numbers[j] : double.NaN
                };

                for (int m = 0; m < results.Length; m++)
                {
                    double result = results[m];

                    double[] newRemaining = new double[3];
                    newRemaining[0] = result;
                    newRemaining[1] = remaining[0];
                    newRemaining[2] = remaining[1];

                    for (int n = 0; n < numbers.Length - 1; n++)
                    {
                        for (int o = 0; o < numbers.Length - 1; o++)
                        {
                            if (n != o)
                            {
                                double[] nextRemaining = new double[1];
                                int idx2 = 0;
                                for (int p = 0; p < numbers.Length - 1; p++)
                                {
                                    if (p != n && p != o)
                                    {
                                        nextRemaining[idx2] = newRemaining[p];
                                        idx2++;
                                    }
                                }

                                double[] nextResults = new double[]
                                {
                                        newRemaining[n] + newRemaining[o],
                                        newRemaining[n] - newRemaining[o],
                                        newRemaining[n] * newRemaining[o],
                                        newRemaining[o] != 0 ? newRemaining[n] / newRemaining[o] : double.NaN
                                };

                                for (int p = 0; p < nextResults.Length; p++)
                                {
                                    if (Math.Abs(nextResults[p] - 24) < 1e-6)
                                    {
                                        canMake24 = true;
                                        break;
                                    }
                                }
                            }

                            if (canMake24) break;
                        }

                        if (canMake24) break;
                    }

                    if (canMake24) break;
                }

                if (canMake24) break;
            }

            if (canMake24) break;
        }

        if (canMake24) break;
    }

    if (canMake24)
    {
        Console.WriteLine("YES");
    }
    else
    {
        Console.WriteLine("NO");
    }
}
catch (Exception e) 
{
        Console.WriteLine("Ошибка: некорректный ввод цифр");
}