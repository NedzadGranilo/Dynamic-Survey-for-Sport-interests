import json

def ask_question(question):
    """Ask a question based on its type."""
    print(f"\n{question['text']}")
    
    if question["type"] == "choice":
        # Display options for choice questions
        for i, option in enumerate(question["options"], 1):
            print(f"{i}. {option}")
        while True:
            try:
                choice = int(input("Enter the number of your choice: "))
                if 1 <= choice <= len(question["options"]):
                    return question["options"][choice - 1]
                else:
                    print("Invalid choice. Please choose a valid option.")
            except ValueError:
                print("Invalid input. Please enter a number.")
    
    elif question["type"] == "text":
        # Handle open-ended questions
        return input("Your answer: ")

def run_survey(survey):
    """Run the survey and collect answers."""
    print(f"Welcome to the {survey['title']}!\n")
    answers = {}
    question_map = {q["id"]: q for q in survey["questions"]}
    current_id = 1
    last_question_id = max(question_map.keys())
    
    while current_id <= last_question_id:
        question = question_map[current_id]
        answer = ask_question(question)
        answers[current_id] = answer
        
        # Handle branching logic
        if "branch" in question and answer in question["branch"]:
            current_id = question["branch"][answer]
        else:
            current_id += 1

    # Print the final message
    print(f"\n{survey['finalMessage']}")
    return answers

# Read survey data from a JSON file
with open("survey.json", "r") as file:
    survey_data = json.load(file)

# Run the survey
user_answers = run_survey(survey_data)

