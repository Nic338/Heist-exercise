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


        List<TeamMember> Team = new List<TeamMember>();

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
        int bankDifficulty = 100;
        int totalSkillLevel = 0;

        foreach (var member in Team)
        {
            totalSkillLevel += member.SkillLevel;
        }

        Console.WriteLine("-----Heist Report-----");
        Console.WriteLine($"Total Team Skill Level: {totalSkillLevel}");
        Console.WriteLine($"Bank Difficulty Level: {bankDifficulty}");

        if (totalSkillLevel >= bankDifficulty)
        {
            Console.WriteLine("The Heist was a Success!");
        }
        else
        {
            Console.WriteLine("Skill Level too low! Try again with a new team");
        }
    }
}
