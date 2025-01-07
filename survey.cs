using System;
using System.IO;

namespace DynamicSurvey
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the JSON file
            string jsonFilePath = "survey.json";

            if (!File.Exists(jsonFilePath))
            {
                Console.WriteLine("Error: survey.json file not found.");
                return;
            }

            try
            {
                // Load the JSON file
                string jsonContent = File.ReadAllText(jsonFilePath);

                // Parse the JSON manually
                Survey survey = ParseSurvey(jsonContent);

                if (survey != null)
                {
                    Console.WriteLine($"Welcome to the {survey.Title}\n");

                    foreach (var question in survey.Questions)
                    {
                        Console.WriteLine($"{question.Id}. {question.Text}");

                        if (question.Type == "choice" && question.Options != null)
                        {
                            for (int i = 0; i < question.Options.Length; i++)
                            {
                                Console.WriteLine($"  {i + 1}. {question.Options[i]}");
                            }
                        }

                        Console.Write("Your answer: ");
                        string userAnswer = Console.ReadLine();

                        if (question.Branch != null)
                        {
                            for (int i = 0; i < question.Branch.Length; i++)
                            {
                                if (question.Branch[i].Key == userAnswer)
                                {
                                    question.Id = question.Branch[i].Value;
                                    break;
                                }
                            }
                        }
                    }

                    Console.WriteLine("\nThank you for completing the survey!");
                }
                else
                {
                    Console.WriteLine("Failed to load survey.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        static Survey ParseSurvey(string json)
        {
            Survey survey = new Survey();

            // Extract the title
            survey.Title = ExtractJsonValue(json, "Title");

            // Extract the questions
            string questionsJson = ExtractJsonObject(json, "Questions");
            string[] questionBlocks = SplitJsonArray(questionsJson);

            survey.Questions = new Question[questionBlocks.Length];
            for (int i = 0; i < questionBlocks.Length; i++)
            {
                string questionBlock = questionBlocks[i];
                Question question = new Question
                {
                    Id = int.Parse(ExtractJsonValue(questionBlock, "Id")),
                    Text = ExtractJsonValue(questionBlock, "Text"),
                    Type = ExtractJsonValue(questionBlock, "Type"),
                    Options = ParseJsonArray(ExtractJsonObject(questionBlock, "Options")),
                    Branch = ParseJsonDictionary(ExtractJsonObject(questionBlock, "Branch"))
                };

                survey.Questions[i] = question;
            }

            return survey;
        }

        static string ExtractJsonValue(string json, string key)
        {
            string pattern = $"\"{key}\"\\s*:\\s*\"(.*?)\"";
            var match = System.Text.RegularExpressions.Regex.Match(json, pattern);
            return match.Success ? match.Groups[1].Value : null;
        }

        static string ExtractJsonObject(string json, string key)
        {
            string pattern = $"\"{key}\"\\s*:\\s*(\\{{.*?\\}}|\\[.*?\\])";
            var match = System.Text.RegularExpressions.Regex.Match(json, pattern);
            return match.Success ? match.Groups[1].Value : null;
        }

        static string[] SplitJsonArray(string jsonArray)
        {
            if (string.IsNullOrWhiteSpace(jsonArray) || jsonArray == "[]")
                return new string[0];

            jsonArray = jsonArray.Trim('[', ']');
            return jsonArray.Split(new[] { "},{" }, StringSplitOptions.RemoveEmptyEntries);
        }

        static string[] ParseJsonArray(string jsonArray)
        {
            if (string.IsNullOrWhiteSpace(jsonArray) || jsonArray == "[]")
                return null;

            jsonArray = jsonArray.Trim('[', ']').Replace("\"", "");
            return jsonArray.Split(',');
        }

        static KeyValue[] ParseJsonDictionary(string jsonDictionary)
        {
            if (string.IsNullOrWhiteSpace(jsonDictionary) || jsonDictionary == "{}")
                return null;

            jsonDictionary = jsonDictionary.Trim('{', '}');
            string[] pairs = jsonDictionary.Split(',');

            KeyValue[] result = new KeyValue[pairs.Length];
            for (int i = 0; i < pairs.Length; i++)
            {
                string[] keyValue = pairs[i].Split(':');
                result[i] = new KeyValue
                {
                    Key = keyValue[0].Trim().Replace("\"", ""),
                    Value = int.Parse(keyValue[1].Trim())
                };
            }

            return result;
        }
    }

    public class Survey
    {
        public string Title { get; set; }
        public Question[] Questions { get; set; }
    }

    public class Question
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Type { get; set; }
        public string[] Options { get; set; }
        public KeyValue[] Branch { get; set; }
    }

    public class KeyValue
    {
        public string Key { get; set; }
        public int Value { get; set; }
    }
}
