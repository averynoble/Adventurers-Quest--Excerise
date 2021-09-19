using System;

namespace Quest
{
    public class Prize
    {
        private string _text { get; set; }

        public Prize(string text)
        {
            _text = text;
        }

        public void ShowPrize(Adventurer adventurer)
        {
            if (adventurer.Awesomeness > 0)
            {
                for (int i = 0; i < adventurer.Awesomeness; i++)
                {
                    Console.WriteLine($"Great job {adventurer.Name} you have received {_text}");
                }
            }
            else 
            {
                Console.WriteLine($"I'm sorry {adventurer.Name} you're not awesome enough to receive a prize.");
            }
        }
    }
}