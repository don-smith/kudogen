using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kudogen.Model;

namespace Kudogen.DataAccess
{
    public class TeamInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<KudogenDbContext>
    {
        protected override void Seed(KudogenDbContext context)
        {
            var teamMembers = new List<TeamMember>
            {
                new TeamMember{Name = "David Shorter", Email = "david@intergenusa.com", IsAdmin = false, IsApproved = true},
                new TeamMember{Name = "Lee Farley", Email = "lee@intergenusa.com", IsAdmin = false, IsApproved = true},
                new TeamMember{Name = "Ben Fox", Email = "ben@intergenusa.com", IsAdmin = false, IsApproved = true},
                new TeamMember{Name = "Jonny Lin", Email = "jonny@intergenusa.com", IsAdmin = false, IsApproved = true},
                new TeamMember{Name = "Tim Woolford", Email = "tim@intergenusa.com", IsAdmin = false, IsApproved = true},
                new TeamMember{Name = "Amber Williams", Email = "amber@intergenusa.com", IsAdmin = false, IsApproved = true},
                new TeamMember{Name = "Melissa Willoughby", Email = "melissa@intergenusa.com", IsAdmin = false, IsApproved = true},
                new TeamMember{Name = "James Carpinter", Email = "james@intergenusa.com", IsAdmin = false, IsApproved = true},
                new TeamMember{Name = "Don Smith", Email = "don@intergenusa.com", IsAdmin = true, IsApproved = true},
                new TeamMember{Name = "Jay Templeton", Email = "jay@intergenusa.com", IsAdmin = true, IsApproved = true},
                new TeamMember{Name = "April Dinius", Email = "april@intergenusa.com", IsAdmin = true, IsApproved = true},
                new TeamMember{Name = "Liz Larsen", Email = "liz@intergenusa.com", IsAdmin = true, IsApproved = true},
                new TeamMember{Name = "Hamish Hill", Email = "hamish@intergenusa.com", IsAdmin = true, IsApproved = true}
            };
            teamMembers.ForEach(m => context.TeamMembers.Add(m));
            context.SaveChanges();
        }
    }
}
