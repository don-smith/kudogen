using System.Linq;
using Breeze.ContextProvider;
using Breeze.ContextProvider.EF6;
using Newtonsoft.Json.Linq;
using Kudogen.Model;

namespace Kudogen.DataAccess
{
    /// <summary>
    /// Repository (a "Unit of Work" really) of Kudogen models.
    /// </summary>
    public class KudogenRepository
    {
        private readonly EFContextProvider<KudogenDbContext>
            _contextProvider = new EFContextProvider<KudogenDbContext>();

        private KudogenDbContext Context { get { return _contextProvider.Context; } }

        public string Metadata
        {
            get { return _contextProvider.Metadata(); }
        }

        public SaveResult SaveChanges(JObject saveBundle)
        {
            return _contextProvider.SaveChanges(saveBundle);
        }

        public IQueryable<TeamMember> TeamMembers
        {
            get { return Context.TeamMembers; }
        }

        public IQueryable<Award> AvailableAwards
        {
            get { return Context.Awards.Where(a => a.IsActive); }
        }

        public Award AddAward(Award award)
        {
            var savedAward = Context.Awards.Add(award);
            return savedAward;
        }

        public IQueryable<Nomination> CurrentNominations
        {
            get { return Context.Nominations.Where(n => n.IsWinner == null); }
        }

        public IQueryable<Nomination> PastNominations
        {
            get { return Context.Nominations.Where(n => n.IsWinner != null); }
        }
    }
}