using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission13.Models
{
    public class EFBowlersRepository : IBowlersRepository
    {
        private BowlersDbContext _context { get; set; }

        public EFBowlersRepository(BowlersDbContext temp)
        {
            _context = temp;
        }
        public IQueryable<Bowler> Bowlers => _context.Bowlers;

        public void SaveBowler(Bowler b)
        {
            if (b.BowlerID == 0)
            {
                var max = _context.Bowlers.Max(x => x.BowlerID);
                b.BowlerID = max + 1;
                _context.Update(b);
                _context.SaveChanges();
            }

            else
            {
                _context.Update(b);
                _context.SaveChanges();
            }

        }

        public void AddBowler(Bowler b)
        {
            if (b.BowlerID == 0)
            {
                var max = _context.Bowlers.Max(x => x.BowlerID);
                b.BowlerID = max + 1;
                _context.Add(b);
                _context.SaveChanges();
            }

            else
            {
                _context.Add(b);
                _context.SaveChanges();
            }

        }

        public void DeleteBowler(Bowler b)
        {
            _context.Remove(b);
            _context.SaveChanges();
        }


    }
}
