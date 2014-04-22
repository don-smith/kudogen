using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kudogen.Model;

namespace Kudogen.DataAccess
{
    public class DataInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<KudogenDbContext>
    {
        protected override void Seed(KudogenDbContext context)
        {
            var teamMembers = new List<TeamMember>
            {
                new TeamMember{ Name = "David Shorter", Email = "david@intergenusa.com", IsAdmin = false, IsApproved = true },
                new TeamMember{ Name = "Lee Farley", Email = "lee@intergenusa.com", IsAdmin = false, IsApproved = true },
                new TeamMember{ Name = "Ben Fox", Email = "ben@intergenusa.com", IsAdmin = false, IsApproved = true },
                new TeamMember{ Name = "Jonny Lin", Email = "jonny@intergenusa.com", IsAdmin = false, IsApproved =  true },
                new TeamMember{ Name = "Tim Woolford", Email = "tim@intergenusa.com", IsAdmin = false, IsApproved = true },
                new TeamMember{ Name = "Amber Williams", Email = "amber@intergenusa.com", IsAdmin = false, IsApproved = true },
                new TeamMember{ Name = "Melissa Willoughby", Email = "melissa@intergenusa.com", IsAdmin = false, IsApproved = true },
                new TeamMember{ Name = "James Carpinter", Email = "james@intergenusa.com", IsAdmin = false, IsApproved = true },
                new TeamMember{ Name = "Don Smith", Email = "don@intergenusa.com", IsAdmin = true, IsApproved = true },
                new TeamMember{ Name = "Jay Templeton", Email = "jay@intergenusa.com", IsAdmin = true, IsApproved = true },
                new TeamMember{ Name = "April Dinius", Email = "april@intergenusa.com", IsAdmin = true, IsApproved = true },
                new TeamMember{ Name = "Liz Larsen", Email = "liz@intergenusa.com", IsAdmin = true, IsApproved = true },
                new TeamMember{ Name = "Hamish Hill", Email = "hamish@intergenusa.com", IsAdmin = true, IsApproved = true }
            };
            teamMembers.ForEach(m => context.TeamMembers.Add(m));
            context.SaveChanges();

            var awards = new List<Award>
            {
                new Award { IsActive = true, Name = "El Cheapo", WinnerType = WinnerTypeEnum.Everyone },
                new Award { IsActive = true, Name = "Customer Pet", WinnerType = WinnerTypeEnum.Vote },
                new Award { IsActive = true, Name = "MVP", WinnerType = WinnerTypeEnum.Random },
                new Award { IsActive = false, Name = "Old Dog", WinnerType = WinnerTypeEnum.Random }
            };

            awards.ForEach(a => context.Awards.Add(a));
            context.SaveChanges();

            var nominations = new List<Nomination>
            {
                // Upcoming nominations
                new Nomination
                {
                    AwardId = 1,
                    NominatorId = 1,
                    NominateeId = 2,
                    BecauseText = "He's an el cheapo",
                    DateSubmitted = DateTime.Now.Subtract(new TimeSpan(6, 0, 0, 0)),
                    IsWinner = null
                },
                new Nomination
                {
                    AwardId = 2,
                    NominatorId = 2,
                    NominateeId = 3,
                    BecauseText = "He's a customer pet",
                    DateSubmitted = DateTime.Now.Subtract(new TimeSpan(4, 0, 0, 0)),
                    IsWinner = null
                },
                new Nomination
                {
                    AwardId = 3,
                    NominatorId = 3,
                    NominateeId = 4,
                    BecauseText = "He's an MVP",
                    DateSubmitted = DateTime.Now.Subtract(new TimeSpan(5, 0, 0, 0)),
                    IsWinner = null
                },

                // Past nominations
                new Nomination
                {
                    AwardId = 1,
                    NominatorId = 1,
                    NominateeId = 2,
                    BecauseText = "He's an el cheapo",
                    DateSubmitted = DateTime.Now.Subtract(new TimeSpan(13, 0, 0, 0)),
                    IsWinner = true
                },
                new Nomination
                {
                    AwardId = 2,
                    NominatorId = 2,
                    NominateeId = 3,
                    BecauseText = "He's a customer pet",
                    DateSubmitted = DateTime.Now.Subtract(new TimeSpan(11, 0, 0, 0)),
                    IsWinner = false
                },
                new Nomination
                {
                    AwardId = 3,
                    NominatorId = 3,
                    NominateeId = 4,
                    BecauseText = "He's an MVP",
                    DateSubmitted = DateTime.Now.Subtract(new TimeSpan(12, 0, 0, 0)),
                    IsWinner = true
                },

                // Inactive award nominations
                new Nomination
                {
                    AwardId = 4,
                    NominatorId = 4,
                    NominateeId = 5,
                    BecauseText = "This shouldn't show up. Inactive award.",
                    DateSubmitted = DateTime.Now.Subtract(new TimeSpan(30, 0, 0, 0)),
                    IsWinner = false
                }
            };

            nominations.ForEach(n => context.Nominations.Add(n));
            context.SaveChanges();
        }
    }
}
