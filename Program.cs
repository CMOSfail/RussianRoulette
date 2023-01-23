using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Speech;
using System.Speech.Synthesis;
using System.ComponentModel;
using System.Media;

namespace RussianRoulette02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var synth = new SpeechSynthesizer();
            Slot[] slots = CreateSlots();
            bool IsGameOver = false;
            Console.WriteLine("Welcome to the Russian Roulette!!!");
            synth.Speak("Welcome to the Russian Roulette!!!");
            System.Media.SoundPlayer player = new System.Media.SoundPlayer();


            while (!IsGameOver)
            {
                Console.WriteLine("---");
                for (int i = 0; i < 6; i++)
                {
                    if (slots[i].IsShot == true)
                    {
                        Console.Write("X ");
                    }
                    else
                    {
                        Console.Write("O ");
                    }
                }
                Console.WriteLine();
                Console.WriteLine("---");
                Console.Write("Please input a number of slot: ");
                int slot = int.Parse(Console.ReadLine());

                while((slot-1) < 0 || (slot-1) > 5)
                {
                    Console.Write("Not a valid slot number, please try again: ");
                    slot = int.Parse(Console.ReadLine());
                }

                while (slots[slot - 1].IsShot)
                {
                    Console.Write("Not a valid slot number, please try again: ");
                    slot = int.Parse(Console.ReadLine());
                }

                slots[slot - 1].IsShot = true;

                if (slots[slot-1].IsLoaded)
                {
                    player.SoundLocation = @"C:\Users\thebl\source\repos\RussianRoulette02\bonk-sound-effect-36055.wav";
                    player.PlaySync();
                    Console.WriteLine("Bang! You got shot! Game Over");
                    synth.Speak("Bang! You got shot! Game Over");
                    IsGameOver = true;
                }
                if (!slots[slot-1].IsLoaded)
                {
                    player.SoundLocation = @"C:\Users\thebl\source\repos\RussianRoulette02\evil-laugh-49831.wav";
                    player.PlaySync();
                    Console.WriteLine("It looks like you will live to see another day...");
                    synth.Speak("It looks like you will live to see another day...");
                }

                if (IsGameOver == true)
                {
                    Console.Write("Would you like to start another game? (type 0 if not and 1 for another game!): ");
                    int temp = int.Parse(Console.ReadLine());
                    if ((temp == 1))
                    {
                        IsGameOver = false;
                        slots = CreateSlots();
                        Console.WriteLine();
                        Console.WriteLine("Welcome to the Russian Roulette!!!");
                    }
                    else
                    {
                        IsGameOver = true;
                        Console.ReadLine();
                    }
                }
            }

            Console.ReadLine();

            

        }

        public static Slot[] CreateSlots()
        {
            Slot[] slots = new Slot[6];

            for(int i = 0; i < 5; i++)
            {
                Slot slot = new Slot(false, false);
                slots[i] = slot;
            }
            Slot slot02 = new Slot(true, false);
            slots[5] = slot02;

            Random rnd = new Random();
            slots = slots.OrderBy(x => rnd.Next()).ToArray();

            return slots;
        }
    }
}
