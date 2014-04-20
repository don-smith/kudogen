using System.Linq;
using System.Web.Http;
using Kudogen.Model;
using Kudogen.DataAccess;
using Newtonsoft.Json.Linq;
using Breeze.ContextProvider;
using Breeze.WebApi2;

namespace Kudogen.Web.Controllers
{
    [BreezeController]
    public class BreezeController : ApiController
    {
        // Todo: inject via an interface rather than "new" the concrete class
        readonly KudogenRepository _repository = new KudogenRepository();

        [HttpGet]
        public string Metadata()
        {
            return _repository.Metadata;
        }

        [HttpPost]
        public SaveResult SaveChanges(JObject saveBundle)
        {
            return _repository.SaveChanges(saveBundle);
        }

        [HttpGet]
        public IQueryable<TeamMember> TeamMembers()
        {
            return _repository.TeamMembers;
        }

        [HttpGet]
        public IQueryable<Award> AvailableAwards()
        {
            return _repository.AvailableAwards;
        }

        [HttpPost]
        public Award AddAward(Award award)
        {
            return _repository.AddAward(award);
        }

        [HttpGet]
        public IQueryable<Nomination> CurrentNominations()
        {
            return _repository.CurrentNominations;
        }

        [HttpGet]
        public IQueryable<Nomination> PastNominations()
        {
            return _repository.PastNominations;
        }

        /// <summary>
        /// Query returing a 1-element array with a lookups object whose 
        /// properties are all Rooms, Tracks, and TimeSlots.
        /// </summary>
        /// <returns>
        /// Returns one object, not an IQueryable, 
        /// whose properties are "rooms", "tracks", "timeslots".
        /// The items arrive as arrays.
        /// </returns>
        [HttpGet]
        public object Lookups()
        {
            var teamMembers = _repository.TeamMembers;
            var availableAwards = _repository.AvailableAwards;
            var currentNominations = _repository.CurrentNominations;
            var pastNominations = _repository.PastNominations;
            return new { teamMembers, availableAwards, currentNominations, pastNominations };
        }

        // Diagnostic
        [HttpGet]
        public string Ping()
        {
            return "pong";
        }
    }
}