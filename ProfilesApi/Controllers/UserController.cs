using ProfileAPI.Domain;
using ProfileAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ProfileAPI.Controllers
{
    [Route("api/profiles")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ProfileService _profileService;

        public UserController(ProfileService profileService)
        {
            _profileService = profileService;
        }

        [HttpGet]
        public ActionResult<List<UserProfile>> Get() =>
            _profileService.Get();

        [HttpGet("{id:length(24)}", Name = "GetProfile")]
        public ActionResult<UserProfile> Get(string id)
        {
            var profile = _profileService.Get(id);

            if (profile == null)
            {
                return NotFound();
            }

            return profile;
        }

        [HttpPost]
        public ActionResult<UserProfile> Create(UserProfile profile)
        {
            _profileService.Create(profile);

            return CreatedAtRoute("GetProfile", new { id = profile.Id.ToString() }, profile);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, UserProfile profileIn)
        {
            var profile = _profileService.Get(id);

            if (profile == null)
            {
                return NotFound();
            }

            _profileService.Update(id, profileIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var profile = _profileService.Get(id);

            if (profile == null)
            {
                return NotFound();
            }

            _profileService.Remove(profile.Id);

            return NoContent();
        }
    }
}