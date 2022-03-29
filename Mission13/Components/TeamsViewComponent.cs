using Microsoft.AspNetCore.Mvc;
using Mission13.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission13.Components
{
    public class TeamsViewComponent : ViewComponent
    {
        private ITeamsRepository repo { get; set; }
        public TeamsViewComponent(ITeamsRepository temp)
        {
            repo = temp;
        }

        
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedTeam = RouteData?.Values["team"];
            var T = repo.Teams;
                //.Select(x => x.TeamID)
                //.Distinct()
                //.OrderBy(x => x);

            return View(T);
        }
    }
}
