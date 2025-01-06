def get_valid_answer(prompt, valid_answers):
    while True:
        answer = input(prompt + "\n")
        if answer in valid_answers:
            return answer
        print(f"Invalid input. Please enter one of the following options: {', '.join(valid_answers)}")


def main():
    # Welcome message
    print("Welcome to the University Sports Interest Survey!")
    print("This survey will help us understand your sports preferences and participation.")

    # Question 1: What is your name?
    name = input("1. What is your name? ")

    # Question 2: What is your age? (Valid input: 1, 2, 3)
    age = get_valid_answer("2. What is your age? (1. 18-22, 2. 23-27, 3. 28 and above)", ["1", "2", "3"])

    # Question 3: What year of university are you in? (Valid input: 1, 2, 3, 4)
    year_of_university = get_valid_answer(
        "3. What year of university are you in? (1. 1st Year, 2. 2nd Year, 3. 3rd Year, 4. 4th Year)", ["1", "2", "3", "4"]
    )

    # Question 4: Do you play any sports? (Valid input: 1. Yes, 2. No)
    plays_sports = get_valid_answer("4. Do you play any sports? (1. Yes, 2. No)", ["1", "2"])

    if plays_sports == "1":
        # Additional questions for sports players
        sport_played = get_valid_answer(
            "5. Which sports do you play? (1. Soccer, 2. Basketball, 3. Tennis, 4. Swimming, 5. Volleyball)", ["1", "2", "3", "4", "5"]
        )
        skill_level = get_valid_answer(
            "6. How would you rate your skill level in your chosen sport? (1. Beginner, 2. Intermediate, 3. Expert)", ["1", "2", "3"]
        )
        practice_frequency = get_valid_answer(
            "7. How often do you practice your sport? (1. Daily, 2. Weekly, 3. Occasionally)", ["1", "2", "3"]
        )
        team_sport = get_valid_answer("8. Do you participate in any team sports? (1. Yes, 2. No)", ["1", "2"])
        sport_type = get_valid_answer(
            "9. What is your preferred type of sport? (1. Competitive, 2. Recreational)", ["1", "2"]
        )
        practice_time = get_valid_answer(
            "10. What time of day do you prefer to practice sports? (1. Morning, 2. Afternoon, 3. Evening)", ["1", "2", "3"]
        )
        join_club = get_valid_answer(
            "11. Would you be interested in joining a sports club at the university? (1. Yes, 2. No)", ["1", "2"]
        )
        equipment = get_valid_answer(
            "12. What sports equipment do you currently own? (1. Ball, 2. Racket, 3. Shoes)", ["1", "2", "3"]
        )
        training_location = get_valid_answer(
            "13. Would you prefer to train indoors or outdoors? (1. Indoors, 2. Outdoors)", ["1", "2"]
        )
        fitness_importance = get_valid_answer(
            "14. How important is fitness to you? (1. Very important, 2. Important, 3. Not important)", ["1", "2", "3"]
        )
        suggestions = input("15. Do you have any suggestions to improve university sports programs? ")

        print("\nThank you for completing the survey, " + name + "!")
        print("Your responses have been recorded.")
    else:
        print("Thank you for your time! Your responses will still help us improve our sports programs.")


if __name__ == "__main__":
    main()
