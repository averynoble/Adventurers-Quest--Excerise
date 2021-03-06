using System;
using System.Collections.Generic;

// Every class in the program is defined within the "Quest" namespace
// Classes within the same namespace refer to one another without a "using" statement
namespace Quest
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a few challenges for our Adventure's quest
            // The "Challenge" Constructor takes three arguments
            //      the text of the challenge
            //      a correct answer
            //      a number of awesome points to gain or lose depending on the success of the challenge
            Console.Write("What is your name Adventurer?");
            string adventurerName = Console.ReadLine();

            Robe adventurerRobe = new Robe() {Colors = new List<string>() {"Aquamarine", "Black"}, Length = 44};
            Hat adventurerHat = new Hat() {shininessLevel = 7};

            Adventurer theAdventurer = new Adventurer(adventurerName, adventurerRobe, adventurerHat);
            Prize thePrize = new Prize("Untold riches beyond your wildest dreams!");

            Console.WriteLine(theAdventurer.GetDescription());

            Console.WriteLine("Lets begin our quest!");

            Challenge twoPlusTwo = new Challenge("2 + 2?", 4, 10);
            
            Challenge theAnswer = new Challenge(
                "What's the answer to life, the universe and everything?", 42, 25);

            Challenge whatSecond = new Challenge(
                "What is the current second?", DateTime.Now.Second, 50);

            int randomNumber = new Random().Next() % 10;
            Challenge guessRandom = new Challenge(
                "What number am I thinking of?", randomNumber, 25);
            
            Challenge favoriteBeatle = new Challenge(
                @"Who's your favorite Beatle?
                1) John 2) Paul 3) George 4) Ringo", 4, 20 );
            
            Challenge whatFace = new Challenge(
                @"I am a face that is always changing but consistently ends up being the same
                1) Clock 2) Money 3) Status", 1, 10);
            
            Challenge timeManagement = new Challenge(
                @"What is the most abundant resource but can never be bought
                1) Time 2) Energy 3) Love 4) Faith", 1, 20);
            
            // "Awesomeness" is like our Adventurer's current "score"
            // A higher Awesomeness is better

            // Here we set some reasonable min and max values.
            //  If an Adventurer has an Awesomeness greater than the max, they are truly awesome
            //  If an Adventurer has an Awesomeness less than the min, they are terrible
            int minAwesomeness = 0;
            int maxAwesomeness = 100;

            // A list of challenges for the Adventurer to complete
            // Note we can use the List class here because of "using System.Collections.Generic;"

            void StartAdventure()
            {
                List<Challenge> challenges = new List<Challenge>()
                {
                    twoPlusTwo, theAnswer, whatSecond, guessRandom, favoriteBeatle, whatFace, timeManagement
                };

                // Selecting 5 Random new challenges for the adventurer
                for (int i = 0; i < 5; i++)
                {
                    int challengeCount = challenges.Count;
                    int randomChallenges = new Random().Next(challengeCount);
                    challenges[randomChallenges].RunChallenge(theAdventurer);  
                }

                // This code examines how Awesome the Adventurer is after completing the challenges
                // And praises or humiliates them accordingly
                if (theAdventurer.Awesomeness >= maxAwesomeness)
                {
                    Console.WriteLine("YOU DID IT! You are truly awesome!");
                }
                else if (theAdventurer.Awesomeness <= minAwesomeness)
                {
                    Console.WriteLine("Get out of my sight. You lack of awesomeness offends me!");
                }
                else
                {
                    Console.WriteLine("I guess you did...ok? ...sorta. Still, you should get out of my sight.");
                }

                thePrize.ShowPrize(theAdventurer);
                Console.Write("Would you like to quest again? (Y/N)");
                string questAgain = Console.ReadLine();
                if (questAgain == "y")
                {
                    Console.WriteLine("Forward we go to another adventure!");
                    int correctCountAmount = theAdventurer.Awesomeness * 10;
                    theAdventurer.Awesomeness += correctCountAmount;
                    Console.WriteLine();
                    StartAdventure();
                }
                else 
                {
                    Console.WriteLine($"So was told of the Legend of {theAdventurer.Name}!");
                }
            }

            StartAdventure();
        }
    }
}
