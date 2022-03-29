using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission13.Models
{
    public class EFTeamsRepository : ITeamsRepository
    {
        private BowlersDbContext _context { get; set; }

        public EFTeamsRepository(BowlersDbContext temp)
        {
            _context = temp;
        }
        public IQueryable<Team> Teams => _context.Teams;

        public void SaveTeam(Team t)
        {
            if (t.TeamID == 0)
            {
                var max = _context.Teams.Max(x => x.TeamID);
                t.TeamID = max + 1;
                _context.Update(t);
                _context.SaveChanges();
            }

            else
            {
                _context.Update(t);
                _context.SaveChanges();
            }

        }

        public void AddTeam(Team t)
        {
            if (t.TeamID == 0)
            {
                var max = _context.Teams.Max(x => x.TeamID);
                t.TeamID = max + 1;
                _context.Add(t);
                _context.SaveChanges();
            }

            else
            {
                _context.Add(t);
                _context.SaveChanges();
            }

        }

        public void DeleteTeam(Team t)
        {
            _context.Remove(t);
            _context.SaveChanges();
        }


    }
}
