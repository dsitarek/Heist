using Heist.Models;

var title = $@"
 _______   __         ______   __    __        __      __   ______   __    __  _______         __    __  ________  ______   ______  ________ 
|       \ |  \       /      \ |  \  |  \      |  \    /  \ /      \ |  \  |  \|       \       |  \  |  \|        \|      \ /      \|        \
| $$$$$$$\| $$      |  $$$$$$\| $$\ | $$       \$$\  /  $$|  $$$$$$\| $$  | $$| $$$$$$$\      | $$  | $$| $$$$$$$$ \$$$$$$|  $$$$$$\\$$$$$$$$
| $$__/ $$| $$      | $$__| $$| $$$\| $$        \$$\/  $$ | $$  | $$| $$  | $$| $$__| $$      | $$__| $$| $$__      | $$  | $$___\$$  | $$   
| $$    $$| $$      | $$    $$| $$$$\ $$         \$$  $$  | $$  | $$| $$  | $$| $$    $$      | $$    $$| $$  \     | $$   \$$    \   | $$   
| $$$$$$$ | $$      | $$$$$$$$| $$\$$ $$          \$$$$   | $$  | $$| $$  | $$| $$$$$$$\      | $$$$$$$$| $$$$$     | $$   _\$$$$$$\  | $$   
| $$      | $$_____ | $$  | $$| $$ \$$$$          | $$    | $$__/ $$| $$__/ $$| $$  | $$      | $$  | $$| $$_____  _| $$_ |  \__| $$  | $$   
| $$      | $$     \| $$  | $$| $$  \$$$          | $$     \$$    $$ \$$    $$| $$  | $$      | $$  | $$| $$     \|   $$ \ \$$    $$  | $$   
 \$$       \$$$$$$$$ \$$   \$$ \$$   \$$           \$$      \$$$$$$   \$$$$$$  \$$   \$$       \$$   \$$ \$$$$$$$$ \$$$$$$  \$$$$$$    \$$   
                                                                                                                                                                                                                                                                                        
 Enter exit to leave or hit enter to continue                                                                                                                                            ";

Console.WriteLine(title);

var exit = Console.ReadLine();

while (exit != "exit")
{
    List<TeamMember> teamMembers = new List<TeamMember>();
    bool teamComplete = false;

    while (!teamComplete)
    {
        Console.WriteLine("Enter team member name:");
        var name = Console.ReadLine();
        if (name == "") break;

        bool successful = false;
        int parsedSkill = 0;
        decimal parsedCourage = 0;

        while (!successful)
        {
            Console.WriteLine($"Enter {name}'s skill level");
            var skill = Console.ReadLine();
            successful = int.TryParse(skill, out parsedSkill);
        }

        successful = false;

        while (!successful)
        {
            Console.WriteLine($"Enter {name}'s courage level");
            var courage = Console.ReadLine();
            successful = decimal.TryParse(courage, out parsedCourage);
        }

        teamMembers.Add(new TeamMember(name, parsedSkill, parsedCourage));
    }

    bool successful2 = false;
    var bankDifficulty = 0;

    while (!successful2)
    {
        Console.WriteLine("Enter bank difficulty level");
        var bankDifficultyInput = Console.ReadLine();
        successful2 = int.TryParse(bankDifficultyInput, out bankDifficulty);
    }

    successful2 = false;
    var trialRuns = 1;
    while (!successful2)
    {
        Console.WriteLine("Enter number of trial runs");
        var trialRunInput = Console.ReadLine();
        successful2 = int.TryParse(trialRunInput, out trialRuns);
    }

    int goodRuns = 0;
    int badRuns = 0;

    for (int i = 1; i <= trialRuns; i++)
    {
        int teamSkill = 0;
        Random rng = new Random();
        int luck = rng.Next(-10, 10);
        int thisRunDifficulty = bankDifficulty;
        thisRunDifficulty += luck;

        foreach (var teamMember in teamMembers)
        {
            teamSkill += teamMember.SkillLevel;
        }

        Console.WriteLine($"Team Skill: {teamSkill} Bank Difficulty: {thisRunDifficulty} Luck: {luck}");

        if (teamSkill > thisRunDifficulty)
        {
            Console.WriteLine($"Run {i}: The team successfully robs the bank!");
            goodRuns += 1;
        }
        else
        {
            Console.WriteLine($"Run {i}:The team was not skillful enough to rob the bank.");
            badRuns += 1;
        }
    }
    Console.WriteLine($@"Successful: {goodRuns} 
Unsuccessful: {badRuns}


Start a new team or type 'exit' to exit
");
}