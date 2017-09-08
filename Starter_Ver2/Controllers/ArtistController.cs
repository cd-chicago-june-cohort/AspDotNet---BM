using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using JsonData;

namespace MusicApi.Controllers {

    
    public class ArtistController : Controller {

        private List<Artist> allArtists;

        public ArtistController() {
            allArtists = JsonToFile<Artist>.ReadJson();
        }

        //This method is shown to the user navigating to the default API domain name
        //It just display some basic information on how this API functions
        [Route("")]
        [HttpGet]
        public string Index() {
            //String describing the API functionality
            string instructions = "Welcome to the Music API~~\n========================\n";
            instructions += "    Use the route /artists/ to get artist info.\n";
            instructions += "    End-points:\n";
            instructions += "       *Name/{string}\n";
            instructions += "       *RealName/{string}\n";
            instructions += "       *Hometown/{string}\n";
            instructions += "       *GroupId/{int}\n\n";
            instructions += "    Use the route /groups/ to get group info.\n";
            instructions += "    End-points:\n";
            instructions += "       *Name/{string}\n";
            instructions += "       *GroupId/{int}\n";
            instructions += "       *ListArtists=?(true/false)\n";
            return instructions;
        }

        [HttpGet]
        [Route("artists")]
        public JsonResult artistsAPI()
        {
            return Json(allArtists);
        }

        [HttpGet]
        [Route("artists/name/{name}")]
        public JsonResult artistNameAPI(string name)
        {
            List<Artist> artistName = allArtists.Where(match => match.ArtistName == name).ToList();
            return Json(artistName);
        }

        [HttpGet]
        [Route("artists/realname/{name}")]
        public JsonResult artistRealNameAPI(string name)
        {
            List<Artist> artistRealName = allArtists.Where(match => match.RealName == name).ToList();
            return Json(artistRealName);
        }

        [HttpGet]
        [Route("artists/hometown/{town}")]
        public JsonResult artistHometownAPI(string town)
        {
            List<Artist> artistHometown = allArtists.Where(match => match.Hometown == town).ToList();
            return Json(artistHometown);
        }

        [HttpGet]
        [Route("artists/groupid/{id}")]
        public JsonResult artistIdAPI(int id)
        {
            List<Artist> groupId = allArtists.Where(match => match.GroupId == id).ToList();
            return Json(groupId);
        }
    }
}
