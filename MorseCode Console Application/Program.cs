using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorseCode_Console_Application
{
    internal class Program
    {
        static void Main(string[] args)
        {

            {
                string SetMorseCode(int nv)
                {
                    switch (nv)
                    {
                        case 48: // 0
                            return "-----";
                        case 49: // 1
                            return ".----";
                        case 50: // 2
                            return "..---";
                        case 51: // 3
                            return "...--";
                        case 52: // 4
                            return "....-";
                        case 53: // 5
                            return ".....";
                        case 54: // 6
                            return "-....";
                        case 55: // 7
                            return "--...";
                        case 56: // 8
                            return "---..";
                        case 57: // 9
                            return "----.";
                        case 65: // A
                            return ".-";
                        case 66: // B
                            return "-...";
                        case 67: // C
                            return "-.-.";
                        case 68: // D
                            return "-..";
                        case 69: // E
                            return ".";
                        case 70: // F
                            return "..-.";
                        case 71: // G
                            return "--.";
                        case 72: // H
                            return "....";
                        case 73: // I
                            return "..";
                        case 74: // J
                            return ".---";
                        case 75: // K
                            return "-.-";
                        case 76: // L
                            return ".-..";
                        case 77: // M
                            return "--";
                        case 78: // N
                            return "-.";
                        case 79: // O
                            return "---";
                        case 80: // P
                            return ".--.";
                        case 81: // Q
                            return "--.-";
                        case 82: // R
                            return ".-.";
                        case 83: // S
                            return "...";
                        case 84: // T
                            return "-";
                        case 85: // U
                            return "..-";
                        case 86: // V
                            return "...-";
                        case 87: // W
                            return ".--";
                        case 88: // X
                            return "-..-";
                        case 89: // Y
                            return "-.--";
                        case 90: // Z
                            return "--..";
                        case 32: // /space/
                            return "";
                        default:
                            {
                                return "";
                            }
                    }
                }
                bool CanConvert(string InstanceWord)
                {
                    bool canConvert = true;
                    char[] WordChar = InstanceWord.ToCharArray();
                    for (int wc = 0; wc < WordChar.Length; wc++)
                    {
                        if ((int)WordChar[wc] == 32 || ((int)WordChar[wc] >= 48 && (int)WordChar[wc] <= 57) || ((int)WordChar[wc] >= 65 && (int)WordChar[wc] <= 90))
                        {
                            continue;
                        }
                        else
                        {
                            canConvert = false;
                        }
                    }
                    return canConvert;
                }
                async void MorseSignal(string InstanceWord, int InstanceFrequencyValue, int InstanceBeepDelay)
                {
                    char[] WordChar = InstanceWord.ToCharArray();
                    for (int wc = 0; wc < WordChar.Length; wc++)
                    {
                        string MorseCodeString = SetMorseCode((int)WordChar[wc]);
                        char[] MorseCodeChar = MorseCodeString.ToCharArray();
                        for (int c = 0; c < MorseCodeChar.Length; c++)
                        {
                            int MorseCodeInt = Convert.ToInt32(MorseCodeChar[c]);
                            switch (MorseCodeInt)
                            {
                                case 45:
                                    {
                                        Console.Beep(InstanceFrequencyValue, 3 * InstanceBeepDelay);
                                        Console.Write("-");
                                        break;
                                    }
                                case 46:
                                    {
                                        Console.Beep(InstanceFrequencyValue, 2 * InstanceBeepDelay);
                                        Console.Write(".");
                                        break;
                                    }
                                case 32:
                                    {
                                        await Task.Delay(2 * InstanceBeepDelay);
                                        Console.Write(" ");
                                        break;
                                    }
                            }
                        }
                        await Task.Delay(2 * InstanceBeepDelay);
                        Console.Write("  ");

                    }
                }
                string word;
                string frequencystring;
                int frequencyValue;
                int messagesCounter = 1;
                string beepDelayString;
                int beepDelay = 100;
            Pos1:
                {
                    Console.WriteLine("Enter Text");
                    word = Console.ReadLine().ToUpper();
                    Console.WriteLine("Duration (ms)");
                    beepDelayString = Console.ReadLine();
                    try
                    {
                        beepDelay = Convert.ToInt32(beepDelayString);
                        Console.WriteLine("Frequency (Hz)");
                        frequencystring = Console.ReadLine();
                        try
                        {
                            frequencyValue = Convert.ToInt32(frequencystring);
                            if (frequencyValue >= 37 && frequencyValue <= 32767)
                            {
                                if (CanConvert(word))
                                {
                                    Console.WriteLine($"Message Number - {messagesCounter}\n");
                                    MorseSignal(word, frequencyValue, beepDelay);
                                }
                                else
                                {
                                    Console.WriteLine("Only latin letters, spaces and numbers are accepted");
                                }
                                Console.ReadKey();
                                Console.WriteLine("\r\n\r\nStart again?   Y / N ");
                                string answer = Console.ReadLine();
                                switch (answer.ToLower())
                                {
                                    case "y":
                                        {
                                            messagesCounter++;
                                            goto Pos1;
                                        }
                                    case "n":
                                        {
                                            break;
                                        }
                                }
                            }
                            else
                            {
                                Console.WriteLine("The frequency is not in the range from 37 Hz to 32767 Hz");
                                Console.ReadKey();
                                Console.WriteLine("\r\n\r\nStart again?   Y / N \"");
                                string answer = Console.ReadLine();
                                switch (answer.ToLower())
                                {
                                    case "y":
                                        {
                                            goto Pos1;
                                        }
                                    case "n":
                                        {
                                            break;
                                        }
                                }
                            }

                        }
                        catch
                        {
                            Console.WriteLine("\r\nWrong frequency");
                            Console.ReadKey();
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Wrong signal duration");
                        Console.ReadKey();
                    }

                }
            }
        }
    }
}
