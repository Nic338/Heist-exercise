using System;
using System.Text.RegularExpressions;

public class Program
{

    static void Main(string[] args)
    {
        Heist();
    }
    static void Heist()
    {
        Console.WriteLine("Plan Your Heist!");
        Console.WriteLine("----------------");


        AddTeamMember();

    }
    static void AddTeamMember()
    {
        string name;
        string skill;
        string courage;
        int parsedSkill;
        double parsedCourage;
        string heistAttempts;
        int parsedAttempts;
        int successfulRuns = 0;
        int failedRuns = 0;

        List<TeamMember> Team = new List<TeamMember>();

        Console.WriteLine("-- Enter the Bank Difficulty --");
        int userDifficulty = int.Parse(Console.ReadLine());

        while (true)
        {
            Console.WriteLine("What is the name of your new Team Member? (PRESS ENTER TO STOP ADDING TEAM MEMBERS)");
            name = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name))
                break;
            if (Regex.IsMatch(name, "^[a-zA-Z]+$"))
            {

            }
            else
            {
                Console.WriteLine("Invalid Input: Must Enter a Name");
                AddTeamMember();

            }


            Console.WriteLine("What is the Skill Level of your new Team Member?");
            Console.WriteLine("(On a scale from 1 - 100)");
            skill = Console.ReadLine();

            try
            {

                parsedSkill = int.Parse(skill);

                if (parsedSkill >= 1 && parsedSkill <= 100)
                {

                }
                else
                {
                    Console.WriteLine("Skill Level MUST be between 1 and 100!");
                    AddTeamMember();
                }

                Console.WriteLine("What is the Courage Factor of your new Team Member?");
                Console.WriteLine("(On a scale from 0.0 - 2.0)");
                courage = Console.ReadLine();

                parsedCourage = double.Parse(courage);

                if (parsedCourage >= 0.0 && parsedCourage <= 2.0)
                {

                }
                else
                {
                    Console.WriteLine("Courage Factor MUST be between 0.0 and 2.0!");
                    AddTeamMember();
                }

                var newTeamMember = new TeamMember(name, parsedSkill, parsedCourage);

                Console.WriteLine($"New Team Member {name} has a skill level of {parsedSkill} and courage factor of {parsedCourage}");

                Team.Add(newTeamMember);
                Console.WriteLine();
            }
            catch
            {
                Console.WriteLine("Please Enter a valid number");

                AddTeamMember();
            }
        }



        Console.WriteLine("Enter the number of heists you want to attempt: ");
        heistAttempts = Console.ReadLine();
        parsedAttempts = int.Parse(heistAttempts);

        for (var i = 1; i <= parsedAttempts; i++)
        {
            Console.WriteLine($"-- Heist #{i} --");
            int totalSkillLevel = 0;

            foreach (var member in Team)
            {
                totalSkillLevel += member.SkillLevel;
            }

            int luckValue = new Random().Next(-10, 10);
            int randomBankDifficulty = luckValue + userDifficulty;

            Console.WriteLine("-----Heist Report-----");
            Console.WriteLine($"Total Team Skill Level: {totalSkillLevel}");
            Console.WriteLine($"Bank Difficulty Level: {randomBankDifficulty}");

            if (totalSkillLevel >= randomBankDifficulty)
            {
                Console.WriteLine("The Heist was a Success!");
                successfulRuns++;
            }
            else
            {
                Console.WriteLine("Skill Level too low! Try again with a new team");
                failedRuns++;
            }
        Console.WriteLine();

        }
        Console.WriteLine();
        Console.WriteLine($"Successful Heists: {successfulRuns}");
        Console.WriteLine();
        Console.WriteLine($"Failed Heists: {failedRuns}");
        Console.WriteLine();
    }
}
