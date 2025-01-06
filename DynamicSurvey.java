import java.util.Scanner;

public class DynamicSurvey {

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        // Welcome message
        System.out.println("Welcome to the University Sports Interest Survey!");
        System.out.println("This survey will help us understand your sports preferences and participation.");

        // Question 1: What is your name?
        System.out.print("1. What is your name? ");
        String name = scanner.nextLine();

        // Question 2: What is your age? (Valid input: 1, 2, 3)
        String age = getValidAnswer(scanner, "2. What is your age? (1. 18-22, 2. 23-27, 3. 28 and above)", "1", "2", "3");

        // Question 3: What year of university are you in? (Valid input: 1, 2, 3, 4)
        String yearOfUniversity = getValidAnswer(scanner, "3. What year of university are you in? (1. 1st Year, 2. 2nd Year, 3. 3rd Year, 4. 4th Year)", "1", "2", "3", "4");

        // Question 4: Do you play any sports? (Valid input: 1. Yes, 2. No)
        String playsSports = getValidAnswer(scanner, "4. Do you play any sports? (1. Yes, 2. No)", "1", "2");

        // Conditional questions based on the answer to "Do you play any sports?"
        if (playsSports.equals("1")) {
            // Question 5: Which sports do you play? (Valid input: 1-5)
            System.out.println("5. Which sports do you play?");
            System.out.println("   1. Soccer");
            System.out.println("   2. Basketball");
            System.out.println("   3. Tennis");
            System.out.println("   4. Swimming");
            System.out.println("   5. Volleyball");
            String sportPlayed = getValidAnswer(scanner, "Please choose a sport by typing the number (1-5)", "1", "2", "3", "4", "5");

            // Question 6: How would you rate your skill level in your chosen sport? (1. Beginner, 2. Intermediate, 3. Expert)
            String skillLevel = getValidAnswer(scanner, "6. How would you rate your skill level in your chosen sport? (1. Beginner, 2. Intermediate, 3. Expert)", "1", "2", "3");

            // Question 7: How often do you practice your sport? (1. Daily, 2. Weekly, 3. Occasionally)
            String practiceFrequency = getValidAnswer(scanner, "7. How often do you practice your sport? (1. Daily, 2. Weekly, 3. Occasionally)", "1", "2", "3");

            // Question 8: Do you participate in any team sports? (Valid input: 1. Yes, 2. No)
            String teamSport = getValidAnswer(scanner, "8. Do you participate in any team sports? (1. Yes, 2. No)", "1", "2");

            // Question 9: What is your preferred type of sport? (1. Competitive, 2. Recreational)
            String sportType = getValidAnswer(scanner, "9. What is your preferred type of sport? (1. Competitive, 2. Recreational)", "1", "2");

            // Question 10: What time of day do you prefer to practice sports? (1. Morning, 2. Afternoon, 3. Evening)
            String practiceTime = getValidAnswer(scanner, "10. What time of day do you prefer to practice sports? (1. Morning, 2. Afternoon, 3. Evening)", "1", "2", "3");

            // Question 11: Would you be interested in joining a sports club at the university? (1. Yes, 2. No)
            String joinClub = getValidAnswer(scanner, "11. Would you be interested in joining a sports club at the university? (1. Yes, 2. No)", "1", "2");

            // Question 12: What sports equipment do you currently own? (e.g., Ball, Racket, Shoes, etc.)
            String equipment = getValidAnswer(scanner, "12. What sports equipment do you currently own? (1.Ball 2.Racket 3.Shoes)",  "1","2");

            // Question 13: Would you prefer to train indoors or outdoors? (1. Indoors, 2. Outdoors)
            String trainingLocation = getValidAnswer(scanner, "13. Would you prefer to train indoors or outdoors? (1. Indoors, 2. Outdoors)", "1", "2");

            // Question 14: How important is fitness to you? (1. Very important, 2. Important, 3. Not important)
            String fitnessImportance = getValidAnswer(scanner, "14. How important is fitness to you? (1. Very important, 2. Important, 3. Not important)", "1", "2", "3");

            // Question 15: Do you have any suggestions to improve university sports programs?
            System.out.print("15. Do you have any suggestions to improve university sports programs? ");
            String suggestions = scanner.nextLine();

            // Thank the user for completing the survey
            System.out.println("\nThank you for completing the survey, " + name + "!");
            System.out.println("Your responses have been recorded.");
        } else {
            System.out.println("Thank you for your time! Your responses will still help us improve our sports programs.");
        }

        // Close the scanner
        scanner.close();
    }

    // Method to validate the user input for questions with options (1, 2, 3, etc.)
    public static String getValidAnswer(Scanner scanner, String question, String... validAnswers) {
        String answer;
        while (true) {
            System.out.println(question);
            answer = scanner.nextLine();

            // Check if the answer is valid
            for (String validAnswer : validAnswers) {
                if (answer.equals(validAnswer)) {
                    return answer;
                }
            }

            // If answer is invalid, ask again
            System.out.println("Invalid input. Please enter one of the following options: " + String.join(", ", validAnswers));
        }
    }
}
