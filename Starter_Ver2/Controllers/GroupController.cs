using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using JsonData;

namespace MusicApi.Controllers {
    public class GroupController : Controller {
        List<Group> allGroups {get; set;}
        public GroupController() {
            allGroups = JsonToFile<Group>.ReadJson();
        }

        [HttpGet]
        [Route("groups")]
        public JsonResult groupsAPI()
        {
            return Json(allGroups);
        }

        [HttpGet]
        [Route("groups/name/{name}")]
        public JsonResult groupNameAPI(string name)
        {
            List<Group> groupName = allGroups.Where(match => match.GroupName == name).ToList();
            return Json(groupName);
        }

        [HttpGet]
        [Route("groups/id/{id}")]
        public JsonResult groupIdAPI(int id)
        {
            List<Group> groupid = allGroups.Where(match => match.Id == id).ToList();
            return Json(groupid);
        }

    }
}