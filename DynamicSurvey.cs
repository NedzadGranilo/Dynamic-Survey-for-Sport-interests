using System;

class DynamicSurvey
{
    static void Main()
    {
        // Welcome message
        Console.WriteLine("Welcome to the University Sports Interest Survey!");
        Console.WriteLine("This survey will help us understand your sports preferences and participation.");

        // Question 1: What is your name?
        Console.Write("1. What is your name? ");
        string name = Console.ReadLine();

        // Question 2: What is your age? (Valid input: 1, 2, 3)
        string age = GetValidAnswer("2. What is your age? (1. 18-22, 2. 23-27, 3. 28 and above)", "1", "2", "3");

        // Question 3: What year of university are you in? (Valid input: 1, 2, 3, 4)
        string yearOfUniversity = GetValidAnswer(
            "3. What year of university are you in? (1. 1st Year, 2. 2nd Year, 3. 3rd Year, 4. 4th Year)", "1", "2", "3", "4"
        );

        // Question 4: Do you play any sports? (Valid input: 1. Yes, 2. No)
        string playsSports = GetValidAnswer("4. Do you play any sports? (1. Yes, 2. No)", "1", "2");

        if (playsSports == "1")
        {
            // Additional questions for sports players
            string sportPlayed = GetValidAnswer(
                "5. Which sports do you play? (1. Soccer, 2. Basketball, 3. Tennis, 4. Swimming, 5. Volleyball)", "1", "2", "3", "4", "5"
            );
            string skillLevel = GetValidAnswer(
                "6. How would you rate your skill level in your chosen sport? (1. Beginner, 2. Intermediate, 3. Expert)", "1", "2", "3"
            );
            string practiceFrequency = GetValidAnswer(
                "7. How often do you practice your sport? (1. Daily, 2. Weekly, 3. Occasionally)", "1", "2", "3"
            );
            string teamSport = GetValidAnswer("8. Do you participate in any team sports? (1. Yes, 2. No)", "1", "2");
            string sportType = GetValidAnswer(
                "9. What is your preferred type of sport? (1. Competitive, 2. Recreational)", "1", "2"
            );
            string practiceTime = GetValidAnswer(
                "10. What time of day do you prefer to practice sports? (1. Morning, 2. Afternoon, 3. Evening)", "1", "2", "3"
            );
            string joinClub = GetValidAnswer(
                "11. Would you be interested in joining a sports club at the university? (1. Yes, 2. No)", "1", "2"
            );
            string equipment = GetValidAnswer(
                "12. What sports equipment do you currently own? (1. Ball, 2. Racket, 3. Shoes)", "1", "2", "3"
            );
            string trainingLocation = GetValidAnswer(
                "13. Would you prefer to train indoors or outdoors? (1. Indoors, 2. Outdoors)", "1", "2"
            );
            string fitnessImportance = GetValidAnswer(
                "14. How important is fitness to you? (1. Very important, 2. Important, 3. Not important)", "1", "2", "3"
            );
            Console.Write("15. Do you have any suggestions to improve university sports programs? ");
            string suggestions = Console.ReadLine();

            Console.WriteLine("\nThank you for completing the survey, " + name + "!");
            Console.WriteLine("Your responses have been recorded.");
        }
        else
        {
            Console.WriteLine("Thank you for your time! Your responses will still help us improve our sports programs.");
        }
    }

    // Method to validate the user input for questions with options (1, 2, 3, etc.)
    static string GetValidAnswer(string question, params string[] validAnswers)
    {
        while (true)
        {
            Console.WriteLine(question);
            string answer = Console.ReadLine();

            foreach (string validAnswer in validAnswers)
            {
                if (answer == validAnswer)
                {
                    return answer;
                }
            }

            Console.WriteLine("Invalid input. Please enter one of the following options: " + string.Join(", ", validAnswers));
        }
    }
}
