const fs = require("fs");
const prompt = require("prompt-sync")();

// Function to ask a question
function askQuestion(question) {
    console.log(`\n${question.text}`);

    if (question.type === "choice") {
        // Display options for choice questions
        question.options.forEach((option, index) => {
            console.log(`${index + 1}. ${option}`);
        });

        while (true) {
            const choice = parseInt(prompt("Enter the number of your choice: "), 10);
            if (choice >= 1 && choice <= question.options.length) {
                return question.options[choice - 1];
            } else {
                console.log("Invalid choice. Please try again.");
            }
        }
    } else if (question.type === "text") {
        // Handle open-ended questions
        return prompt("Your answer: ");
    }
}

// Function to run the survey
function runSurvey(survey) {
    console.log(`Welcome to the ${survey.title}!\n`);
    const answers = {};
    const questionMap = Object.fromEntries(survey.questions.map(q => [q.id, q]));
    let currentId = 1;
    const lastQuestionId = Math.max(...survey.questions.map(q => q.id));

    while (currentId <= lastQuestionId) {
        const question = questionMap[currentId];
        const answer = askQuestion(question);
        answers[currentId] = answer;

        // Handle branching logic
        if (question.branch && question.branch[answer]) {
            currentId = question.branch[answer];
        } else {
            currentId += 1;
        }
    }

    // Print the final message
    console.log(`\n${survey.finalMessage}`);
    return answers;
}

// Load survey data from the JSON file
const surveyData = JSON.parse(fs.readFileSync("survey.json", "utf-8"));

// Run the survey
const userAnswers = runSurvey(surveyData);


;
