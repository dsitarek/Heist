using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heist.Models
{ 
    internal class TeamMember
    {
        public string Name { get; set; }
        public int SkillLevel { get; set; }
        public decimal  CourageFactor { get; set; }

        public TeamMember(string name, int skill, decimal courage)
        {
            Name = name;
            SkillLevel = skill;
            CourageFactor = courage;
        }

        public void Print()
        {
            Console.WriteLine($@"
Name: {Name}
Skill Level: {SkillLevel}
Courage: {CourageFactor}
");
        }
    }
}
